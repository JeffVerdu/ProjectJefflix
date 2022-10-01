using System.ComponentModel.DataAnnotations;

namespace JefflixMVC.Models.DTOS
{
    public class CategoriaCreacionDTO
    {
        [Required(ErrorMessage = "El campo nombre es requerido")]
        public string Name { get; set; }
    }
}
