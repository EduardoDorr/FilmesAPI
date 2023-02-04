using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Domain.Models;

namespace FilmesAPI.Domain.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            _ = CreateMap<CreateFilmeDto, Filme>();
            CreateMap<UpdateFilmeDto, Filme>();
            CreateMap<Filme, UpdateFilmeDto>();
            CreateMap<Filme, ReadFilmeDto>();
        }
    }
}
