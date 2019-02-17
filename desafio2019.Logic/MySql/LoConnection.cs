using desafio2019.Data.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio2019.Logic.MySql
{
    public class LoConnection
    {
        public object CargaConnection()
        {
            try
            {
                DaConnection OjbDAO = new DaConnection();
                return OjbDAO.CargaConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
