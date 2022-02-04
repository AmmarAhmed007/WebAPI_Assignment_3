using Assignment_3.Models;
using Assignment_3.Models.DTO.Character;
using Assignment_3.Models.DTO.Movie;
using AutoMapper;
using System.Linq;

namespace Assignment_3.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            //Map from Character to ReadCharacterDTO
            CreateMap<Character, ReadCharacterDTO>()
                .ForMember(mdto => mdto.Movies, option => option
                .MapFrom(c => c.Movies.Select(m => m.Id).ToArray()));
            CreateMap<CharacterDTO, Character>();
            
        }
    }
}
