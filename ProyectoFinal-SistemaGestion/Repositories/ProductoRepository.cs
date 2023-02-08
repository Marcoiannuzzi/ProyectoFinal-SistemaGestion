using ProyectoFinal_SistemaGestion.Models;
using System.Data.SqlClient;

namespace ProyectoFinal_SistemaGestion.Repositories
{
    public class ProductoRepository
    {
        private static string connectionString = "Data Source=MARCO\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Producto> GetProductos()
        {

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto", connection);
                connection.Open();
                SqlDataReader reader = comando.ExecuteReader();

                List<Producto> list = new List<Producto>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto temporalProd = new Producto()
                        {
                            Id = reader.GetInt64(0),
                            Descripciones = reader.GetString(1),
                            Costo = reader.GetDecimal(2),
                            PrecioDeVenta = reader.GetDecimal(3),
                            Stock = reader.GetInt32(4),
                            IdUsuario = reader.GetInt64(5),
                        };
                        list.Add(temporalProd);
                    }
                }
                return list;
            }

        }

        public static List<Producto> GetProductosbyId(long idUsuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Producto WHERE IdUsuario = @id", connection);
                var param = new SqlParameter("id", idUsuario);
                comando.Parameters.Add(param);


                connection.Open();
                SqlDataReader reader = comando.ExecuteReader();


                List<Producto> list = new List<Producto>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Producto temporalProd = new Producto()
                        {
                            Id = reader.GetInt64(0),
                            Descripciones = reader.GetString(1),
                            Costo = reader.GetDecimal(2),
                            PrecioDeVenta = reader.GetDecimal(3),
                            Stock = reader.GetInt32(4),
                            IdUsuario = reader.GetInt64(5),
                        };
                        list.Add(temporalProd);
                    }
                }
                return list;
            }

        }

        public static void CreateProducto(Producto producto)
        {
            using (var connection = new SqlConnection(connectionString))
            {


            }
        }

        public static void UpdateProducto(int id, Producto producto)
        {
            using (var connection = new SqlConnection(connectionString))
            {


            }
        }

        public static void DeleteProducto(long id)
        {
            using (var connection = new SqlConnection(connectionString))
            {


            }
        }
    }
}
