using System.ComponentModel.DataAnnotations;

namespace Jefflix.DTO
{
    public class SerieParaEditarDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }
        public int? Temporadas { get; set; }
        public string? Director { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string? PaisOrigen { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una Categoria")]
        public int IdCategoria { get; set; }
        public string? Portada { get; set; }
        public string Categoria { get; set; }
    }
}
