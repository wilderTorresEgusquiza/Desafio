using desafio2019.Data.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio2019.Logic.MySql
{
    public class LoDevice_Type
    {
        public object CargaDevice_Type()
        {
            try
            {
                DaDevice_Type OjbDAO = new DaDevice_Type();
                return OjbDAO.CargaDevice_Type();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
