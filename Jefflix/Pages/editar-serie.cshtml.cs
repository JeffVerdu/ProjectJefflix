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
        [Required]
        public int Id { get; set; }
        [BindProperty]
        public SerieParaEditarDTO Serie { get; set; }
        public SelectList CategoriasLista { get; set; }
        public editar_serieModel(ISeriesNegocio seriesNegocio)
        {
            _seriesNegocio = seriesNegocio;
        }
        public void OnGet(int id)
        {
            Id = id;
            var serieParaEditarDTO = new SerieParaEditarDTO();
            serieParaEditarDTO = _seriesNegocio.ObtenerSerieId(id);
            Serie = serieParaEditarDTO;
            CategoriasLista = _seriesNegocio.ObtenerCategoriasLista();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

                var serieParaEditarDTO = new SerieParaEditarDTO ();
                serieParaEditarDTO = Serie;
                serieParaEditarDTO.Id = Id;
                _seriesNegocio.editarSerie(serieParaEditarDTO);
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
