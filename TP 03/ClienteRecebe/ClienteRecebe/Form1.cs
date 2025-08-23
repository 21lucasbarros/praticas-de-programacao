using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace ClienteRecebe
{
    public partial class Form1 : Form
    {
        private Cliente cliente;
        public Form1()
        {
            InitializeComponent();
            cliente = new Cliente();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            string mensagem = txtEnvia.Text;
            cliente.EnviarMensagem(mensagem);
            ltbMostra.Items.Add("Lucas e João Del enviam: " + mensagem);
            txtEnvia.Clear();
        }

        private void ltbMostra_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtEnvia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
