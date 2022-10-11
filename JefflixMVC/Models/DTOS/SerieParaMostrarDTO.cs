namespace JefflixMVC.Models.DTOS
{
    public class SerieParaMostrarDTO
    {
        public string? Nombre { get; set; }
        public string Portada { get; set; }
        public int? Temporadas { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Director { get; set; }
    }
}
