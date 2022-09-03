using Jefflix.DATOS.Entidades;
using Jefflix.DATOS.Reporitorios;
using Jefflix.DTO;

namespace Jefflix.NEGOCIO
{
    public class SeriesNegocio : ISeriesNegocio
    {
        private readonly ISeriesRepositorio _seriesRepositorio;

        public SeriesNegocio(ISeriesRepositorio seriesRepositorio)
        {
            _seriesRepositorio = seriesRepositorio;
        }

        public List<SeriesDTO> ObtenerSeries ()
        {
            var listaSeriesDTO = new List<SeriesDTO> ();
            var listaSeriesEntidades = _seriesRepositorio.ObtenerTodas();
            foreach (var serie in listaSeriesEntidades)
            {
                var serieDTO = new SeriesDTO { 
                    Id=serie.Id, 
                    Nombre=serie.Nombre,
                    Temporadas=serie.Temporadas,
                    Portada=serie.Portada, 
                    Director=serie.Director, 
                    PaisOrigen=serie.PaisOrigen,
                    FechaCreacion=serie.FechaCreacion,
                    IdCategoria=serie.IdCategoria,
                    Categoria=serie.Categoria,
                     
                };
                listaSeriesDTO.Add(serieDTO);
            }
            return listaSeriesDTO;
        }
    }
}
