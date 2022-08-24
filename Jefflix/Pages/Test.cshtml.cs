using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jefflix.Pages
{
    public class TestModel : PageModel
    {
        [BindProperty]
        public int Numero1 { get; set; }
        [BindProperty]
        public int Numero2 { get; set; }
        public void OnGet()
        {
            this.Numero1 = 123;
            this.Numero2 = 321;
        }
    }
}
