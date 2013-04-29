using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRW.Integrador.DAO
{
    public class Auxiliares
    {
        public static int ArreglaVariablePermisos(object variableReader)
        {
            int variableArreglada = 0;

            if (!String.IsNullOrEmpty(Convert.ToString(variableReader)))
                variableArreglada = Convert.ToInt32(variableReader);
            else
                variableArreglada = 0;

            return variableArreglada;
        }
    }
}
