using System;
using cadastro_de_clientes.Interfaces;
namespace cadastro_de_clientes.Classes.CalculoDeImposto.PessoaJuridica
{
	public class AcimaDe10000 : Imposto
	{
        public Imposto Proximo { get; set; }

        public double CalculaImposto(double Rendimento)
        {
            if (Rendimento > 10000)
            {
                return Rendimento * 0.09;
            }
            return Proximo.CalculaImposto(Rendimento);
        }
    }
}

