using API.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("pizza")]
    public class PizzaController : Controller
    {
        private readonly AppDbContext _DbContext;
        public PizzaController(AppDbContext appDbContext)
        {
            _DbContext = appDbContext;
        }

        [HttpGet("all")]
        public async Task<List<Pizza>> GetAllPizza()
        {
            var data = await _DbContext.Pizzas.ToListAsync();
            return data;
        }

    }
}
