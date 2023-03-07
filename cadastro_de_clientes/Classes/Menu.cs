using System;
namespace cadastro_de_clientes.Classes
{
	public class Menu
	{
		string[] MenuPrincipal = ["teste"];

		public void Gerar()
		{
			this.BoasVindas();
		}
		private void BoasVindas()
		{
			Console.WriteLine($"=======================================================\nBem vindo ao nosso sistema de Cadastro de Clientes\nPessoa Física e Pessoa Jurídica\n=======================================================");
		}
	}
}

