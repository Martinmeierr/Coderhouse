using EjemploDeClase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_FINAL_C.Consultas
{
    public class VentaHandler : DbHandler
    {
        
        public List<Venta> GetVenta()
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM VENTA", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();

                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();
                                
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }

            return ventas;
        }
        public void Delete(Venta venta)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "DELETE FROM Venta WHERE Comentarios = @comentariosVenta";

                    SqlParameter parametro = new SqlParameter();
                    parametro.ParameterName = "ventaComentarios";
                    parametro.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametro.Value = venta.Id;

                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryDelete, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(parametro);
                        sqlCommand.ExecuteNonQuery(); // Se ejecuta el delete
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Insert(Venta venta)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[Venta] " +
                        "(Comentarios) VALUES " +
                        "('Hola');";

                    SqlParameter ComentariosParameter = new SqlParameter("Comentarios", SqlDbType.VarChar) { Value = venta.Comentarios };
                   


                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(ComentariosParameter);
                    

                        sqlCommand.ExecuteScalar(); // Se ejecuta la sentencia sql
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
