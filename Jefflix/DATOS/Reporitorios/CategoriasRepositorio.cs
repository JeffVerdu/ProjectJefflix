using Jefflix.DATOS.Entidades;
using Microsoft.Data.SqlClient;

namespace Jefflix.DATOS.Reporitorios
{
    public class CategoriasRepositorio : ICategoriasRepositorio
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
            using SqlCommand cmd = new SqlCommand("sp_obtener_categorias", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            sql.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Categorias categoria = new Categorias { Id = (int)reader["Id"], Nombre = reader["Nombre"].ToString() };
                    listaCategorias.Add(categoria);
                }
            }

            return listaCategorias;
        }

        public void crearCategoria(Categorias categoria)
        {
            using SqlConnection sql = new SqlConnection(_configuration.GetConnectionString("defaultConnection"));
            using SqlCommand cmd = new SqlCommand("sp_insertar_categoria", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nombre",categoria.Nombre));
            sql.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
