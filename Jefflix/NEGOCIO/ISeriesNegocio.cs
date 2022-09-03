using Jefflix.DATOS.Entidades;
using Jefflix.DTO;

namespace Jefflix.NEGOCIO
{
    public interface ISeriesNegocio
    {
        List<SeriesDTO> ObtenerSeries();
    }
}
