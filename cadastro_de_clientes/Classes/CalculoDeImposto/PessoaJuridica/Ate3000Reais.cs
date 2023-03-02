using System;
using cadastro_de_clientes.Interfaces;
namespace cadastro_de_clientes.Classes.CalculoDeImposto.PessoaJuridica
{
    public class Ate3000Reais : Imposto
    {
        public Imposto Proximo { get; set; }
        public double CalculaImposto(double Rendimento)
        {
            return Rendimento * 0.03;
        }
    }
}

