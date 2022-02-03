﻿using Assignment_3.Models.DTO.Movie;
using AutoMapper;
using System.Linq;

namespace Assignment_3.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, ReadMovieDTO>()
                .ForMember(mdto => mdto.Characters, option => option
                .MapFrom(m => m.Characters.Select(c => c.Id).ToArray()))
                .ForMember(mdto => mdto.Franchise, option => option
                .MapFrom(c => c.FranchiseId))
                .ReverseMap();

            //Map from Movie to UpdateMovieDTO
            //CreateMap<Movie, UpdateMovieDTO>()
            //    .ForMember(mdto => mdto.Characters, option => option
            //    .MapFrom(m => m.Characters.Select(c => c.Id).ToArray()))
            //    .ForMember(mdto => mdto.Franchise, option => option
            //    .MapFrom(c => c.FranchiseId))
            //    .ReverseMap();

            //Map from CreateMovieDTO to Movie
            CreateMap<MovieDTO, Movie>()
                .ReverseMap();
        }
    }
}

