using Microsoft.AspNetCore.Mvc;
using Npgsql;
using TestConsole.Services;
using System.Collections.Generic;
using System;
using CourseAPI.Models;
using System.Threading.Tasks;

namespace TestConsole.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly SupabaseService _supabaseService;

        public HomeController(SupabaseService supabaseService)
        {
            _supabaseService = supabaseService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return Ok(new { message = "Hello" });
        }

        [HttpPost("{name}")]
        public IActionResult PostData(string name)
        {
            return Ok(new { message = "Hello " + name });
        }

        [HttpPut]
        public IActionResult MyPut()
        {
            return Ok(new { message = "my put" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(new { message = "delete " + id });
        }


        [HttpGet]
        public IActionResult List()
        {
            try
            {
                using var conn = _supabaseService.CreateConnection();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM tb_book";

                var books = new List<object>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new
                        {
                            id = Convert.ToInt32(reader["id"]),
                            isbn = Convert.ToString(reader["isbn"]),
                            name = reader["name"].ToString(),
                            price = Convert.ToInt32(reader["price"]),
                        });
                    }
                }
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult Info(int id)
        {
            try
            {
                using var conn = _supabaseService.CreateConnection();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM tb_book where id = @id";
                cmd.Parameters.AddWithValue("id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Ok(new
                        {
                            id = Convert.ToInt32(reader["id"]),
                            isbn = Convert.ToString(reader["isbn"]),
                            name = reader["name"].ToString(),
                            price = Convert.ToInt32(reader["price"]),
                        });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status404NotFound, new
                        {
                            message = "Book not found"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = ex.Message
                });

            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Edit(BookModel bookModel)
        {
            try
            {
                using var conn = _supabaseService.CreateConnection();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE tb_book SET
                        isbn = @isbn,
                        name = @name,
                        price = @price
                    WHERE id = @id
                ";
                cmd.Parameters.AddWithValue("isbn", bookModel.isbn!);
                cmd.Parameters.AddWithValue("name", bookModel.name!);
                cmd.Parameters.AddWithValue("price", bookModel.price!);
                cmd.Parameters.AddWithValue("id", bookModel.id!);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return Ok(new { message = "Book updated successfully" });
                }
                else
                {
                    return StatusCode(404, new { message = "Book not found to update" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult Create(BookModel bookModel)
        {
            try
            {
                using var conn = _supabaseService.CreateConnection();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO tb_book (isbn, name, price) VALUES(@isbn, @name, @price)";
                cmd.Parameters.AddWithValue("isbn", bookModel.isbn!);
                cmd.Parameters.AddWithValue("name", bookModel.name!);
                cmd.Parameters.AddWithValue("price", bookModel.price!);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return Ok(new { message = "Book created successfully" });
                }
                else
                {
                    return StatusCode(500, new { message = "Failed to create book" });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                using var conn = _supabaseService.CreateConnection();
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM tb_book WHERE id = @id ";
                cmd.Parameters.AddWithValue("id", id);

                if (cmd.ExecuteNonQuery() != -1)
                {
                    return Ok(new { message = "Delete success" });
                }
                else
                {
                    return StatusCode(404, new { message = "Book not found to delete" });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult UploadFile(IFormFile file)
        {
            try
            {
                if (file == null)
                {
                    return StatusCode(404, new { message = "No file upload" });
                }
                string ext = Path.GetExtension(file.FileName).ToLower();
                if (ext != ".jpg" && ext != ".jpeg" && ext != ".png" && ext != ".gif" && ext != ".bmp")
                {
                    return StatusCode(400, new { message = "Invalid file type : your ext = " + ext });
                }
                DateTime dt = DateTime.Now; //เอาวันปัจจุบัน
                Random random = new Random(); //สุ่ม
                int readerNumber = random.Next(1000000);
                string newName = $"{dt.Year}{dt.Month}{dt.Day}{dt.Hour}{dt.Minute}{dt.Second}{dt.Millisecond}{readerNumber}{ext}";
                string targetPath = "../Images/" + newName;
                using (FileStream fileStream = new FileStream(targetPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return Ok(new { message = "File uploaded successfully" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }



        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> MyGet()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage res = await client.GetAsync("http://localhost:5000/api/Home");
                if (res.IsSuccessStatusCode)
                {
                    return Ok(res.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    return StatusCode(500, new { message = "Error" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }





    }


}



