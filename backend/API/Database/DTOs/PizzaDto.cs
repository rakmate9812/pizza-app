using System.ComponentModel.DataAnnotations;

namespace API.Database.DTOs
{
    public class PizzaDto
    {
        // The users sends this data transfer object from the front-end
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public byte[]? ImageData { get; set; }
        public string? RecipeLink { get; set; }

        [Required]
        public int Rating { get; set; }
    }
}
