
using GRW.Integrador.Modelo.Entidades;

namespace GRW.Integrador.Modelo.Negocio
{
    public class ManejoDeUsuarios
    {
        public bool ConsultaUsuario(string nombreUsuario, string password)
        {
            //TODO: abre conexion con base de datos


            //TODO: consulta que el usuario exista y devuelve la entidad de usuario
            string passwordBaseDatos = "GJr8VHt24t4S21o5yhkNJEE3vhZ986ce";  //Hasheo de: Passw0rd

            //comparando claves hasheadas
            Hasheador hasheo = new Hasheador();
            bool passwordIguales = hasheo.ComparaHash(password, passwordBaseDatos);

            //TODO: cierra conexión con base de datos

            return passwordIguales;
        }

        public UsuarioEntidad ConsultaPermisosUsuario(string nombreUsuario)
        {
            //TODO: abre conexion con base de datos

            //TODO:Consulta permisos de usuario en base de datos
            UsuarioEntidad usuarioPermisos = new UsuarioEntidad();
            //usuarioPermisos.AllowAutoConf = 
            //usuarioPermisos.AllowAccount =

            //TODO: cierra conexión con base de datos

            return usuarioPermisos;
        }
    }
}
