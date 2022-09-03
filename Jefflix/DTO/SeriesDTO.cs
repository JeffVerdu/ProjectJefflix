namespace Jefflix.DTO
{
    public class SeriesDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Portada { get; set; }
        public string Director { get; set; }
        public string PaisOrigen { get; set; }
        public int Temporadas { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
    }
}
