namespace API.Database.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageData { get; set; }
        public string? RecipeLink { get; set; }
        public DateTime TimeCreated { get; set; }
        public int Rating { get; set; }
    }
}
