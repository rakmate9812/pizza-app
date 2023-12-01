using API.Database.DTOs;
using API.Database.Models;
using API.Migrations;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("pizza")]
    public class PizzaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly PizzaRepository _pizzaRepository;

        public PizzaController(AppDbContext appDbContext)
        {
            _context = appDbContext;
            _pizzaRepository = new PizzaRepository(appDbContext);
        }

        // Not used
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

            if (data == null) return NotFound("Pizza not found with the given id");

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

        [HttpPost("browse/{pageNum}")]
        public ActionResult<PaginatedPizzaSearchResult> GetPaginatedSearchResults([FromBody] PizzaSearchDto request, int pageNum)
        {

            var data = _pizzaRepository.GetPaginatedSearchResults(request.SearchTerm, pageNum, 4);

            if (data.Items == null || data.Items.Count == 0)
            {
                return NotFound("Pizza not found!");
            }

            return Ok(data);
        }

    }
}
