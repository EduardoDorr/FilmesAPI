﻿using AutoMapper;
using FilmesAPI.Models;
using FilmesAPI.Data.Dtos;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
        }
    }
}
