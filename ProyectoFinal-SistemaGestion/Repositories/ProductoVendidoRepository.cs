using ProyectoFinal_SistemaGestion.Models;
using System.Data.SqlClient;

namespace ProyectoFinal_SistemaGestion.Repositories
{
    public class ProductoVendidoRepository
    {
        private static string connectionString = "Data Source=MARCO\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<ProductoVendido> GetProductosVendidos()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ProductoVendido", connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<ProductoVendido> listaProductos = new List<ProductoVendido>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var produtoVendido = new ProductoVendido()
                        {
                            Id = reader.GetInt64(0),
                            Stock = reader.GetInt32(1),
                            IdProducto = reader.GetInt64(2),
                            IdVenta = reader.GetInt64(3),
                        };

                        listaProductos.Add(produtoVendido);
                    }
                }
                return listaProductos;
            }
        }

        public static List<ProductoVendido> GetProductosVendidos(long IdVenta)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM ProductoVendido WHERE IdVenta = @id", connection);
                var param = new SqlParameter("id", IdVenta);
                cmd.Parameters.Add(param);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                List<ProductoVendido> listaProductos = new List<ProductoVendido>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var produtoVendido = new ProductoVendido()
                        {
                            Id = reader.GetInt64(0),
                            Stock = reader.GetInt32(1),
                            IdProducto = reader.GetInt64(2),
                            IdVenta = reader.GetInt64(3),
                        };

                        listaProductos.Add(produtoVendido);
                    }
                }
                return listaProductos;
            }

        }

    }
}
