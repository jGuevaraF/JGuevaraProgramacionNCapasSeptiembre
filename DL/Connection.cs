using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Connection
    {
        public static string GetConnection()
        {
            string conexion = ConfigurationManager.ConnectionStrings["JGuevaraPrimerosComandos"].ToString();
            //string conexion = ConfigurationManager.ConnectionStrings["JGuevaraPrimerosComandos"].ConnectionString;

            return conexion;
        }
    }
}
