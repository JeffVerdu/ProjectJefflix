using Jefflix.DTO;

namespace Jefflix.NEGOCIO
{
    public interface ICategoriaNegocio
    {
        List<CategoriaDTO> obtenerCategorias();
        void crearCategoria(CategoriaDTO categoria);
    }
}
