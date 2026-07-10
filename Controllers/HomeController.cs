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
        [Route("[action]/{name}")]
        public IActionResult PostData(string name)
        {
            return Ok(new { message = "Hello " + name });
        }
    }
}
