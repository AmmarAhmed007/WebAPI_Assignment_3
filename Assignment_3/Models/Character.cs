using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Models
{
    public class Character
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
