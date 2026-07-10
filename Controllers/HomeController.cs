using Microsoft.AspNetCore.Mvc;

namespace TestConsole.Controllers
{
    [ApiController]
    [Route("[action]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { message = "Hello" });
        }

        [HttpPost]
        [Route("/{name}")]
        public IActionResult PostData(string name)
        {
            return Ok(new { message = "Hello " + name });
        }

        [HttpPut]
        [Route("")]
        public IActionResult MyPut()
        {
            return Ok(new { message = "my put" });
        }

        [HttpDelete]
        [Route("/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(new { message = "delete " + id });
        }
    }
}
