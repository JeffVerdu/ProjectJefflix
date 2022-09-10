using Jefflix.DATOS.Entidades;
using Jefflix.DATOS.Reporitorios;
using Jefflix.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jefflix.NEGOCIO
{
    public class SeriesNegocio : ISeriesNegocio
    {
        private readonly ISeriesRepositorio _seriesRepositorio;
private readonly ICategoriasRepositorio _categoriasRepositorio;

        public SeriesNegocio(ISeriesRepositorio seriesRepositorio, ICategoriasRepositorio categoriasRepositorio)
        {
            _seriesRepositorio = seriesRepositorio;
            _categoriasRepositorio = categoriasRepositorio;
        }

        public List<SeriesDTO> ObtenerSeries ()
        {
            var listaSeriesDTO = new List<SeriesDTO> ();
            var listaSeriesEntidades = _seriesRepositorio.ObtenerTodas();
            foreach (var serie in listaSeriesEntidades)
            {
                var serieDTO = new SeriesDTO {
                    Id = serie.Id,
                    Nombre = serie.Nombre,
                    Temporadas = serie.Temporadas == null ? null:(int)serie.Temporadas,
                    FechaCreacion = serie.FechaCreacion,
                    Categoria = serie.Categoria
                     
                };
                listaSeriesDTO.Add(serieDTO);
            }
            return listaSeriesDTO;
        }

        public SelectList ObtenerCategoriasLista()
        {
            var categorias = _categoriasRepositorio.ObtenerTodas();
            var listadoCategorias = new SelectList(categorias,"Id","Nombre");
            return listadoCategorias;
        }
        public void crearSerie(SerieParaGuardarDTO serieParaGuardarDTO)
        {
            var serie = new Series
            {
                Nombre = serieParaGuardarDTO.Nombre,
                Portada = serieParaGuardarDTO.Portada,
                Director = serieParaGuardarDTO.Director,
                PaisOrigen = serieParaGuardarDTO.PaisOrigen,
                Temporadas = serieParaGuardarDTO.Temporadas,
                FechaCreacion = serieParaGuardarDTO.FechaCreacion == null ? null: serieParaGuardarDTO.FechaCreacion,
                IdCategoria = serieParaGuardarDTO.IdCategoria
            };
            _seriesRepositorio.crearSerie(serie);
        }
    }
}
