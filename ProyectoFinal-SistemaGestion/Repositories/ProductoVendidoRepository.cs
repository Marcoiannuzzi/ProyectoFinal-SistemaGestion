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

        public static void Create(ProductoVendido productoVendido)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO ProductoVendido (Stock, IdProducto, IdVenta) VALUES (@Stock, @IdProducto, @IdVenta)", connection);
                var stock = new SqlParameter("Stock", productoVendido.Stock);
                var idproducto = new SqlParameter("IdProducto", productoVendido.IdProducto);
                var idVenta = new SqlParameter("IdVenta", productoVendido.IdVenta);
                cmd.Parameters.Add(stock);
                cmd.Parameters.Add(idproducto);
                cmd.Parameters.Add(idVenta);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }


        }

        public static void Update(ProductoVendido productoVendido)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE ProductoVendido SET Stock = @Stock, IdProducto =@IdProducto, IdVenta=@IdVenta WHERE Id = @id", connection);
                var stock = new SqlParameter("Stock", productoVendido.Stock);
                var idproducto = new SqlParameter("IdProducto", productoVendido.IdProducto);
                var idVenta = new SqlParameter("IdVenta", productoVendido.IdVenta);
                var id = new SqlParameter("id", productoVendido.Id);
                cmd.Parameters.Add(stock);
                cmd.Parameters.Add(idproducto);
                cmd.Parameters.Add(idVenta);
                cmd.Parameters.Add(id);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }

        }

        public static void Delete (long id) 
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM ProductoVendido WHERE Id = @id", connection);
                var idProducto = new SqlParameter("id", id);
                cmd.Parameters.Add(idProducto);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }

        }

    }
}
