using System.Collections.Generic;

namespace Assignment_3.Models.DTO.Franchise
{
    public class ReadFranchiseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> Movies { get; set; }
    }
}
