using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace ClienteEnvia
{
    class Program
    {
        static void Main(string[] args)
        {
            //int pacoteAtual = 0; // para simular erro proposital no 3o pacote

            string filename = "testeXML.xml";
            string buffer = "";

            // abre o arquivo e lê todo o conteúdo
            FileStream infile = new FileStream(filename, FileMode.Open, FileAccess.Read);
            int tam = (int)infile.Length;

            for (int i = 0; i < tam; ++i)
                buffer += (char)infile.ReadByte();

            infile.Close();

            // cria o socket UDP
            Socket socketenviar = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.IP);
            IPEndPoint endereco = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9060);

            // envia nome do arquivo
            socketenviar.SendTo(Encoding.ASCII.GetBytes(filename), endereco);
            Console.WriteLine("FileName = " + filename);

            // envia quantidade de pacotes
            int qtd = tam / 10;
            if (tam % 10 != 0) ++qtd;
            socketenviar.SendTo(Encoding.ASCII.GetBytes(qtd.ToString()), endereco);
            Console.WriteLine("QtdDataGramas = " + qtd);

            // envia pacotes de 10 bytes + checksum
            string aux = "";
            for (int i = 0, j = 1; i < tam; ++i, ++j)
            {
                aux += buffer[i];

                if (j == 10)
                {
                    int checksum = CalcularCheckSum(aux);

                    // Simulação de erro proposital no 3º pacote
                    //if (pacoteAtual == 2) // 0-based -> terceiro pacote
                    //{
                    //    // altera um caractere do pacote para corromper
                    //    char[] arr = aux.ToCharArray();
                    //    arr[0] = (char)(arr[0] + 1); // muda 1o byte
                    //    aux = new string(arr);
                    //    Console.WriteLine("PACOTE CORROMPIDO PROPOSITALMENTE !!!");
                    //}

                    socketenviar.SendTo(Encoding.ASCII.GetBytes(aux), endereco);
                    socketenviar.SendTo(Encoding.ASCII.GetBytes(checksum.ToString()), endereco);
                    Console.WriteLine($"Enviado: {aux} | CheckSum: {checksum}");

                    //pacoteAtual++;
                    j = 0;
                    aux = "";
                }
            }

            // envia o resto (último bloco, se sobrar)
            if (tam % 10 != 0)
            {
                int checksum = CalcularCheckSum(aux);
                socketenviar.SendTo(Encoding.ASCII.GetBytes(aux), endereco);
                socketenviar.SendTo(Encoding.ASCII.GetBytes(checksum.ToString()), endereco);
                Console.WriteLine($"Enviado: {aux} | CheckSum: {checksum}");
            }

            socketenviar.Close();
            Console.WriteLine("Envio concluído!");
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
