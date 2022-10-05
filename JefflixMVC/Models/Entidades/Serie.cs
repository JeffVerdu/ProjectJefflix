using System.ComponentModel.DataAnnotations;

namespace JefflixMVC.Models.Entidades
{
    public class Serie
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [MaxLength(50)]
        public string? Nombre { get; set; }
        public string? Portada { get; set; }
        [MaxLength(50)]
        public string? Director { get; set; }
        [MaxLength(50)]
        public string? PaisOrigen { get; set; }
        public int? Temporadas { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Activo { get; set; }
        public int? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        
    }
}
