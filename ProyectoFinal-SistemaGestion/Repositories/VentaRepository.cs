using ProyectoFinal_SistemaGestion.Models;
using System.Data.SqlClient;

namespace ProyectoFinal_SistemaGestion.Repositories
{
    public class VentaRepository
    {
        private static string connectionString = "Data Source=MARCO\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Venta> GetVentas(long IdUsuario)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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
        }

        public static void CreateVenta(Venta producto)
        {
            using (var connection = new SqlConnection(connectionString))
            {


            }
        }

        public static void UpdateVenta(int id, Venta producto)
        {
            using (var connection = new SqlConnection(connectionString))
            {


            }
        }

        public static void DeleteVenta(long id)
        {
            using (var connection = new SqlConnection(connectionString))
            {


            }
        }
    }
}
