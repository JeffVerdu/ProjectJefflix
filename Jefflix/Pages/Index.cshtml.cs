using Jefflix.DTO;
using Jefflix.NEGOCIO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jefflix.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ISeriesNegocio _seriesNegocio;

        public IndexModel(ILogger<IndexModel> logger, ISeriesNegocio seriesNegocio)
        {
            _logger = logger;
            _seriesNegocio = seriesNegocio;
        }
        public List<SerieParaMostrarDTO> Series { get; set; }
        public void OnGet()
        {
            Series = _seriesNegocio.ObtenerSeriesIndex();
        }
    }
}