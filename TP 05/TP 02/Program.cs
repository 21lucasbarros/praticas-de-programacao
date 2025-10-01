using System;
using System.Threading;
using System.Threading.Tasks;

namespace TP_02
{
    class Program
    {
        static void processo1()
        {
            Console.WriteLine("Iniciando Processo 1");
            Thread.Sleep(5000); // 5 segundos
            Console.WriteLine("Finalizando Processo 1");
        }

        static void processo2()
        {
            Console.WriteLine("Iniciando Processo 2");
            Thread.Sleep(4000); // 4 segundos
            Console.WriteLine("Finalizando Processo 2");
        }

        static void processo3()
        {
            Console.WriteLine("Iniciando Processo 3");
            Thread.Sleep(3000); // 3 segundos
            Console.WriteLine("Finalizando Processo 3");
        }

        static void processo4()
        {
            Console.WriteLine("Iniciando Processo 4 (depende do 1)");
            Thread.Sleep(3000); // 3 segundos
            Console.WriteLine("Finalizando Processo 4");
        }

        static void processo5()
        {
            Console.WriteLine("Iniciando Processo 5 (depende do 2)");
            Thread.Sleep(5000); // 5 segundos
            Console.WriteLine("Finalizando Processo 5");
        }

        static void processo6()
        {
            Console.WriteLine("Iniciando Processo 6 (depende de todos os anteriores)");
            Thread.Sleep(1000); // 1 segundo
            Console.WriteLine("Finalizando Processo 6");
        }

        static void Main(string[] args)
        {
            DateTime inicio = DateTime.Now;

            var t1 = Task.Run(() => processo1());
            var t2 = Task.Run(() => processo2());
            var t3 = Task.Run(() => processo3());

            var t4 = t1.ContinueWith(_ => processo4());

            var t5 = t2.ContinueWith(_ => processo5());

            var t6 = Task.WhenAll(t1, t2, t3, t4, t5).ContinueWith(_ => processo6());

            t6.Wait();

            DateTime fim = DateTime.Now;
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Tempo total = " + (fim - inicio));
            Console.WriteLine("Execução finalizada. Pressione qualquer tecla para sair.");
            Console.ReadKey();
        }
    }
}
