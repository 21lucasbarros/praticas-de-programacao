using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace ServidorRecebe
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socketreceber = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
            EndPoint endereco = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9060);
            byte[] data = new byte[1024];
            int qtdbytes, qtd;
            string filename;

            socketreceber.Bind(endereco);

            // recebe nome do arquivo
            qtdbytes = socketreceber.ReceiveFrom(data, ref endereco);
            filename = Encoding.ASCII.GetString(data, 0, qtdbytes);
            Console.WriteLine("FileName recebido: " + filename);

            // recebe quantidade de pacotes
            qtdbytes = socketreceber.ReceiveFrom(data, ref endereco);
            qtd = int.Parse(Encoding.ASCII.GetString(data, 0, qtdbytes));
            Console.WriteLine("QtdDataGramas = " + qtd);

            FileStream outfile = new FileStream(filename, FileMode.Create, FileAccess.Write);

            for (int i = 0; i < qtd; i++)
            {
                // recebe o pacote
                qtdbytes = socketreceber.ReceiveFrom(data, ref endereco);
                string conteudo = Encoding.ASCII.GetString(data, 0, qtdbytes);

                // recebe o checksum
                qtdbytes = socketreceber.ReceiveFrom(data, ref endereco);
                string checksumStr = Encoding.ASCII.GetString(data, 0, qtdbytes);
                int checksumRecebido = int.Parse(checksumStr);

                // calcula o checksum local
                int checksumCalculado = CalcularCheckSum(conteudo);

                Console.WriteLine($"Pacote {i + 1}: {conteudo} | CheckSum recebido={checksumRecebido}, calculado={checksumCalculado}");

                if (checksumRecebido != checksumCalculado)
                {
                    Console.WriteLine("Erro: Pacote corrompido! Encerrando...");
                    outfile.Close();
                    socketreceber.Close();
                    return;
                }

                // grava no arquivo
                foreach (char c in conteudo)
                    outfile.WriteByte((byte)c);
            }

            outfile.Close();
            socketreceber.Close();
            Console.WriteLine("Arquivo recebido com sucesso!");
            Console.ReadKey();
        }

        static int CalcularCheckSum(string dados)
        {
            int soma = 0;
            foreach (char c in dados)
                soma += (int)c;
            return soma;
        }
    }
}
