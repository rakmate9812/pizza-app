using System.ComponentModel.DataAnnotations;

namespace API.Database.DTOs
{
    public class PizzaDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
        public string RecipeLink { get; set; }
        public DateTime TimeCreated { get; set; }

        [Required]
        public int Rating { get; set; }
    }
}
