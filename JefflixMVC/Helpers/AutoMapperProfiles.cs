using AutoMapper;
using JefflixMVC.Models.DTOS;
using JefflixMVC.Models.Entidades;

namespace JefflixMVC.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<CategoriaCreacionDTO, Categoria>();
            CreateMap<Categoria, CategoriaEdicionDTO>();
            CreateMap<CategoriaEdicionDTO, Categoria>();
            CreateMap<Serie, SerieDTO>();
            CreateMap<SerieCreacionDTO, Serie>();
        }
    }
}
