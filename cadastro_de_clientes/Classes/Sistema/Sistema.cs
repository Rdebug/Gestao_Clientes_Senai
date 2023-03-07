using System;
using System.Net.NetworkInformation;

namespace cadastro_de_clientes.Classes.Sistema
{
	public class Sistema
	{
		public Sistema()
		{
			Console.Clear();
			new MenuPrincipal().Apresentacao();
		}
		public static void GerarMensagem(string Mensagem, string Status = "normal", int Tempo = 1500)
		{
            Console.Clear();
			if(Status == "sucesso") Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (Status == "aviso") Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (Status == "erro") Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(Mensagem);
			Console.ResetColor();
            Thread.Sleep(Tempo);
			Console.Clear();
        }
		public static void Encerrar()
		{
            Console.Clear();
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			//Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Obrigado por utilizar nosso sistema");
            Console.ResetColor();
            Thread.Sleep(1500);
        }
		public static bool VerificarPreenchimentoEmTexto(string? Texto)
		{
            if (Texto != null)
            {
                Texto = Texto.Trim();
                if (Texto.Length > 0)return true;
            }
            return false;
		}
		
	}
}

