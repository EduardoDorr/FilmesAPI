using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Domain.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<UpdateSessaoDto, Sessao>();
            CreateMap<Sessao, UpdateSessaoDto>();
            CreateMap<Sessao, ReadSessaoDto>();
        }
    }
}
