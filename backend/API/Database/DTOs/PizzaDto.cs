using System.ComponentModel.DataAnnotations;

namespace API.Database.DTOs
{
    public class PizzaDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
