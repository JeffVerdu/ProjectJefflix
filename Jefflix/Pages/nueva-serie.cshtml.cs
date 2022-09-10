using Jefflix.DTO;
using Jefflix.NEGOCIO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Jefflix.Pages
{
    public class nueva_serieModel : PageModel
    {
        private readonly ISeriesNegocio _seriesNegocio;

        public SelectList CategoriasLista { get; set; }
        [BindProperty]
        public SerieParaGuardarDTO Serie { get; set; }
        public nueva_serieModel(ISeriesNegocio seriesNegocio)
        {
            _seriesNegocio = seriesNegocio;
        }
        public void OnGet()
        {
            CategoriasLista = _seriesNegocio.ObtenerCategoriasLista();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _seriesNegocio.crearSerie(Serie);
                return RedirectToPage("./series");
            }
            else
            {
                CategoriasLista = _seriesNegocio.ObtenerCategoriasLista();
                return Page();
            }

        }
    }
}
