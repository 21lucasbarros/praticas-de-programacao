using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace SerialEnvia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Iniciar")
            {
                button1.Text = "Finalizar";
                timer1.Enabled = true;
                try
                {
                    serialPort1.Open();
                    listBox1.Items.Add("Porta serial aberta com sucesso!");
                }
                catch (Exception erro)
                {
                    listBox1.Items.Add("Erro ao abrir porta: " + erro.Message);
                }
            }
            else
            {
                button1.Text = "Iniciar";
                timer1.Enabled = false;
                if (serialPort1.IsOpen) serialPort1.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random gerador = new Random();
            int amostra = gerador.Next(100);

            listBox1.Items.Add(amostra);

            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine(amostra.ToString());
            }
        }
    }
}
