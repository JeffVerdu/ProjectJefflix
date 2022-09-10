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
                        Temporadas = reader["Temporadas"] == DBNull.Value ? null : (int)reader["Temporadas"], 
                        FechaCreacion = reader["FechaCreacion"] == DBNull.Value ? null : (DateTime?)reader["FechaCreacion"],
                        Categoria = reader["Categoria"].ToString() };
                    listaSeries.Add(serie);
                }
            }

            return listaSeries;
        }

        public void crearSerie(Series serie)
        {
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("defaultConnection"));
            using SqlCommand cmd = new SqlCommand("sp_insertar_serie", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Nombre", serie.Nombre));
            cmd.Parameters.Add(new SqlParameter("@Temporadas", serie.Temporadas == null ? DBNull.Value: serie.Temporadas));
            cmd.Parameters.Add(new SqlParameter("@Director", serie.Director == null ? DBNull.Value : serie.Director));
            cmd.Parameters.Add(new SqlParameter("@FechaCreacion", serie.FechaCreacion == null ? DBNull.Value:serie.FechaCreacion));
            cmd.Parameters.Add(new SqlParameter("@PaisOrigen", serie.PaisOrigen == null ? DBNull.Value : serie.PaisOrigen));
            cmd.Parameters.Add(new SqlParameter("@CategoriaId", serie.IdCategoria));
            cmd.Parameters.Add(new SqlParameter("@Portada", serie.Portada == null ? DBNull.Value : serie.Portada));
            sql.Open();
            cmd.ExecuteNonQuery();
        }

    }
}
