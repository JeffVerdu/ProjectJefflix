using Jefflix.DATOS.Entidades;
using Jefflix.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jefflix.NEGOCIO
{
    public interface ISeriesNegocio
    {
        void crearSerie(SerieParaGuardarDTO serieParaGuardarDTO);
        void editarSerie(SerieParaEditarDTO serieParaEditarDTO);
        void eliminarSerie(int id);
        SelectList ObtenerCategoriasLista();
        SerieParaEditarDTO ObtenerSerieId(int id);
        List<SeriesDTO> ObtenerSeries();
        List<SerieParaMostrarDTO> ObtenerSeriesIndex();
    }
}
