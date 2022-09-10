using Jefflix.DTO;
using Jefflix.NEGOCIO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Principal;

namespace Jefflix.Pages
{
    public class eliminar_serieModel : PageModel
    {
        private readonly ISeriesNegocio _seriesNegocio;

        public eliminar_serieModel(ISeriesNegocio seriesNegocio)
        {
            _seriesNegocio = seriesNegocio;
        }
        [BindProperty]
        public string Nombre { get; set; }
        [BindProperty]
        public int Id { get; set; }
        public void OnGet(int id)
        {
            var serie =_seriesNegocio.ObtenerSerieId(id);
            Id = serie.Id;
            Nombre = serie.Nombre;
        }
        public IActionResult OnPost()
        {
            _seriesNegocio.eliminarSerie(Id);
            return RedirectToPage("./series");
        }
    }
}
