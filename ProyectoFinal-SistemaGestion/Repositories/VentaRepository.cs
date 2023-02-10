using ProyectoFinal_SistemaGestion.Models;
using System.Data.SqlClient;

namespace ProyectoFinal_SistemaGestion.Repositories
{
    public class VentaRepository
    {
        private static string connectionString = "Data Source=MARCO\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Venta> GetVentas()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand comando = new SqlCommand("SELECT * FROM Venta", connection);

                    var listaventas = new List<Venta>();

                    connection.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var venta = new Venta()
                            {
                                Id = reader.GetInt64(0),
                                Comentarios = reader.GetString(1),
                                IdUsuario = reader.GetInt64(2)
                            };

                            listaventas.Add(venta);
                        }
                    }

                    return listaventas;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                };
            }
        }

        public static List<Venta> GetVentas(long IdUsuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand comando = new SqlCommand("SELECT * FROM Venta WHERE IdUsuario = @id", connection);
                    SqlParameter param = new SqlParameter("id", IdUsuario);
                    comando.Parameters.Add(param);

                    var listaventas = new List<Venta>();

                    connection.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var venta = new Venta()
                            {
                                Id = reader.GetInt64(0),
                                Comentarios = reader.GetString(1),
                                IdUsuario = reader.GetInt64(2)
                            };

                            listaventas.Add(venta);
                        }
                    }

                    return listaventas;

                }
                catch (Exception ex) { throw new Exception(ex.Message); };
            }
        }

        public static long CreateVenta(Venta venta)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Venta (Comentarios, IdUsuario) VALUES (@Comentarios, @IdUsuario); SELECT @@IDENTITY ", connection);
                    var comentarios = new SqlParameter("Comentarios", venta.Comentarios);
                    var idUsuario = new SqlParameter("IdUsuario", venta.IdUsuario);
                    cmd.Parameters.Add(comentarios);
                    cmd.Parameters.Add(idUsuario);

                    connection.Open();
                    return Convert.ToInt64(cmd.ExecuteScalar());

                }
                catch (Exception ex) { throw new Exception(ex.Message); };
            }
        }

        public static int CargarVenta(long idUsuario, List<Producto> productosVendido)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    long numeroVenta = CreateVenta(new Venta()
                    {
                        IdUsuario = idUsuario,
                        Comentarios = ""
                    });

                    foreach (var item in productosVendido)
                    {
                        SqlCommand cmd = new SqlCommand(" INSERT INTO ProductoVendido (Stock, IdProducto,IdVenta) VALUES (@Stock,@IdProducto,@IdVenta)", connection);
                        var stock = new SqlParameter("Stock", item.Stock);
                        var idProducto = new SqlParameter("IdProducto", item.Id);
                        var idVenta = new SqlParameter("IdVenta", numeroVenta);

                        cmd.Parameters.Add(stock);
                        cmd.Parameters.Add(idProducto);
                        cmd.Parameters.Add(idVenta);


                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        ProductoRepository.UpdateStock(item.Id, item.Stock);
                        
                    }

                    return 1;
                }
                catch (Exception ex)
                {
                    throw new Exception();
                };
            }
        }

        public static int UpdateVenta(Venta venta)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Venta SET Comentarios = @Comentarios, IdUsuario = @IdUsuario WHERE Id = @Id", connection);
                    var comentarios = new SqlParameter("Comentarios", venta.Comentarios);
                    var idUsuario = new SqlParameter("IdUsuario", venta.IdUsuario);
                    var id = new SqlParameter("id", venta.Id);

                    cmd.Parameters.Add(comentarios);
                    cmd.Parameters.Add(idUsuario);
                    cmd.Parameters.Add(id);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    return 1;

                }
                catch (Exception ex) { throw new Exception(ex.Message); };
            }
        }

        public static int DeleteVenta(long id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Venta WHERE Id=@id", connection);
                    var ventaId = new SqlParameter("id", id);
                    cmd.Parameters.Add(ventaId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    return 1;

                }
                catch (Exception ex) { throw new Exception(ex.Message); };

            }
        }
    }
}
