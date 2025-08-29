class Program
{
    static int k = 0;

    public static bool isPrimo(int x)
    {
        int f = x / 2 + 1;
        for (int i = 2; i < f; ++i)
            if (x % i == 0) return false;
        return true;
    }

    static void ContaPrimos(int inicio, int fim)
    {
        for (int i = inicio; i < fim; ++i)
            if (isPrimo(i)) ++k;
    }

    static void Main(string[] args)
    {
        DateTime inicio, fim;
        inicio = DateTime.Now;

        Thread t1 = new Thread(() => ContaPrimos(1, 100000));
        Thread t2 = new Thread(() => ContaPrimos(100000, 200000));
        Thread t3 = new Thread(() => ContaPrimos(200000, 300000));

        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        fim = DateTime.Now;

        Console.WriteLine("Foram encontrados " + k + " numeros primos.");
        Console.WriteLine("Tempo = " + (fim - inicio));
        Console.ReadKey();
    }
}