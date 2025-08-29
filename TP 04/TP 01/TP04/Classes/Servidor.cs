using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TP04
{
    internal class Servidor
    {
        private Socket socketReceber;
        private IPEndPoint endereco;
        public event Action<string> MensagemRecebida;

        public Servidor()
        {
            socketReceber = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            endereco = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9060);
            socketReceber.Bind(endereco);
        }

        public void Iniciar()
        {
            Thread thread = new Thread(() =>
            {
                byte[] data = new byte[1024];
                EndPoint remetente = new IPEndPoint(IPAddress.Any, 0);

                while (true)
                {
                    int qtdBytes = socketReceber.ReceiveFrom(data, ref remetente);
                    string mensagem = Encoding.ASCII.GetString(data, 0, qtdBytes);
                    MensagemRecebida?.Invoke(mensagem);
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }
}
