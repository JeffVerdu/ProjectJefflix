using Jefflix.NEGOCIO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Text;

namespace Jefflix.Pages
{
    public class TestModel : PageModel
    {
        private readonly ICalculo _calculo;
        public TestModel(ICalculo calculo)
        {
            _calculo = calculo;
        }
        [BindProperty]
        public int Numero1 { get; set; }
        [BindProperty]
        public int Numero2 { get; set; }
        [BindProperty]
        public int Resultado { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            this.Resultado = _calculo.Operacion(this.Numero1, this.Numero2);
        }
    }
}
