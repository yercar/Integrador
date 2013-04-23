using System;
using System.Text;
using System.Security.Cryptography;

namespace GRW.Integrador.Modelo.Negocio
{
    public class Hasheador
    {
        //definiendo la sal
        const int cantidadDeSal = 4;

        public string GeneraHashNuevo(string _passUsuario)
        {
            //Generador de número aleatorios
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] salero = new byte[cantidadDeSal];

            //Genera números aleatorios diferentes de cero y los pone en el arreglo
            rng.GetNonZeroBytes(salero);

            //Convertir el password del usuario a un arreglo de bytes
            byte[] bytesDeDatos = Encoding.UTF8.GetBytes(_passUsuario);

            //Generar otro arreglo para guardar los datos mas la sal
            byte[] datosSalados = new byte[salero.Length + bytesDeDatos.Length];

            //Copiar la sal a datosSalados
            Array.Copy(salero, 0, datosSalados, 0, salero.Length);

            //Copair los datos leidos a datos salados
            Array.Copy(bytesDeDatos, 0, datosSalados, salero.Length, bytesDeDatos.Length);

            //Crear instancia de herramienta de creación de hash
            SHA1CryptoServiceProvider csp = new SHA1CryptoServiceProvider();

            //Crear el hash
            byte[] bytesConHash = csp.ComputeHash(datosSalados);

            //crear el arreglo final del tamaño "total" + sal
            byte[] resultadoDeBytes = new byte[salero.Length + bytesConHash.Length];

            //copiar la sal al resultado
            Array.Copy(salero, 0, resultadoDeBytes, 0, salero.Length);

            //copiar los datos convertidos al resultado
            Array.Copy(bytesConHash, 0, resultadoDeBytes, salero.Length, bytesConHash.Length);

            return Convert.ToBase64String(resultadoDeBytes);
        }

        public bool ComparaHash(string _passUsuario, string _passBaseDatos)
        {
            bool passwordIguales = false;

            #region CrearHash
            //Extraer la sal
            byte[] claveSaladaConHashBytes = Convert.FromBase64String(_passBaseDatos);
            int sal = BitConverter.ToInt32(claveSaladaConHashBytes, 0); //Solo extrae los primeros 4 bytes

            //Extrae el Hash sin la sal
            byte[] claveHashBytes = new byte[claveSaladaConHashBytes.Length - cantidadDeSal];
            Array.Copy(claveSaladaConHashBytes, cantidadDeSal, claveHashBytes, 0, claveHashBytes.Length);

            //Combina la clave del usuario y la sal
            byte[] claveDelUsuarioBytes = Encoding.UTF8.GetBytes(_passUsuario);
            byte[] salero = BitConverter.GetBytes(sal);
            byte[] claveSaladaConBytes = new byte[salero.Length + claveDelUsuarioBytes.Length];
            Array.Copy(salero, 0, claveSaladaConBytes, 0, salero.Length);
            Array.Copy(claveDelUsuarioBytes, 0, claveSaladaConBytes, salero.Length, claveDelUsuarioBytes.Length);

            //Calcula el valor del hash
            SHA1CryptoServiceProvider csp = new SHA1CryptoServiceProvider();
            byte[] claveConHash = csp.ComputeHash(claveSaladaConBytes);
            #endregion CrearHash

            //Compara byte por byte para determinar si el password es el mismo
            for (int ixByte = 0; ixByte < claveHashBytes.Length; ixByte++)
            {
                if (claveConHash[ixByte] != claveHashBytes[ixByte])
                {
                    passwordIguales = false;
                    return passwordIguales;
                }
            }

            passwordIguales = true;

            return passwordIguales;
        }
    }
}
