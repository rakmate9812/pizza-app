using API.Database.Models;

namespace API.Database.DTOs
{
    public class PaginatedPizzaSearchResult
    {
        public int Total { get; set; }
        public List<Pizza>? Items { get; set; }
    }
}
