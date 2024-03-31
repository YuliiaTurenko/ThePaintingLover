using System;
using System.Collections.Generic;

namespace ThePaintingLoverApplication.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Painting> FavoritePaintings { get; set; }

        public User()
        {
            FavoritePaintings = new List<Painting>();
        }

        public void Register(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
            Console.WriteLine("Registration is successful!");
        }

        public bool Login(string email, string password)
        {
            if (email == Email && password == Password)
            {
                Console.WriteLine("Welcome!");
                return true;
            }
            else if (email != Email && password == Password)
            {
                Console.WriteLine("Invalid email!");
                return false;
            }
            else
            {
                Console.WriteLine("Invalid password!");
                return false;
            }
        }

        public void AddToFavorites(Painting painting)
        {
            FavoritePaintings.Add(painting);
        }
    }
}
