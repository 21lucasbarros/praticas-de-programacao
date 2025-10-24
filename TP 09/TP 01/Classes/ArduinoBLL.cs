using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_01.Classes
{
    class ArduinoBLL
    {
        private static int display = 0;

        public static void setDisplay(int _display) { display = _display; }
        public static int getDisplay() { return display; }

        public static String mostraBits(int _x)
        {
            String retorno = "";
            int aux = 128;

            for (int i = 0; i < 8; ++i)
            {
                if ((_x & aux) != 0)
                    retorno += "1";
                else
                    retorno += "0";
                aux = aux >> 1;
            }
            return retorno;
        }

        public static void ligaDispositivo(String _n)
        {
            int aux = 1 << (int.Parse(_n) - 1);
            display = display | aux;
        }

        public static void desligaDispositivo(String _n)
        {
            int aux = 1 << (int.Parse(_n) - 1);
            display = display & ~aux;
        }

        //public static void delay(int milissegundos)
        //{
        //    System.Threading.Thread.Sleep(milissegundos);
        //}

        public static async Task delayAsync(int milissegundos)
        {
            await Task.Delay(milissegundos);
        }

        public static void alarmeStep(bool ligar)
        {
            display = ligar ? 255 : 0;
        }

        //public static void alarme()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        // acende todos os LEDs
        //        display = 255;
        //        delay(2000);

        //        // apaga todos os LEDs
        //        display = 0;
        //        delay(2000);
        //    }
        //}

        //public static void sequencial()
        //{
        //    display = 0;
        //    for (int i = 0; i <= 8; i++)
        //    {
        //        ligaDispositivo(i.ToString());
        //        delay(2000);
        //    }
        //}
    }
}
