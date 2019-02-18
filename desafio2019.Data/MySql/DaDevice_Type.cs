using Dapper;
using desafio2019.Entity.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio2019.Data.MySql
{
    public class DaDevice_Type
    {

        #region ConnectionString

        private string connectionStringMysql()
        {
            string cadena = string.Empty;
            ConexionDAO objDa = new ConexionDAO();

            cadena = objDa.CnxMySQL();
            return cadena;

        }

        #endregion ConnectionString


        public object CargaDevice_Type()
        {
            string cadena = String.Empty;
            try
            {
                cadena = " SELECT   ";
                cadena += "     rowid,  ";
                cadena += "     description  ";
                cadena += " FROM   ";
                cadena += "     Device_Type   ";

                using (MySqlConnection cn = new MySqlConnection(connectionStringMysql()))
                {
                    var resultado = cn.Query<EnDevice_Type>(cadena).ToList();

                    return resultado;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


       



    }
}
