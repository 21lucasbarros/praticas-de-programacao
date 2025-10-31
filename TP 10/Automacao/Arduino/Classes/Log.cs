using System;

namespace Arduino
{
    internal class Log
    {
        private static string dispositivo;
        private static string operacao;
        private static string data;
        private static string hora;

        public static void setDispositivo(string _dispositivo) { dispositivo = _dispositivo; }
        public static void setOperacao(string _operacao) { operacao = _operacao; }
        public static void setData(string _data) { data = _data; }
        public static void setHora(string _hora) { hora = _hora; }

        public static string getDispositivo() { return dispositivo; }
        public static string getOperacao() { return operacao; }
        public static string getData() { return data; }
        public static string getHora() { return hora; }
    }
}
