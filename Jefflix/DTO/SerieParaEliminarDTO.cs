using Microsoft.AspNetCore.Mvc;

namespace Jefflix.DTO
{
    public class SerieParaEliminarDTO
    {
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string Nombre { get; set; }
    }
}
