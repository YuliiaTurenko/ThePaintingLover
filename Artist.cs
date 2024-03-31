using System;
using System.Collections.Generic;

namespace ThePaintingLoverApplication.Models
{
    public class Artist
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
        public string Country { get; set; }
        public string Biography { get; set; }
        public List<Painting> Paintings { get; set; }

        public void AddPainting(Painting painting)
        {
            Paintings.Add(painting);
        }
    }
}
