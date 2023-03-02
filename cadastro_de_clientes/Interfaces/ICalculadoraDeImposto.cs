using System;
namespace cadastro_de_clientes.Interfaces
{
	public interface ICalculadoraDeImposto
	{
		public double CalculaPessoaFisica(double rendimento);
        public double CalculaPessoaJuridica(double rendimento);
    }
}

