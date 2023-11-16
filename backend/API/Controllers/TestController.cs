using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController : Controller
    {
        [HttpGet("test")]
        public string GetTestData()
        {
            return "ok";
        }
    }
}
