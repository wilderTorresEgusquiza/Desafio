using desafio2019.Data;
using desafio2019.Data.MySql;
using desafio2019.Entity.MySql;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio2019.Logic.MySql
{
    public class LoDevices
    {
        public object Devices_Lista()
        {
            try
            {
                DaDevices OjbDAO = new DaDevices();
                return OjbDAO.Devices_Lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Devices_Insertar(EnDevices objEn)
        {
            string msg = string.Empty;
            ConexionDAO cadenaDao = new ConexionDAO();

            using (MySqlConnection cn = new MySqlConnection(cadenaDao.CnxMySQL()))
            {
                cn.Open();
                using (MySqlTransaction tran = cn.BeginTransaction())
                {
                    try
                    {
                        DaDevices OjbDAO = new DaDevices();
                        OjbDAO.Devices_Insertar(objEn, tran);
                        tran.Commit();
                        msg = "EXITO";

                    }
                    catch (MySqlException ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        tran.Dispose();
                        cn.Close();
                    }
                    return msg;
                }
            }
        }

        public DataTable Devices_Selecionar(int rowid)
        {
            try
            {
                DaDevices OjbDAO = new DaDevices();
                return OjbDAO.Devices_Selecionar(rowid);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable DevicesJson_Selecionar(int rowid)
        {
            try
            {
                DaDevices OjbDAO = new DaDevices();
                return OjbDAO.DevicesJson_Selecionar(rowid);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string Devices_Editar(EnDevices objEn)
        {
            string msg = string.Empty;
            ConexionDAO cadenaDao = new ConexionDAO();

            using (MySqlConnection cn = new MySqlConnection(cadenaDao.CnxMySQL()))
            {
                cn.Open();
                using (MySqlTransaction tran = cn.BeginTransaction())
                {
                    try
                    {
                        DaDevices OjbDAO = new DaDevices();
                        OjbDAO.Devices_Editar(objEn, tran);
                        tran.Commit();
                        msg = "EXITO";

                    }
                    catch (MySqlException ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        tran.Dispose();
                        cn.Close();
                    }
                    return msg;
                }
            }
        }

        public string Devices_configuracion(int ID, string cadena)
        {
            string msg = string.Empty;
            ConexionDAO cadenaDao = new ConexionDAO();

            using (MySqlConnection cn = new MySqlConnection(cadenaDao.CnxMySQL()))
            {
                cn.Open();
                using (MySqlTransaction tran = cn.BeginTransaction())
                {
                    try
                    {
                        DaDevices OjbDAO = new DaDevices();
                        OjbDAO.Devices_configuracion(ID,cadena, tran);
                        tran.Commit();
                        msg = "EXITO";

                    }
                    catch (MySqlException ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        tran.Dispose();
                        cn.Close();
                    }
                    return msg;
                }
            }
        }
    }
}
