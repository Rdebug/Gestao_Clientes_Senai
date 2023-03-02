using System;
using cadastro_de_clientes.Interfaces;
namespace cadastro_de_clientes.Classes.CalculoDeImposto.PessoaJuridica
{
    public class Entre6000e10000 : Imposto
    {
        public Imposto Proximo { get; set; }

        public double CalculaImposto(double Rendimento)
        {
            if( Rendimento >= 6000 && Rendimento <= 10000)
            {
                return Rendimento * 0.07;
            }
            return Proximo.CalculaImposto(Rendimento);
        }
    }
}

