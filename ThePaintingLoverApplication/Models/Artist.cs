namespace ThePaintingLoverApplication.Models
{
    public class Artist
    {
        public required string Name { get; set; }
        public required string Country { get; set; }
        public required string Biography { get; set; }
        public required string YearsOfLife { get; set; }
        public List<Painting> Paintings { get; set; }
    }
}