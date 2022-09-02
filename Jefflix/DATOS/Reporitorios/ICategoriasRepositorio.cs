using Jefflix.DATOS.Entidades;

namespace Jefflix.DATOS.Reporitorios
{
    public interface ICategoriasRepositorio
    {
        List<Categorias> ObtenerTodas();
        void crearCategoria(Categorias categoria);
    }
}
