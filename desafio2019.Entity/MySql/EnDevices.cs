using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio2019.Entity.MySql
{
    public class EnDevices
    {
        public int rowid { get; set; }
        public int ConnectionID { get; set; }
        public string NameDevice { get; set; }
        public int DeviceID { get; set; }
        public int SensorID { get; set; }
        public int OperSysID { get; set; }
        public string Dip { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
        public string temmax { get; set; }
        public string temmin { get; set; }
        public string hummax { get; set; }
        public string hummin { get; set; }

        public class EnDevicesTabla
        {
            public int rowid { get; set; }
            public int ConnectionID { get; set; }
            public string Connection { get; set; }
            public string NameDevice { get; set; }
            public string usuario { get; set; }
            public string clave { get; set; }
            public int DeviceID { get; set; }
            public string Dip { get; set; }
            public string Device { get; set; }
            public int SensorID { get; set; }
            public string Sensor { get; set; }
            public int OperSysID { get; set; }
            public string OperSystem { get; set; }
            public string temmax { get; set; }
            public string temmin { get; set; }
            public string hummax { get; set; }
            public string hummin { get; set; }

        }

    }
}
