using System;
using System.Configuration;
using System.Data;
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
                    _cadenaDeConexion = ConfigurationManager.ConnectionStrings["BaseDeDatosIntegrador"].ConnectionString;
                return _cadenaDeConexion;
            }
            set { _cadenaDeConexion = value; }
        }

        public bool ConsultaCredencialesUsuario(string nombreUsuario, string password)
        {
            bool respuestaCredenciales = false;

            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaDeConexion))
                {
                    SqlCommand comando = conexion.CreateCommand();
                    comando.CommandText =
                        "SELECT Name, Password FROM xgcg_AccTransUser WHERE Name = '@nombre' AND Password = '@password'";
                    comando.Parameters.AddWithValue("@nombre", nombreUsuario);
                    comando.Parameters.AddWithValue("@password", password);
                    conexion.Open();
                    object credencial = comando.ExecuteScalar();

                    conexion.Close();
                }

                return respuestaCredenciales;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UsuarioEntidad ConsultaPermisosUsuario(string nombreUsuario)
        {
            UsuarioEntidad permisosUsuario = null; // = new UsuarioEntidad();
            
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaDeConexion))
                {

                    SqlCommand comando = conexion.CreateCommand();
                    comando.CommandText = "xsp_ValidateLogin";
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Name", nombreUsuario);

                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        permisosUsuario = new UsuarioEntidad();
                        //Del storeProcedure los campos viene en este orden:
                        //[Password], AllowDBChange, AllowAutoConf, AllowUserAdmin, AllowInterfaces, 
                        //AllowInvControl, AllowAccount, AllowCostCenter, AllowJournal, AllowFileRead, 
                        //AllowDiscReport, AllowReprocess
                        permisosUsuario.Nombre = System.Threading.Thread.CurrentPrincipal.Identity.Name;
                        permisosUsuario.AllowDbChanges =  Auxiliares.ArreglaVariablePermisos(reader[1]);
                        permisosUsuario.AllowAutoConf = Auxiliares.ArreglaVariablePermisos(reader[2]);
                        permisosUsuario.AllowUserAdmin = Auxiliares.ArreglaVariablePermisos(reader[3]);
                        permisosUsuario.AllowInterface = Auxiliares.ArreglaVariablePermisos(reader[4]);
                        permisosUsuario.AllowInvControl = Auxiliares.ArreglaVariablePermisos(reader[5]);
                        permisosUsuario.AllowAccount = Auxiliares.ArreglaVariablePermisos(reader[6]);
                        permisosUsuario.AllowCostCenter = Auxiliares.ArreglaVariablePermisos(reader[7]);
                        permisosUsuario.AllowJournal = Auxiliares.ArreglaVariablePermisos(reader[8]);
                        permisosUsuario.AllowFileRead = Auxiliares.ArreglaVariablePermisos(reader[9]);
                        permisosUsuario.AllowDiscReport = Auxiliares.ArreglaVariablePermisos(reader[10]);
                        permisosUsuario.AllowReprocess = Auxiliares.ArreglaVariablePermisos(reader[11]);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return permisosUsuario;
        }

        public void AgregarUsuario(UsuarioEntidad usuario)
        {
            using (SqlConnection conexion = new SqlConnection(CadenaDeConexion))
            {
                SqlCommand comando = conexion.CreateCommand();
                comando.CommandText = "storeProcedure";
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@IdUsuario", usuario.Nombre);
                //...
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }
    }
}
