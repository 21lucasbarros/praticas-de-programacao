using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP04
{
    public partial class Form1 : Form
    {

        private Cliente cliente;
        private Servidor servidor;

        public Form1()
        {
            InitializeComponent();
            cliente = new Cliente();
            servidor = new Servidor();
            servidor.MensagemRecebida += AtualizarLista;

        }

        private void AtualizarLista(string mensagem)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AtualizarLista(mensagem)));
            }
            else
            {
                ltbRecebe.Items.Add("Lucas e João Del enviam: " + mensagem);
                ltbRecebe.Refresh();
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string mensagem = txtEnvia.Text;
            cliente.EnviarMensagem(mensagem);
            ltbMostra.Items.Add("Lucas e João Del enviam: " + mensagem);
            txtEnvia.Clear();
        }

        private void btnAtivar_Click(object sender, EventArgs e)
        {
            servidor.Iniciar();
            MessageBox.Show("Servidor iniciado e aguardando mensagens...");
        }
    }
}
