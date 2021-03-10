using FileDirectory.Entities;
using System;
using System.Globalization;
using System.IO;

namespace FileDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\temp\arquivo.csv";

            try
            {
                string[] lines = File.ReadAllLines(path);

                string souceFolderPath = Path.GetDirectoryName(path); //Pegar o caminho do diretorio
                string targertFolderPath = souceFolderPath + @"\out"; //Passar o diretorio a ser incerido no caminho
                string targertFilePach = targertFolderPath + @"\summary.csv"; //Garar arquivo para resceber novos informações

                Directory.CreateDirectory(targertFolderPath);

                using (StreamWriter sw = File.AppendText(targertFilePach))
                {
                    foreach (string line in lines)
                    {
                        string[] textItem = line.Split(',');
                        string nome = textItem[0];
                        double price = double.Parse(textItem[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(textItem[2]);

                        Products products = new Products(nome, price, quantity);

                        sw.WriteLine($"{products.Name}, {products.TotalAmount().ToString("C2")}");
                    }
                }


            }
            catch (IOException ex)
            {

                Console.WriteLine("Um erro na execução do aquivo");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
