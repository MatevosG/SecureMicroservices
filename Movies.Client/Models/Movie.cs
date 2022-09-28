﻿using System;

namespace Movies.Client.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public DateTime ReleaseData { get; set; }
        public string ImageUrl { get; set; }
        public string Owner { get; set; }
    }
}
