using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjemploDeClase;

namespace PROYECTO_FINAL_C.Consultas
{
    internal class ProductoVendidoHandler  : DbHandler
    {
        public List<ProductoVendido> GetProductoVendido()
        {
            List<ProductoVendido> ProductoVendido = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM PRODUCTOVENDIDO", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();

                                productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.IdVenta = Convert.ToInt32(dataReader["idVenta"]);
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["idProducto"]);

                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }

            return ProductoVendido;
        }
        public void Delete(ProductoVendido productoVendido)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    string queryDelete = "DELETE FROM ProductoVendido WHERE id = @idProductoVendido";

                    SqlParameter parametro = new SqlParameter();
                    parametro.ParameterName = "idProductoVendido";
                    parametro.SqlDbType = System.Data.SqlDbType.BigInt;
                    parametro.Value = productoVendido.Id;

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

        public void Insert(ProductoVendido productoVendido)
        {
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                    {
                        string queryInsert = "INSERT INTO [SistemaGestion].[dbo].[ProductoVendido] " +
                            "(Stock, IdProducto, IdVenta) VALUES " +
                            "(20,1, 5);";

                        SqlParameter stockParameter = new SqlParameter("Stock", SqlDbType.VarChar) { Value = productoVendido.Stock };
                        SqlParameter idProductoParameter = new SqlParameter("IdProducto", SqlDbType.VarChar) { Value = productoVendido.IdProducto };
                        SqlParameter idVentaParameter = new SqlParameter("IdVenta", SqlDbType.VarChar) { Value = productoVendido.IdVenta };
                        


                        sqlConnection.Open();

                        using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                        {
                            sqlCommand.Parameters.Add(stockParameter);
                            sqlCommand.Parameters.Add(idProductoParameter);
                            sqlCommand.Parameters.Add(idVentaParameter);
                            

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
}

    

