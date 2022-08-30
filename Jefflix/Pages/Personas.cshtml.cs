using Jefflix.NEGOCIO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Jefflix.Pages
{
    public class PersonasModel : PageModel
    {
        [BindProperty]
        public string saludo1 { get; set; }
        [BindProperty]
        public string saludo2 { get; set; }
        public void OnGet()
        {
            //Instanciamos objetos de la clase persona
            //2 formas de llenar los atributos del objeto si no declaro constructor de clase
            var persona1 = new Persona();
            persona1.Name = "Andrea";
            persona1.Height = 1.7f;
            persona1.Age = 25;
            persona1.Weight = 60f;
            var persona2 = new Persona { Name = "Ramon", Height = 1.5f, Age = 24, Weight = 50f };
            //Lenar atributos del objeto con constructor definido
            //var persona3 = new Persona("Maria",1.6f,22,57);
            var saludoPersona1 = persona1.Introduce();
            var saludoPersona2 = persona2.Introduce();
            saludo1 = saludoPersona1;
            saludo2 = saludoPersona2;
        }
    }
}
