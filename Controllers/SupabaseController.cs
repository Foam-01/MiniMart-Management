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

        [HttpGet("{table}")]
        public async Task<IActionResult> GetTable(string table)
        {
            try
            {
                var svc = new SupabaseService(_config);
                var result = await svc.GetTableAsync(table);

                if (result.Success && result.Json.HasValue)
                    return Ok(result.Json.Value);

                // Return Supabase response details for debugging
                return StatusCode(result.StatusCode, new { success = result.Success, status = result.StatusCode, body = result.Body });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(502, new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
