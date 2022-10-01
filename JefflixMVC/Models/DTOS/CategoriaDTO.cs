using System.ComponentModel.DataAnnotations;

namespace JefflixMVC.Models.DTOS
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
