using Microsoft.AspNetCore.Mvc;
using Npgsql;
using TestConsole.Services;
using System.Collections.Generic;
using System;
using CourseAPI.Models;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


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
        public async Task<IActionResult> MyGet2()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage res = await client.GetAsync("http://localhost:5000/api/Home");
                if (res.IsSuccessStatusCode)
                {
                    return Ok(await res.Content.ReadAsStringAsync());
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

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> MyPut2()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage res = await client.PutAsJsonAsync("http://localhost:5000/api/Home/Create", new
                {
                    id = 3,
                    isbn = "978-616-7027-20-4",
                    name = "Book 3",
                    price = 300
                });
                if (res.IsSuccessStatusCode)
                {
                    return Ok(await res.Content.ReadAsStringAsync());
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


        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> MyDelete2(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage res = await client.DeleteAsync("http://localhost:5000/api/Home/Remove/" + id);
                if (res.IsSuccessStatusCode)
                {
                    return Ok(await res.Content.ReadAsStringAsync());
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

        [HttpGet]
        [Route("[action]")]
        public IActionResult GenerateToken(string username, string password)
        {
            try
            {
                // 1. ตรวจสอบความถูกต้องของ Username และ Password (จำลองระบบ Login)
                if (username == "admin" && password == "admin")
                {
                    // 2. ดึงค่าการตั้งค่า JWT (เช่น Issuer, Audience, Key) จากไฟล์ appsettings.json
                    var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                    var Issuer = MyConfig.GetValue<string>("Jwt:Issuer");
                    var Audience = MyConfig.GetValue<string>("Jwt:Audience");
                    var Key = Encoding.ASCII.GetBytes(MyConfig.GetValue<string>("Jwt:Key")!);

                    // 3. กำหนดรายละเอียดของ Token (พิมพ์เขียวสำหรับสร้างบัตรผ่าน)
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        // Subject: ข้อมูลตัวตนผู้ใช้งานที่จะใส่ไว้ใน Token
                        Subject = new ClaimsIdentity(new Claim[] {
                            new Claim("id", Guid.NewGuid().ToString()), // ไอดีอ้างอิงสุ่ม
                            new Claim(JwtRegisteredClaimNames.Sub, username), // ชื่อผู้ใช้ (Subject)
                            new Claim(JwtRegisteredClaimNames.Email, "user@mail.com"), // อีเมลจำลอง
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // เลขรหัสไอดีของ Token
                        }),
                        Expires = DateTime.Now.AddDays(1), // ระยะเวลาหมดอายุของ Token (1 วัน)
                        Issuer = Issuer, // แหล่งผู้ออก Token
                        Audience = Audience, // ผู้มีสิทธิ์รับ/ใช้งาน Token
                        // นำกุญแจลับ (Key) มาเซ็นกำกับลายเซ็นดิจิทัลท้าย Token ด้วยอัลกอริทึม HmacSha512
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha512Signature)
                    };

                    // 4. เริ่มขั้นตอนการปั๊มเหรียญ Token ออกมาเป็นข้อความ
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor); // สร้างก้อนข้อมูล Token ตามพิมพ์เขียว
                    var JwtToken = tokenHandler.WriteToken(token); // แปลงก้อนข้อมูล Token ให้เป็นสายอักขระ String ยาวๆ

                    // ส่ง Token ที่สร้างเสร็จกลับไปให้ไคลเอนต์ใช้งาน
                    return Ok(new { JwtToken = JwtToken });
                }

                // หากกรอก Username หรือ Password ไม่ถูกต้อง ส่งผลลัพธ์ 401 Unauthorized กลับไป
                return Unauthorized();
            }
            catch (Exception ex)
            {
                // หากระบบเกิดข้อผิดพลาด ส่งผลลัพธ์ 500 Internal Server Error กลับไป
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }




}



