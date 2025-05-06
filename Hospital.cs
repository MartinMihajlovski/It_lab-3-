namespace WebApplication8.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        // Линк до слика од болницата (опционално)
        public string ImageUrl { get; set; }
    }
}
