using System;
using System.Windows.Forms;

namespace servidorRecebe
{
    public partial class Form1 : Form
    {
        private Servidor servidor;

        public Form1()
        {
            InitializeComponent();
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

        private void ltbRecebe_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            servidor.Iniciar();
            MessageBox.Show("Servidor iniciado e aguardando mensagens...");
        }
    }
}
