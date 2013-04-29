
using System;
using System.DirectoryServices;
using GRW.Integrador.DAO;
using GRW.Integrador.Modelo.Entidades;

namespace GRW.Integrador.Modelo.Negocio
{
    public class ManejoDeUsuarios
    {
        public bool ConsultaCredencialesDeUsuario(string nombreUsuario, string password, bool esAdministrador)
        {
            bool passwordIguales = false;

            if (esAdministrador)
            {
                //PARA EL CASO DE USAR PASS DE HASH
                string passwordBaseDatos = "GJr8VHt24t4S21o5yhkNJEE3vhZ986ce";  //Hasheo de: Passw0rd

                //comparando claves hasheadas
                Hasheador hasheo = new Hasheador();
                passwordIguales = hasheo.ComparaHash(password, passwordBaseDatos);

                if (nombreUsuario != "Admin")
                    passwordIguales = false;
            }
            else
            {
                //PARA AUTENTICACIÓN CON ACTIVE DIRECTORY
                try
                {
                    string[] dominioUsuario = nombreUsuario.Split('\\');

                    if (dominioUsuario.Length != 2)
                    {
                        throw new Exception("Debe poner un dominio válido");
                    }
                    else
                    {
                        DirectoryEntry entry = new DirectoryEntry("LDAP://" + dominioUsuario[0],
                                                              dominioUsuario[1], password);
                        object nativeObject = entry.NativeObject;
                        passwordIguales = true;
                    }
                    
                }
                catch (DirectoryServicesCOMException ex)
                {
                    throw new Exception(ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return passwordIguales;
        }

        public UsuarioEntidad ConsultaPermisosUsuario(string nombreUsuario)
        {
            try
            {
                UsuarioEntidad usuarioPermisos;
                DAOUsuarios infoUsuarios = new DAOUsuarios();
                usuarioPermisos = infoUsuarios.ConsultaPermisosUsuario(nombreUsuario);

                return usuarioPermisos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
