using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;

namespace Serializacao01
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BDLivros.mdb";
            List<Livro> listaLivros = new List<Livro>();

            using (OleDbConnection conexao = new OleDbConnection(connString))
            {
                conexao.Open();
                string sql = "SELECT codigo, titulo, autor, editora, ano FROM TabLivro";
                OleDbCommand cmd = new OleDbCommand(sql, conexao);
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Livro l = new Livro();
                    l.setCodigo(dr["codigo"].ToString());
                    l.setTitulo(dr["titulo"].ToString());
                    l.setAutor(dr["autor"].ToString());
                    l.setEditora(dr["editora"].ToString());
                    l.setAno(dr["ano"].ToString());

                    listaLivros.Add(l);
                }

                dr.Close();
                conexao.Close();
            }

            foreach (Livro l in listaLivros)
            {
                Console.WriteLine($"{l.getCodigo()} - {l.getTitulo()} - {l.getAutor()} - {l.getEditora()} - {l.getAno()}");
            }

            string json = JsonConvert.SerializeObject(listaLivros);
            File.WriteAllText("livros.json", json);

            Console.WriteLine("\nTodos os livros foram serializados para livros.json!");
            Console.ReadKey();
        }
    }
}
