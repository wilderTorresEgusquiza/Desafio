using Dapper;
using desafio2019.Entity.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;

namespace desafio2019.Data.MySql
{
    public class DaDevices
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

        public object Devices_Lista()
        {
            string cadena = String.Empty;
            try
            {

                cadena = " SELECT   ";
                cadena += "     d.rowid,  ";
                cadena += "     d.ConnectionID,  ";
                cadena += "     c.description as Connection,  ";
                cadena += "     NameDevice,  ";
                cadena += "     d.DeviceID,  ";
                cadena += "     dt.description as Device,  ";
                cadena += "     d.SensorID,  ";
                cadena += "     s.description as Sensor,  ";
                cadena += "     d.OperSysID,  ";
                cadena += "     o.description as OperSystem  ";
                cadena += " FROM   ";
                cadena += "     Device  d    ";
                cadena += "     inner join Conecction_Type c   on      ";
                cadena += "         d.ConnectionID  =   c.rowid   ";
                cadena += "     inner join Device_Type dt   on      ";
                cadena += "         d.DeviceID  =   dt.rowid   ";
                cadena += "     inner join Sensor_Type s   on      ";
                cadena += "         d.SensorID  =   s.rowid   ";
                cadena += "     inner join OperativeSystem_Type o   on      ";
                cadena += "         d.OperSysID  =   o.rowid   ";

                using (MySqlConnection cn = new MySqlConnection(connectionStringMysql()))
                {
                    var resultado = cn.Query<EnDevices.EnDevicesTabla>(cadena).ToList();

                    return resultado;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Devices_Insertar(EnDevices objEn, MySqlTransaction tran)
        {

            string cadena = string.Empty;
            try
            {

                cadena = " INSERT INTO    Device    ";
                cadena += " (    ";
                cadena += "     ConnectionID,    ";
                cadena += "     NameDevice,    ";
                cadena += "     DeviceID,    ";
                cadena += "     SensorID,    ";
                cadena += "     OperSysID    ";
                cadena += " )    ";
                cadena += "     VALUES    ";
                cadena += " (    ";
                cadena += "     " + objEn.ConnectionID + ",    ";
                cadena += "     '" + objEn.NameDevice + "',    ";
                cadena += "     " + objEn.DeviceID + ",    ";
                cadena += "     " + objEn.SensorID + ",    ";
                cadena += "     " + objEn.OperSysID + "    ";
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

        public void Devices_Editar(EnDevices objEn, MySqlTransaction tran)
        {
            string cadena = string.Empty;
            try
            {

                cadena = " UPDATE    Device   SET ";
                cadena += "     ConnectionID = " + objEn.ConnectionID + ",    ";
                cadena += "     NameDevice = '" + objEn.NameDevice + "',    ";
                cadena += "     DeviceID = " + objEn.DeviceID + ",    ";
                cadena += "     SensorID = " + objEn.SensorID + ",    ";
                cadena += "     OperSysID = " + objEn.OperSysID + "    ";
                cadena += " WHERE   ";
                cadena += "     rowid = " + objEn.rowid + "   ";

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

        public DataTable Devices_Selecionar(int rowid)
        {
            string cadena = String.Empty;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {

                cadena = " SELECT   ";
                cadena += "     d.rowid,  ";
                cadena += "     d.ConnectionID,  ";
                cadena += "     c.description as Connection,  ";
                cadena += "     NameDevice,  ";
                cadena += "     d.DeviceID,  ";
                cadena += "     dt.description as Device,  ";
                cadena += "     d.SensorID,  ";
                cadena += "     s.description as Sensor,  ";
                cadena += "     d.OperSysID,  ";
                cadena += "     o.description as OperSystem  ";
                cadena += " FROM   ";
                cadena += "     Device  d    ";
                cadena += "     inner join Conecction_Type c   on      ";
                cadena += "         d.ConnectionID  =   c.rowid   ";
                cadena += "     inner join Device_Type dt   on      ";
                cadena += "         d.DeviceID  =   dt.rowid   ";
                cadena += "     inner join Sensor_Type s   on      ";
                cadena += "         d.SensorID  =   s.rowid   ";
                cadena += "     inner join OperativeSystem_Type o   on      ";
                cadena += "         d.OperSysID  =   o.rowid   ";
                cadena += " WHERE   ";
                cadena += "      d.rowid = " + rowid + "  ";

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


    }
}
