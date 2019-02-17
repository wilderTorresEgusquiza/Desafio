using desafio2019.Data.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio2019.Logic.MySql
{
    public class LoSensor
    {
        public object CargaSensor()
        {
            try
            {
                DaSensor OjbDAO = new DaSensor();
                return OjbDAO.CargaSensor();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
