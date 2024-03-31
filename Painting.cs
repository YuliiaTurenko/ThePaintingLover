using System;
using System.Collections.Generic;

namespace ThePaintingLoverApplication.Models
{
    public class Painting
    {
        public string Title { get; set; }
        public Artist Artist { get; set; }
        public Style PaintingStyle { get; set; }
        public string CreationYear { get; set; }
    }
}
