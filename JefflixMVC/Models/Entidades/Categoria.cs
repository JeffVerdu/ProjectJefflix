using System.ComponentModel.DataAnnotations;

namespace JefflixMVC.Models.Entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
