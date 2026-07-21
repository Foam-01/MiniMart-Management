using Microsoft.AspNetCore.Mvc;
using TestConsole.Services;

namespace TestConsole.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupabaseController : ControllerBase
    {
        private readonly IConfiguration _config;
        public SupabaseController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("test-connection")]
        public async Task<IActionResult> TestConnection()
        {
            try
            {
                var svc = new SupabaseService(_config);
                var result = await svc.TestConnectionAsync();

                if (result.Success)
                {
                    return Ok(new { success = true, message = result.Message });
                }

                return StatusCode(500, new { success = false, message = result.Message, detail = result.Detail });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
