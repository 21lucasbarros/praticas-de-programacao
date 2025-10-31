using Arduino.Classes;
using System;
using System.Windows.Forms;

namespace Arduino
{
    internal class LogBLL
    {
        public static void gravaLog(string dispositivo, string operacao)
        {
            Erro.setErro(false);
            try
            {
                DateTime agora = DateTime.Now;

                Log.setDispositivo(dispositivo);
                Log.setOperacao(operacao);
                Log.setData(agora.ToString("yyyy-MM-dd"));
                Log.setHora(agora.ToString("HH:mm:ss"));

                LogDAL.insereLog();
            }
            catch (Exception ex)
            {
                Erro.setMsg("Erro ao gravar o log: " + ex.Message);
            }
        }
    }
}
