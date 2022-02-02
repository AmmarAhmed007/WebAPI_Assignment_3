using System.Collections.Generic;

namespace Assignment_3.Models.DTO.Franchise
{
    public class FranchiseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<int> Movies { get; set; }
    }
}
