using Arduino.Classes;
using Npgsql;
using System;
using System.Windows.Forms;

namespace Arduino
{
    internal class LogDAL
    {
        private static string connStr = "Host=ep-noisy-dream-acfzrofu-pooler.sa-east-1.aws.neon.tech;Port=5432;Username=neondb_owner;Password=npg_93ZzAQEVfNOy;Database=neondb;SSL Mode=Require;Trust Server Certificate=true;";
        private static NpgsqlConnection conn;
        private static NpgsqlCommand comando;

        public static void conecta()
        {
            try
            {
                conn = new NpgsqlConnection(connStr);
                conn.Open();
            }
            catch (Exception ex)
            {
                Erro.setMsg("Erro ao conectar: " + ex.Message);
            }
        }

        public static void desconecta()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        public static void insereLog()
        {
            try
            {
                if (conn == null || conn.State != System.Data.ConnectionState.Open)
                    conecta();

                string sql = "INSERT INTO tablog (dispositivo, operacao, data, hora) VALUES (@dispositivo, @operacao, @data, @hora)";

                comando = new NpgsqlCommand(sql, conn);
                comando.Parameters.AddWithValue("@dispositivo", Log.getDispositivo());
                comando.Parameters.AddWithValue("@operacao", Log.getOperacao());
                comando.Parameters.AddWithValue("@data", DateTime.Parse(Log.getData()));
                comando.Parameters.AddWithValue("@hora", TimeSpan.Parse(Log.getHora()));

                int linhas = comando.ExecuteNonQuery();

                if (linhas == 0)
                    MessageBox.Show("Nenhum registro inserido!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir log: " + ex.Message);
            }
        }
    }
}
