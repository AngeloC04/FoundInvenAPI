using ConInventario.Modelo;
using System.Data;
using System.Data.SqlClient;

namespace ConInventario.Repositorio
{
    public class InventarioSQLServer : IInventarioM
    {
        private string CadenaConexion;
        public InventarioSQLServer(AccesDate cadenaConexion) 
        {
            CadenaConexion = cadenaConexion.CadenaConexionSQL;
        }

        private SqlConnection conexion()
        {
            return new SqlConnection(CadenaConexion);
        }

        //    public IEnumerable<Inventario> ConsultaSKU()
        //    {
        //       throw new NotImplementedException();
        //    }

        public IEnumerable<Inventario> ConsultaSKU()
        {
            SqlConnection sqlConectar = conexion();
            SqlCommand com = null;
            List<Inventario> lista = new List<Inventario>();
            Inventario i = null;
            try
            {
                sqlConectar.Open();
                com = sqlConectar.CreateCommand();
                com.CommandText = "dbo.consulta_inv";
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    i = new Inventario
                    {
                        SKU = reader["SKU"].ToString(),
                        Bodega = reader["Bodega"].ToString(),
                        DispoNeto = Convert.ToDouble(reader["DispoNeto"].ToString()),
                        InvCompro = Convert.ToDouble(reader["InvCompro"].ToString()),
                        UniPorUbica = Convert.ToDouble(reader["UniPorUbica"].ToString())
                    };

                    lista.Add(i);

                }
            }
            catch (Exception msj)
            {
                throw new Exception("" + msj.ToString());
            }
            finally
            {
                com.Dispose();
                sqlConectar.Close();
                sqlConectar.Dispose();
            }
            return lista;

        }

        public Inventario ConsultaSKUx(string SKU)
        {
            SqlConnection sqlConectar = conexion();
            SqlCommand com = null;
            Inventario i = null;

            try
            {
                sqlConectar.Open(); 
                com = sqlConectar.CreateCommand();
                com.CommandText = "dbo.consulta_inv";
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add("@SKU", SqlDbType.VarChar,100).Value = SKU;
                SqlDataReader reader = com.ExecuteReader();

                if (reader.Read())
                {
                    i = new Inventario
                    {
                        SKU = reader["SKU"].ToString(),
                        Bodega = reader["Bodega"].ToString(),
                        DispoNeto = Convert.ToDouble(reader["DispoNeto"].ToString()),
                        InvCompro = Convert.ToDouble(reader["InvCompro"].ToString()),
                        UniPorUbica = Convert.ToDouble(reader["UniPorUbica"].ToString())
                    };
    }

            }
            catch (Exception msj)
            {
                throw new Exception("" + msj.ToString());
            }
            finally {
                com.Dispose();
                sqlConectar.Close();
                sqlConectar.Dispose();
            }
            return i;
        }


    }
}
