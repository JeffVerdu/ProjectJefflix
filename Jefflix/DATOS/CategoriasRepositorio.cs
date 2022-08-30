using Jefflix.NEGOCIO;
using Microsoft.Data.SqlClient;

namespace Jefflix.DATOS
{
    public class CategoriasRepositorio
    {
        private readonly IConfiguration _configuration;

        public CategoriasRepositorio(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<Categorias> ObtenerTodas()
        {
            var listaCategorias = new List<Categorias>();
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("defaultConnection"));
            using SqlCommand cmd = new SqlCommand("select * from Categorias",sql);
            sql.Open();
            using(var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Categorias categoria = new Categorias { Id = (int)reader["Id"], Nombre = reader["Nombre"].ToString() };
                    listaCategorias.Add(categoria);
                }
            }

            return listaCategorias;
        }
    }
}
