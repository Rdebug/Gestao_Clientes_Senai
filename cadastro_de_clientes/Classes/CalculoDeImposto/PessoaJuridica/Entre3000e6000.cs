using System;
using cadastro_de_clientes.Interfaces;
namespace cadastro_de_clientes.Classes.CalculoDeImposto.PessoaJuridica
{
    public class Entre3000e6000 : Imposto
    {
        public Imposto Proximo { get; set; }

        public double CalculaImposto(double Rendimento)
        {
            if( Rendimento >= 3000 && Rendimento <= 6000)
            {
                return Rendimento * 0.05;
            }
            return Proximo.CalculaImposto(Rendimento);
        }
    }
}

