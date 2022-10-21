using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    public static class PropiedadesGenerales
    {
        public static string Conexion
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ToString();
            }
        }
    }
}
