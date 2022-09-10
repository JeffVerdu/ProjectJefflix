using Jefflix.DATOS.Entidades;

namespace Jefflix.DATOS.Reporitorios
{
    public interface ISeriesRepositorio
    {
        void crearSerie(Series serie);
        void editarSerie(Series serie);
        Series obtenerSerieId(int id);
        List<Series> ObtenerTodas();
    }
}
