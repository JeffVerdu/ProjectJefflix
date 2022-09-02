using Jefflix.DTO;
using Jefflix.NEGOCIO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jefflix.Pages
{
    public class CategoriasModel : PageModel
    {
        public List<CategoriaDTO> Categorias { get; set; }

        private readonly ICategoriaNegocio _categoriaNegocio;

        public CategoriasModel(ICategoriaNegocio categoriaNegocio)
        {
            _categoriaNegocio = categoriaNegocio;
        }
        
        public void OnGet()
        {
            Categorias = _categoriaNegocio.obtenerCategorias();

        }
    }
}
