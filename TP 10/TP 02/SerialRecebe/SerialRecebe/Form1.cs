using System;
using System.Windows.Forms;
using System.IO.Ports;
using Npgsql;

namespace SerialRecebe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
                listBox1.Items.Add("Porta serial COM5 conectada com sucesso.");
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(DadosRecebidos);
            }
            catch (Exception erro)
            {
                listBox1.Items.Add("Erro ao se conectar à porta COM5 (" + erro.Message + ")");
            }
        }

        private void DadosRecebidos(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string dado = serialPort1.ReadLine().Trim();

                if (int.TryParse(dado, out int amostra))
                {
                    Invoke(new Action(() =>
                    {
                        listBox1.Items.Add(amostra);

                        // adiciona ponto no gráfico
                        chart1.Series[0].Points.AddY(amostra);
                        if (chart1.Series[0].Points.Count > 20)
                            chart1.Series[0].Points.RemoveAt(0);

                        // grava no banco
                        SalvarAmostra(amostra);
                    }));
                }
            }
            catch (Exception erro)
            {
                Invoke(new Action(() =>
                {
                    listBox1.Items.Add("Erro ao ler dados: " + erro.Message);
                }));
            }
        }

        private void SalvarAmostra(int valor)
        {
            string connStr = "Host=ep-noisy-dream-acfzrofu-pooler.sa-east-1.aws.neon.tech;Port=5432;Username=neondb_owner;Password=npg_93ZzAQEVfNOy;Database=neondb;SSL Mode=Require;Trust Server Certificate=true;";

            try
            {
                using (var conn = new NpgsqlConnection(connStr))
                {
                    conn.Open();

                    string sql = "INSERT INTO tabamostras (valor, datahora) VALUES (@valor, @datahora)";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@valor", valor);
                        cmd.Parameters.AddWithValue("@datahora", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }

                listBox1.Items.Add($"Amostra {valor} salva no banco ({DateTime.Now:HH:mm:ss})");
            }
            catch (Exception erro)
            {
                listBox1.Items.Add("Erro ao salvar no banco: " + erro.Message);
            }
        }
    }
}
