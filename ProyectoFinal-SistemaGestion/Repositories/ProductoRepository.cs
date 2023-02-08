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
                try
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
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }

        public static List<Producto> GetProductosbyId(long idUsuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
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
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                };
            }

        }

        public static void CreateProducto(Producto producto)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Producto (Descripciones,Costo, PrecioVenta,Stock, IdUsuario) VALUES (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)", connection);
                    var descripciones = new SqlParameter("Descripciones", producto.Descripciones);
                    var costo = new SqlParameter("Costo", producto.Costo);
                    var precioVenta = new SqlParameter("PrecioVenta", producto.PrecioDeVenta);
                    var stock = new SqlParameter("Stock", producto.Stock);
                    var idUsuario = new SqlParameter("IdUsuario", producto.IdUsuario);
                    cmd.Parameters.Add(descripciones);
                    cmd.Parameters.Add(costo);
                    cmd.Parameters.Add(precioVenta);
                    cmd.Parameters.Add(stock);
                    cmd.Parameters.Add(idUsuario);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); };
            }
        }

        public static void UpdateProducto(Producto producto)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Producto SET Descripciones = @Descripciones,Costo = @Costo, PrecioVenta = @PrecioVenta,Stock = @Stock, IdUsuario = @IdUsuario WHERE Id =@id", connection);
                    var descripciones = new SqlParameter("Descripciones", producto.Descripciones);
                    var costo = new SqlParameter("Costo", producto.Costo);
                    var precioVenta = new SqlParameter("PrecioVenta", producto.PrecioDeVenta);
                    var stock = new SqlParameter("Stock", producto.Stock);
                    var idUsuario = new SqlParameter("IdUsuario", producto.IdUsuario);
                    var id = new SqlParameter("Id", producto.Id);
                    cmd.Parameters.Add(descripciones);
                    cmd.Parameters.Add(costo);
                    cmd.Parameters.Add(precioVenta);
                    cmd.Parameters.Add(stock);
                    cmd.Parameters.Add(idUsuario);
                    cmd.Parameters.Add(id);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); };

            }
        }

        public static void DeleteProducto(long id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Producto WHERE Id=@id", connection);
                    SqlParameter param = new SqlParameter("id", id);
                    cmd.Parameters.Add(param);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); };
            }
        }
    }
}
