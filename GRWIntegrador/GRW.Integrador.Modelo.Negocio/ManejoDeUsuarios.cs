
namespace GRW.Integrador.Modelo.Negocio
{
    public class ManejoDeUsuarios
    {
        public bool ConsultaUsuario(string _usuario, string _password)
        {
            //abre conexion con base de datos


            //TODO: consulta que el usuario exista y devuelve la entidad de usuario
            string passwordBaseDatos = "GJr8VHt24t4S21o5yhkNJEE3vhZ986ce";  //Hasheo de: Passw0rd

            //comparando claves hasheadas
            Hasheador hasheo = new Hasheador();
            bool passwordIguales = hasheo.ComparaHash(_password, passwordBaseDatos);

            //cierra conexión con base de datos

            return passwordIguales;
        }
    }
}
