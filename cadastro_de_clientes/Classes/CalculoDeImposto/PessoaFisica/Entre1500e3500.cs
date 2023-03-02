using System;
using cadastro_de_clientes.Interfaces;
namespace cadastro_de_clientes.Classes.CalculoDeImposto.PessoaFisica
{
    public class Entre1500e3500 : Imposto
    {
        public Imposto Proximo { get; set; }

        public double CalculaImposto(double Rendimento)
        {
            if( Rendimento >= 1500 && Rendimento <= 3500)
            {
                return Rendimento * 0.02;
            }
            return Proximo.CalculaImposto(Rendimento);
        }
    }
}

