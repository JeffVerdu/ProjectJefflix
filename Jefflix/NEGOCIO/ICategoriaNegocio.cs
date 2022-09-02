using Jefflix.DTO;

namespace Jefflix.NEGOCIO
{
    public interface ICategoriaNegocio
    {
        List<CategoriaDTO> obtenerCategorias();
        void crearCategoria(CategoriaDTO categoria);
        void editarCategoria(CategoriaDTO categoriaDTO);
        CategoriaDTO ObtenerCategoriaId(int id);
        void eliminarCategoria(int id);
    }
}
