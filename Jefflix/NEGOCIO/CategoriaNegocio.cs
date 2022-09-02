using Jefflix.DATOS.Entidades;
using Jefflix.DATOS.Reporitorios;
using Jefflix.DTO;
using Microsoft.AspNetCore.Components.Forms;

namespace Jefflix.NEGOCIO
{
    public class CategoriaNegocio : ICategoriaNegocio
    {
        private readonly ICategoriasRepositorio _categoriasRepositorio;
        public CategoriaNegocio(ICategoriasRepositorio categoriasRepositorio)
        {
            _categoriasRepositorio = categoriasRepositorio;
        }
        public List<CategoriaDTO> obtenerCategorias()
        {
            List<CategoriaDTO> listaCategoriasDTO = new List<CategoriaDTO>();
            var listaCategoriasEntidades = _categoriasRepositorio.ObtenerTodas();
            foreach (var categoria in listaCategoriasEntidades)
            {
                var categoriaDTO = new CategoriaDTO { Id=categoria.Id,Nombre=categoria.Nombre };
                listaCategoriasDTO.Add(categoriaDTO);
            }

            return listaCategoriasDTO;
        }
        public void crearCategoria(CategoriaDTO categoriaDTO)
        {
            var categoria = new Categorias { Id = categoriaDTO.Id, Nombre = categoriaDTO.Nombre};
            _categoriasRepositorio.crearCategoria(categoria);
        }
        public CategoriaDTO ObtenerCategoriaId(int id)
        {
            var categoria = _categoriasRepositorio.obtenerCategoriaId(id);
            CategoriaDTO categoriaDTO = new CategoriaDTO { Id = categoria.Id, Nombre = categoria.Nombre };
            return categoriaDTO;
        }
        public void editarCategoria(CategoriaDTO categoriaDTO)
        {
            var categoria = new Categorias { Id=categoriaDTO.Id, Nombre = categoriaDTO.Nombre };
            _categoriasRepositorio.editarCategoria(categoria);
        }
        public void eliminarCategoria(int id)
        {
            _categoriasRepositorio.eliminarCategoria(id);
        }
    }
}
