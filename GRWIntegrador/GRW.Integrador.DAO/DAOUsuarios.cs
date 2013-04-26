using System.Configuration;
using System.Data.SqlClient;
using GRW.Integrador.Modelo.Entidades;

namespace GRW.Integrador.DAO
{
    public class DAOUsuarios
    {
        private string _cadenaDeConexion;

        public string CadenaDeConexion
        {
            get
            {
                if (_cadenaDeConexion == null)
                    _cadenaDeConexion = ConfigurationManager.ConnectionStrings["BAseDeDatosIntegrador"].ConnectionString;
                return _cadenaDeConexion;
            }
            set { _cadenaDeConexion = value; }
        }

        public void AgregarUsuario(UsuarioEntidad usuario)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaDeConexion))
            {
                
            }
        }
    }
}
