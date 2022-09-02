using Jefflix.DTO;
using Jefflix.NEGOCIO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jefflix.Pages
{
    public class eliminar_categoriaModel : PageModel
    {
        private readonly ICategoriaNegocio _categoriaNegocio;

        public eliminar_categoriaModel(ICategoriaNegocio categoriaNegocio)
        {
            _categoriaNegocio = categoriaNegocio;
        }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string Nombre { get; set; }
        public void OnGet(int id)
        {
            Id = Id;
            var categoriaDTO = _categoriaNegocio.ObtenerCategoriaId(id);
            Nombre = categoriaDTO.Nombre;
        }
        public IActionResult OnPost()
        {
            _categoriaNegocio.eliminarCategoria(Id);
            return RedirectToPage("./Categorias");
        }
    }
}
