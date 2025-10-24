using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_01.Classes;

namespace TP_01
{
    public partial class Form1 : Form
    {
        public Form1()
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
                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
            }
            else
            {
                generico.Text = "Ligar";
                ArduinoBLL.desligaDispositivo(generico.Tag.ToString());
                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
            }

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

        //private void button10_Click(object sender, EventArgs e)
        //{
        //    ArduinoBLL.alarme();
        //    textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
        //}

        //private void button11_Click(object sender, EventArgs e)
        //{
        //    ArduinoBLL.sequencial();
        //    textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
        //}

        private async void button10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                ArduinoBLL.alarmeStep(true);
                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
                await Task.Delay(2000);

                ArduinoBLL.alarmeStep(false);
                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
                await Task.Delay(2000);
            }
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            ArduinoBLL.setDisplay(0);
            for (int i = 1; i <= 8; i++)
            {
                ArduinoBLL.ligaDispositivo(i.ToString());
                textBox1.Text = ArduinoBLL.mostraBits(ArduinoBLL.getDisplay());
                await Task.Delay(500); // 500ms ou 2000ms
            }
        }
    }
}
