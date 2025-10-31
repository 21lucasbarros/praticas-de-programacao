using Arduino.Classes;
using System;
using System.Windows.Forms;

namespace Arduino
{
    public partial class ArduinoIHM : Form
    {
        public ArduinoIHM()
        {
            InitializeComponent();
        }

        private void tratarBotoes(object sender, EventArgs e)
        {
            Button generico = (Button)sender;

            if (generico.Text == "Ligar")
            {
                generico.Text = "Desligar";
                ArduinoBLL.ligaDispositivo(generico.Tag.ToString());
                LogBLL.gravaLog(generico.Tag.ToString(), "Ligar");
            }
            else
            {
                generico.Text = "Ligar";
                ArduinoBLL.desligaDispositivo(generico.Tag.ToString());
                LogBLL.gravaLog(generico.Tag.ToString(), "Desligar");
            }
            textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ArduinoBLL.setDisplay(0);
            textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
            button1.Text = "Ligar";
            button2.Text = "Ligar";
            button3.Text = "Ligar";
            button4.Text = "Ligar";
            button5.Text = "Ligar";
            button6.Text = "Ligar";
            button7.Text = "Ligar";
            button8.Text = "Ligar";
        }

        private void ArduinoIHM_Load(object sender, EventArgs e)
        {
            LogDAL.conecta();
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
        }

        private void ArduinoIHM_FormClosing(object sender, FormClosingEventArgs e)
        {
            LogDAL.desconecta();
        }
    }
}
