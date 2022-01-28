using Assignment_3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment_3
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MovieTitle { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string PhotoUrl { get; set; }
        public string YoutubeLink { get; set; }
        public ICollection<Character> Characters { get; set; }
        public Franchise Franchise { get; set; }


    }
}
