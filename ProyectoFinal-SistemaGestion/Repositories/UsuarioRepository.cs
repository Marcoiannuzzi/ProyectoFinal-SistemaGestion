using ProyectoFinal_SistemaGestion.Models;
using System.Data.SqlClient;

namespace ProyectoFinal_SistemaGestion.Repositories
{
    public class UsuarioRepository
    {

        private static string connectionString = "Data Source=MARCO\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Usuario> GetUsuarios()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand comando = new SqlCommand("SELECT * FROM Usuario", connection);
                    connection.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    List<Usuario> lista = new List<Usuario>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = new Usuario();
                            usuario.Id = reader.GetInt64(0);
                            usuario.Nombre = reader.GetString(1);
                            usuario.Apellido = reader.GetString(2);
                            usuario.NombreUsuario = reader.GetString(3);
                            usuario.Contraseña = reader.GetString(4);
                            usuario.Mail = reader.GetString(5);

                            lista.Add(usuario);
                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error al obtener los usuarios: " + ex.Message);
                    return null;
                }
            }
        }


        public static Usuario GetUsuario(long id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE Id = @id", connection);
                    var param = new SqlParameter("id", id);
                    comando.Parameters.Add(param);

                    connection.Open();

                    SqlDataReader reader = comando.ExecuteReader();
                    Usuario usuario = new Usuario();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            {
                                usuario.Id = reader.GetInt64(0);
                                usuario.Nombre = reader.GetString(1);
                                usuario.Apellido = reader.GetString(2);
                                usuario.NombreUsuario = reader.GetString(3);
                                usuario.Contraseña = reader.GetString(4);
                                usuario.Mail = reader.GetString(5);
                            };
                        }
                    }
                    return usuario;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocurrió un error al obtener el usuario: " + ex.Message);
                    return null;
                };

            }
        }

        public static Usuario GetUsuario(string nombreUsuario, string contrasena)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE NombreUsuario= @NombreUsuario AND Contraseña=@Contraseña", connection);
                    var param = new SqlParameter("NombreUsuario", nombreUsuario);
                    var param2 = new SqlParameter("Contraseña", contrasena);
                    comando.Parameters.Add(param);
                    comando.Parameters.Add(param2);

                    connection.Open();

                    SqlDataReader reader = comando.ExecuteReader();

                    Usuario usuario = new Usuario();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            {
                                usuario.Id = reader.GetInt64(0);
                                usuario.Nombre = reader.GetString(1);
                                usuario.Apellido = reader.GetString(2);
                                usuario.NombreUsuario = reader.GetString(3);
                                usuario.Contraseña = reader.GetString(4);
                                usuario.Mail = reader.GetString(5);
                            };
                        }
                    }
                    return usuario;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static int CreateUsuario(Usuario usuario)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Usuario (Nombre,Apellido,NombreUsuario,Contraseña,Mail) VALUES (@Nombre,@Apellido,@NombreUsuario,@Contraseña,@Mail)", connection);
                    var nombre = new SqlParameter("Nombre", usuario.Nombre);
                    var apellido = new SqlParameter("Apellido", usuario.Apellido);
                    var nombreUsuario = new SqlParameter("NombreUsuario", usuario.NombreUsuario);
                    var contraseña = new SqlParameter("Contraseña", usuario.Contraseña);
                    var mail = new SqlParameter("Mail", usuario.Mail);
                    cmd.Parameters.Add(nombre);
                    cmd.Parameters.Add(apellido);
                    cmd.Parameters.Add(nombreUsuario);
                    cmd.Parameters.Add(contraseña);
                    cmd.Parameters.Add(mail);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    return 1;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public static int UpdateUsuario(Usuario usuario)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Usuario SET Nombre=@Nombre, Apellido=@Apellido, NombreUsuario=@NombreUsuario, Contraseña=@Contraseña, Mail=@Mail WHERE Id=@Id", connection);
                    var nombre = new SqlParameter("Nombre", usuario.Nombre);
                    var apellido = new SqlParameter("Apellido", usuario.Apellido);
                    var nombreUsuario = new SqlParameter("NombreUsuario", usuario.NombreUsuario);
                    var contraseña = new SqlParameter("Contraseña", usuario.Contraseña);
                    var mail = new SqlParameter("Mail", usuario.Mail);
                    var idUsuario = new SqlParameter("Id", usuario.Id);
                    cmd.Parameters.Add(nombre);
                    cmd.Parameters.Add(apellido);
                    cmd.Parameters.Add(nombreUsuario);
                    cmd.Parameters.Add(contraseña);
                    cmd.Parameters.Add(mail);
                    cmd.Parameters.Add(idUsuario);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    return 1;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                };
            }
        }

        public static int DeleteUsuario(long id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Usuario WHERE Id = @Id", connection);
                    var idUsuario = new SqlParameter("Id", id);
                    cmd.Parameters.Add(idUsuario);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    return 1;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                };

            }
        }
    }
}
