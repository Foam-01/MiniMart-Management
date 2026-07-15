using Microsoft.AspNetCore.Mvc;
using Npgsql;
using TestConsole.Services;
using System.Collections.Generic;
using System;

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

    }

}



