using desafio2019.Entity.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio2019.Data.MySql
{
    public class DaUsuario
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

        public DataTable Usuarios_Listar(EnUsuario objEn)
        {
            string cadena = String.Empty;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {

                cadena = " SELECT   ";
                cadena += "     name,  ";
                cadena += "     Correo,  ";
                cadena += "     Clave";
                cadena += " FROM   ";
                cadena += "     Usuario   ";
                cadena += " WHERE   ";
                cadena += "      Clave = '" + objEn.Clave + "'  ";

                using (MySqlConnection cn = new MySqlConnection(connectionStringMysql()))
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cadena, cn))
                    {

                        da.Fill(ds, "Data");
                        dt = ds.Tables["Data"];

                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public void Usuarios_Insertar(EnUsuario objEn, MySqlTransaction tran)
        {

            string cadena = string.Empty;
            try
            {

                cadena = " INSERT INTO    Usuario    ";
                cadena += " (    ";
                cadena += "     Name,    ";
                cadena += "     Correo,    ";
                cadena += "     Clave    ";
                cadena += " )    ";
                cadena += "     VALUES    ";
                cadena += " (    ";
                cadena += "     '" + objEn.Name + "',    ";
                cadena += "     '" + objEn.Correo + "',    ";
                cadena += "     '" + objEn.Clave + "'    ";
                cadena += " )  ";

                using (MySqlCommand cmd = new MySqlCommand(cadena, tran.Connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = tran;

                    cmd.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
