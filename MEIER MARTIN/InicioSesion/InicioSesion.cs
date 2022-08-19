using EjemploDeClase;
using MySql.Data.MySqlClient;
using PROYECTO_FINAL_C;
using System.Data;
using System.Data.SqlClient;

public class InicioSesion : DbHandler
{
    public List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
        using (SqlConnection sqlConnection = new SqlConnection(ConnectionString)) 
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer del inicio sesion 
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Usuario usuario = new Usuario();                                
                                usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();                              
                                usuario.Contraseña = dataReader["Contraseña"].ToString();
                                
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return usuarios;
        }
    }