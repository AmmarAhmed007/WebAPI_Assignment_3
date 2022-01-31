using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string FullName { get; set; }
        [MaxLength(30)]
        public string Alias { get; set; }
        [MaxLength(6)]
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }
        //Relationship
        //public int MovieId { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
