namespace ThePaintingLoverApplication.Models
{
    public class Painting
    {
        public required string Title { get; set; }
        public required string ArtistName { get; set; }
        public required string CreationYear { get; set; }
        public required string FilePath { get; set; }
    }
}