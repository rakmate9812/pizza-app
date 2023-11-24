using API.Database.DTOs;
using API.Database.Models;
using API.Migrations;
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

        [HttpGet("all")]
        public ActionResult<List<Pizza>> GetAll()
        {
            var data = _context.Pizzas.ToList();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var data = _context.Find<Pizza>(id);

            if (data == null) return NotFound("Pizza not found with the given identifier");

            return Ok(data);
        }

        [Authorize]
        [HttpPost("create")]
        public ActionResult<Pizza> Create([FromBody] PizzaDto request)
        {
            var pizza = new Pizza()
            {
                Name = request.Name,
                Description = request.Description,
                TimeCreated = DateTime.Now,
                ImageData = request.ImageData,
                RecipeLink = request.RecipeLink,
                Rating = request.Rating,
            };

            _context.Pizzas.Add(pizza);
            _context.SaveChanges();

            return Ok(pizza);
        }

    }
}
