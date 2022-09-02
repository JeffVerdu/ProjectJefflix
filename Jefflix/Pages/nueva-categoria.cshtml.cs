using Jefflix.DTO;
using Jefflix.NEGOCIO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Jefflix.Pages
{
    public class nueva_categoriaModel : PageModel
    {
        private readonly ICategoriaNegocio _categoriaNegocio;

        [BindProperty]
        [Required(ErrorMessage ="El campo nombre es requerido")]
        public string _Nombre { get; set; }
        public nueva_categoriaModel(ICategoriaNegocio categoriaNegocio)
        {
            _categoriaNegocio = categoriaNegocio;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var categoriaDTO = new CategoriaDTO { Nombre = _Nombre };
                _categoriaNegocio.crearCategoria(categoriaDTO);
                return RedirectToPage("./Categorias");
            }
            else
                return Page();
        }
    }
}
