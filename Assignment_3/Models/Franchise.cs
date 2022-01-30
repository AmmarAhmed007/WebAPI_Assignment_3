using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment_3.Models
{
    public class Franchise
    {
        [Key]
        public int FranchiseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
