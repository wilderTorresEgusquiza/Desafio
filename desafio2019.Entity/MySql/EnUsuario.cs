using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio2019.Entity.MySql
{
    public class EnUsuario
    {
        public int rowid { get; set; }
        public string Name { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

    }
}
