using Jefflix.DATOS.Entidades;
using Microsoft.Data.SqlClient;

namespace Jefflix.DATOS.Reporitorios
{
    public class SeriesRepositorio : ISeriesRepositorio
    {
        private readonly IConfiguration _configuration;

        public SeriesRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Series> ObtenerTodas()
        {
            var listaSeries = new List<Series>();
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("defaultConnection"));
            using SqlCommand cmd = new SqlCommand("sp_obtener_series", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Series serie = new Series 
                    { Id = (int)reader["Id"], 
                        Nombre = reader["Nombre"].ToString(),
                        Temporadas = (int)reader["Temporadas"], 
                        FechaCreacion = reader["FechaCreacion"] == DBNull.Value ? null : (DateTime)reader["FechaCreacion"],
                        Categoria = reader["Categoria"].ToString() };
                    listaSeries.Add(serie);
                }
            }

            return listaSeries;
        }
    }
}
