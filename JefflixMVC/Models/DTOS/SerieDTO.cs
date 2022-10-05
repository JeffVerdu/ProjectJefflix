namespace JefflixMVC.Models.DTOS
{
    public class SerieDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? Temporadas { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Categoria { get; set; }
    }
}
