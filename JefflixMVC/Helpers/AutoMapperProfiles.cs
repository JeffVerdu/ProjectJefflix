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
            CreateMap<Serie, SerieDTO>().ForMember(dest => dest.Categoria,opt => opt.MapFrom(x => x.Categoria.Name));
            CreateMap<SerieCreacionDTO, Serie>();
            CreateMap<Serie,SerieCreacionDTO>();
            CreateMap<SerieEdicionDTO, Serie>();
            CreateMap<Serie, SerieEdicionDTO>();
            CreateMap<SerieDTO, Serie>();
            CreateMap<Serie, SerieParaMostrarDTO>();
        }
    }
}
