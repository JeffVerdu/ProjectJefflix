using Jefflix.DATOS.Entidades;
using Jefflix.DTO;
using Jefflix.NEGOCIO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Core.Types;

namespace Jefflix.Pages
{
    public class seriesModel : PageModel
    {
        private readonly ISeriesNegocio _seriesNegocio;

        public List<SeriesDTO> Series { get; set; }

        public seriesModel(ISeriesNegocio seriesNegocio)
        {
            _seriesNegocio = seriesNegocio;
        }
        public void OnGet()
        {
            Series = _seriesNegocio.ObtenerSeries();
        }
    }
}
