using System.Collections.ObjectModel;

namespace ThePaintingLoverApplication.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Painting> FavoritePaintings { get; set; }
        public List<Note> Notes { get; set; }

        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
            FavoritePaintings = new List<Painting>();
            Notes = new List<Note>();
        }

        public bool IsFavoritePainting(Painting painting)
        {
            return FavoritePaintings.Any(p => p.Title == painting.Title);
        }
    }
}