using API.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("test")]
    public class TestController : Controller
    {
        private readonly AppDbContext _DbContext;
        public TestController(AppDbContext appDbContext)
        {
            _DbContext = appDbContext;
        }

        [HttpGet("test")]
        public IActionResult GetTestData()
        {
            var data = new { message = "successfull api call" };
            return Ok(data);
        }

        [HttpGet("sqltest")]
        public async Task<List<Employee>> GetTestDataFromSqlServer()
        {
            var data = await _DbContext.Employees.ToListAsync();
            return data;
        }

        [HttpGet("sqltest2")]
        public async Task<List<FooBar>> GetTestDataFromSqlServer2()
        {
            var data = await _DbContext.FooBars.ToListAsync();
            return data;
        }
    }
}
