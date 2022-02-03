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
        // [Required]
        public string MovieTitle { get; set; }
        [MaxLength(25)]
        public string Genre { get; set; }
        [MaxLength(4)]
        public int ReleaseYear { get; set; }
        [MaxLength(50)]
        public string Director { get; set; }
        public string PhotoUrl { get; set; }
        public string YoutubeLink { get; set; }
        //Relationship
        public int? FranchiseId { get; set; }
        public ICollection<Character> Characters { get; set; }
        public Franchise Franchises { get; set; }


    }
}
