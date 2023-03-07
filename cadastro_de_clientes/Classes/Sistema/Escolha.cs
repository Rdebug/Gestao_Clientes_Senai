using System;
namespace cadastro_de_clientes.Classes.Sistema
{

	public class Escolha
	{
		public static ConsoleKeyInfo SelecionarOpcao()
		{
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.WriteLine("\n   Selecione uma opção:   ");
			var Opcao = Console.ReadKey(true);
			Console.ResetColor();
			return Opcao;
		}
	}
}

