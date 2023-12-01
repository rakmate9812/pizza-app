using API.Database.DTOs;
using API.Database.Models;
using System.Linq;

namespace API.Repositories
{
    public class PizzaRepository
    {
        private readonly AppDbContext _context;

        public PizzaRepository(AppDbContext context)
        {
            _context = context;
        }


        public List<Pizza> GetAllSearchResult(string searchTerm)
        {
            var pizzas = _context.Pizzas.Where(p => p.Name.ToUpper().Contains(searchTerm.ToUpper()) || (p.Description != null && p.Description.ToUpper().Contains(searchTerm.ToUpper()))).ToList();
            return pizzas;

        }

        public PaginatedPizzaSearchResult GetPaginatedSearchResults(string? searchTerm, int pageNum, int pageSize)
        {
            var pizzas = new List<Pizza>();

            if (searchTerm == null || searchTerm.Length == 0)
            {
                pizzas = _context.Pizzas.ToList();
            }
            else
            {
                pizzas = _context.Pizzas
                    .Where(p => p.Name.ToUpper().Contains(searchTerm.ToUpper()) ||
                                (p.Description != null && p.Description.ToUpper().Contains(searchTerm.ToUpper())))
                    .ToList();
            }

            int totalResults = pizzas.Count;

            int itemsToSkip = (pageNum - 1) * pageSize;

            var paginatedPizzas = pizzas.Skip(itemsToSkip).Take(pageSize).ToList(); // Take the number of items based on the page size

            var result = new PaginatedPizzaSearchResult()
            {
                Total = totalResults,
                Items = paginatedPizzas
            };

            return result;
        }


    }
}
