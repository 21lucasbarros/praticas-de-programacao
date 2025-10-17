using Ponto.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace Ponto
{
    class Program
    {
        static void Main(string[] args)
        {
            List<OcorrenciaPonto> ocorrencias = new List<OcorrenciaPonto>();

            using (StreamReader file = new StreamReader("Abril2017.txt"))
            {
                string linha;
                while ((linha = file.ReadLine()) != null)
                {
                    if (linha.Length < 31) continue; // ignora linhas curtas

                    OcorrenciaPonto o = new OcorrenciaPonto
                    {
                        Prontuario = linha.Substring(0, 15),
                        Data = linha.Substring(15, 6),
                        Hora = linha.Substring(21, 4),
                        Filler = linha.Substring(25, 8)
                    };

                    ocorrencias.Add(o);
                    Console.WriteLine(o);
                }
            }

            // serializa a lista para XML
            DataContractSerializer serializer = new DataContractSerializer(typeof(List<OcorrenciaPonto>));
            using (FileStream fs = new FileStream("Ocorrencias.xml", FileMode.Create))
            using (XmlWriter writer = XmlWriter.Create(fs, new XmlWriterSettings { Indent = true }))
            {
                serializer.WriteObject(writer, ocorrencias);
            }

            Console.WriteLine("\nArquivo 'Ocorrencias.xml' gerado com sucesso!");
            Console.ReadKey();
        }
    }
}
