using API.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("pizza")]
    public class PizzaController : Controller
    {
        private readonly AppDbContext _context;
        public PizzaController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [Authorize]
        [HttpGet("all")]
        public async Task<List<Pizza>> GetAllPizza()
        {
            var data = await _context.Pizzas.ToListAsync();
            return data;
        }

    }
}
