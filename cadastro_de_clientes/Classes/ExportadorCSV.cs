using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace cadastro_de_clientes.Classes
{
	public class ExportadorCSV
	{
        public static void Exportar(string diretorioOrigem)
        {
            // Obter uma lista de arquivos txt no diretório de origem
            var arquivosTxt = Directory.GetFiles(diretorioOrigem, "*.txt");

            // Loop através dos arquivos txt e exportá-los como arquivos csv
            foreach (var arquivoTxt in arquivosTxt)
            {
                var linhas = File.ReadAllLines(arquivoTxt);
                var arquivoCsv = Path.ChangeExtension(arquivoTxt, ".csv");
                using (var writer = new StreamWriter(arquivoCsv))
                {
                    foreach (var linha in linhas)
                    {
                        var campos = linha.Split(',');
                        var linhaCsv = string.Join(';', campos);
                        writer.WriteLine(linhaCsv);
                    }
                }
            }
        }
    }
}

