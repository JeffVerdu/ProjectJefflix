using Jefflix.DTO;
using Jefflix.NEGOCIO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Jefflix.Pages
{
    public class editar_serieModel : PageModel
    {
        private readonly ISeriesNegocio _seriesNegocio;

        [BindProperty]
        public SerieParaEditarDTO Serie { get; set; }
        public SelectList CategoriasLista { get; set; }
        public editar_serieModel(ISeriesNegocio seriesNegocio)
        {
            _seriesNegocio = seriesNegocio;
        }
        public void OnGet(int id)
        {
            CategoriasLista = _seriesNegocio.ObtenerCategoriasLista();
            var serieParaEditarDTO = _seriesNegocio.ObtenerSerieId(id);
            Serie = serieParaEditarDTO;
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _seriesNegocio.editarSerie(Serie);
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
