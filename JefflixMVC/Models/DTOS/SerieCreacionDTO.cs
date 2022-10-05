using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace JefflixMVC.Models.DTOS
{
    public class SerieCreacionDTO
    {
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MaxLength(50)]
        public string? Nombre { get; set; }
        public string? Portada { get; set; }
        [MaxLength(50)]
        public string? Director { get; set; }
        [MaxLength(50)]
        public string? PaisOrigen { get; set; }
        public int? Temporadas { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public SelectList? CategoriasLista { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una categoria")]
        public int? CategoriaId { get; set; }
    }
}
