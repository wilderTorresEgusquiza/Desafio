using desafio2019.Data.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio2019.Logic.MySql
{
    public class LoOperativeSystem
    {
        public object CargaOperativeSystem()
        {
            try
            {
                DaOperativeSystem OjbDAO = new DaOperativeSystem();
                return OjbDAO.CargaOperativeSystem();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
