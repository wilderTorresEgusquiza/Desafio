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
    public class DaOperativeSystem
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


        public object CargaOperativeSystem()
        {
            string cadena = String.Empty;
            try
            {
                cadena = " SELECT   ";
                cadena += "     rowid,  ";
                cadena += "     description  ";
                cadena += " FROM   ";
                cadena += "     OperativeSystem_Type	   ";

                using (MySqlConnection cn = new MySqlConnection(connectionStringMysql()))
                {
                    var resultado = cn.Query<EnOperativeSystem>(cadena).ToList();

                    //var x = (from a in resultado
                    //         select new EnOrders.EnCustomers
                    //         {
                    //             OrdenID= a.OrdenID,
                    //             CustomerID=a.CustomerID
                    //         }
                    //).SingleOrDefault();

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
