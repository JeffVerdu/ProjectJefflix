using Jefflix.DATOS.Entidades;
using Jefflix.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jefflix.NEGOCIO
{
    public interface ISeriesNegocio
    {
        void crearSerie(SerieParaGuardarDTO serieParaGuardarDTO);
        SelectList ObtenerCategoriasLista();
        List<SeriesDTO> ObtenerSeries();
    }
}
