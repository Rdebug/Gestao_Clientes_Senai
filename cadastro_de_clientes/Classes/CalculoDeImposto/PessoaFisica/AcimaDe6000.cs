using System;
using cadastro_de_clientes.Interfaces;
namespace cadastro_de_clientes.Classes.CalculoDeImposto.PessoaFisica
{
	public class AcimaDe6000 : Imposto
	{
        public Imposto Proximo { get; set; }

        public double CalculaImposto(double Rendimento)
        {
            if (Rendimento > 6000)
            {
                return Rendimento * 0.05;
            }
            return Proximo.CalculaImposto(Rendimento);
        }
    }
}

