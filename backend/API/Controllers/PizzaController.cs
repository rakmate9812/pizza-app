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
        public List<Pizza> GetAll()
        {
            var data = _context.Pizzas.ToList();
            return data;
        }

        //[Authorize]
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
