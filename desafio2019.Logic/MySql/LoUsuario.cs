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
    public class LoUsuario
    {

        public DataTable Usuarios_Listar(EnUsuario objEn)
        {
            try
            {
                DaUsuario OjbDAO = new DaUsuario();
                return OjbDAO.Usuarios_Listar(objEn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Usuarios_Insertar(EnUsuario objEn)
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
                        DaUsuario OjbDAO = new DaUsuario();
                        OjbDAO.Usuarios_Insertar(objEn, tran);
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
