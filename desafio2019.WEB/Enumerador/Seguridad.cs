using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace desafio2019.WEB.Enumerador
{
    public class Seguridad
    {
        /// Encripta una cadena
        public static string Encriptar(string cadena)
        {
            string result = string.Empty;
            byte[] encryted = Encoding.Unicode.GetBytes(cadena);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public static string DesEncriptar(string cadena)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(cadena);
            result = Encoding.Unicode.GetString(decryted);
            return result;
        }

    }


}