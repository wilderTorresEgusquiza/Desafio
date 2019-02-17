using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio2019.Data
{
    public class ConexionDAO
    {

        String strConexion = string.Empty;

        public String CnxMySQL()
        {

            strConexion = "Server = 40.79.22.145; Port = 3306; Database = gestion_test; Uid = testuser; Pwd = Exigo.2019123; SslMode = Preferred; ";
            return strConexion;

        }


    }
}
