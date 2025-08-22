using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prova
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            BLL.conecta();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BLL.desconecta();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            double totalValor = 0;
            double totalToneladas = 0;
            int i = 0;
            chart1.Series[0].Points.Clear();




            Cliente.setCNPJ(tb_cnpj.Text);

            BLL.validaCNPJ();

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
                MessageBox.Show("Dados inseridos com sucesso!");


            tb_Nome.Text = Cliente.getNome();


            BLL.getProximo();
            while (!Erro.getErro())
            {

                if (rb_Toneladas.Checked)
                {
                    chart1.Series[0].Points.AddXY(VendaCliente.getData(), VendaCliente.getToneladas());
                    totalValor += Double.Parse(VendaCliente.getToneladas());

                    i++;
                }
                else
                {
                    chart1.Series[0].Points.AddXY(VendaCliente.getData(), VendaCliente.getValor());
                    totalValor += Double.Parse(VendaCliente.getValor());

                }




                BLL.getProximo();


            }

            tb_Tt.Text = totalValor.ToString();

        }
    }
}
