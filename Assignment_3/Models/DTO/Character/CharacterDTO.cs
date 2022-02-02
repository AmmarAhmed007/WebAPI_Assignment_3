using System.Collections.Generic;

namespace Assignment_3.Models.DTO.Character
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<int> Movies { get; set; }
    }
}
