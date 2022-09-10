using Jefflix.DATOS.Entidades;

namespace Jefflix.DATOS.Reporitorios
{
    public interface ISeriesRepositorio
    {
        void crearSerie(Series serie);
        List<Series> ObtenerTodas();
    }
}
