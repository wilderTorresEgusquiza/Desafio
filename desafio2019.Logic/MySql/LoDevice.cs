using desafio2019.Data.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio2019.Logic.MySql
{
    public class LoDevice
    {
        public object CargaDevice()
        {
            try
            {
                DaDevice OjbDAO = new DaDevice();
                return OjbDAO.CargaDevice();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
