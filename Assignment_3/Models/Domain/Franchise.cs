using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Models
{
    public class Franchise
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        //Relationship
        public ICollection<Movie> Movies { get; set; }
    }
}
