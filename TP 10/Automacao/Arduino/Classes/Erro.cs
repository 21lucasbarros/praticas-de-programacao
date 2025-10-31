using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino.Classes
{
    internal class Erro
    {
        private static string msg;
        private static bool erro;

        public static void setMsg(string _msg)
        {
            erro = true;
            msg = _msg;
        }

        public static void setErro(bool _erro) { erro = _erro; }
        public static string getMsg() { return msg; }
        public static bool getErro() { return erro; }
    }
}
