using System;
using cadastro_de_clientes.Classes;
namespace cadastro_de_clientes.Interfaces
{
	public interface IPessoaFisica
	{
		public bool ValidarCpf(string Cpf);
		public bool ValidarDataNascimento(DateTime DataNascimento);
	}
}

