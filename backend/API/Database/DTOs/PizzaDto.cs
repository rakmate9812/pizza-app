using System.ComponentModel.DataAnnotations;

namespace API.Database.DTOs
{
    public class PizzaDto
    {
        // Data coming from the frontend
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageData { get; set; }
        public string? RecipeLink { get; set; }

        [Required]
        public int Rating { get; set; }
    }
}
