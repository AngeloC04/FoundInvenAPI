namespace ConInventario.Repositorio
{
    public class AccesDate
    {
        private string cadenaConexionSQL;

        public string CadenaConexionSQL { get =>  cadenaConexionSQL;}

        public AccesDate(string ConexionSQL)
        {
            cadenaConexionSQL = ConexionSQL;
        }

    }
}
