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

            //strConexion = "Server = 104.248.211.185; Port = 3306; Database = desafio2019; Uid = desafioext; Pwd = aPdfKiFXyZSJS0ds; SslMode = Preferred; ";
            //strConexion = "Server = 104.248.211.185; Database = desafio2019; Uid = desafioext; Pwd = aPdfKiFXyZSJS0ds;";
            //strConexion = "Server = 104.248.211.185; Database = desafio2019; Uid = desafioext; Pwd = KqcdxsY4f999f0sI;";
            strConexion = "Server = 104.248.211.185; Database = desafio2019; Uid = desafioext; Pwd = KqcdxsY4f999f0sI;";
            return strConexion;

        }


    }
}
