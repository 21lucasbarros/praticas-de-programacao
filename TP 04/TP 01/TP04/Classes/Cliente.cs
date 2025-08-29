using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TP04
{
    internal class Cliente
    {
        private Socket socketenviar;
        private IPEndPoint endereco;

        public Cliente()
        {
            socketenviar = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            endereco = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9060);
        }

        public void EnviarMensagem(string mensagem)
        {
            if (!string.IsNullOrEmpty(mensagem))
            {
                socketenviar.SendTo(Encoding.ASCII.GetBytes(mensagem), endereco);
            }
        }
    }
}
