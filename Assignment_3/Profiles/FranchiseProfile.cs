using Assignment_3.Models;
using Assignment_3.Models.DTO.Franchise;
using AutoMapper;
using System.Linq;

namespace Assignment_3.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            //Map from Franchise to ReadFranchiseDTO
            CreateMap<Franchise, ReadFranchiseDTO>()
                .ForMember(fdto => fdto.Movies, option => option
                .MapFrom(f => f.Movies.Select(m => m.Id).ToArray()));
                
            //Map from FranchiseDTO to Franchise
            CreateMap<FranchiseDTO, Franchise>()
                .ReverseMap();
        }
    }
}
