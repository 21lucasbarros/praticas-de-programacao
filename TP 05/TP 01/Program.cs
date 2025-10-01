using System;
using System.Threading.Tasks;

namespace TP_01
{
    class Program
    {
        public static bool isPrimo(int x)
        {
            int f = x / 2 + 1;
            for (int i = 2; i < f; ++i)
                if (x % i == 0) return false;
            return true;
        }

        public static void procPrimos(int id, int inicio, int fim)
        {
            DateTime hinicio, hfim;
            int k = 0;

            hinicio = DateTime.Now;
            for (int i = inicio; i < fim; ++i)
                if (isPrimo(i)) ++k;
            hfim = DateTime.Now;

            Console.WriteLine("Task " + id + " encontrou " + k + " números primos.");
            Console.WriteLine("Começou em.: " + hinicio.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
            Console.WriteLine("Terminou em: " + hfim.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
            Console.WriteLine("Tempo = " + (hfim - hinicio));
            Console.WriteLine("---------------------------------------------");
        }

        static void Main(string[] args)
        {
            Parallel.Invoke(
                () => procPrimos(1, 1, 150000),
                () => procPrimos(2, 150001, 230000),
                () => procPrimos(3, 230001, 300000)
            );

            Console.WriteLine("Execução finalizada. Pressione qualquer tecla para sair.");
            Console.ReadKey();
        }
    }
}
