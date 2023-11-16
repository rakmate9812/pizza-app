using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController : Controller
    {
        [HttpGet("test")]
        public IActionResult GetTestData()
        {
            var data = new { message = "successfull api call" };
            return Ok(data);
        }
    }
}
