using System;
using cadastro_de_clientes.Interfaces;
namespace cadastro_de_clientes.Classes.CalculoDeImposto.PessoaFisica
{
    public class Ate1500Reais : Imposto
    {
        public Imposto Proximo { get; set; }
        public double CalculaImposto(double Rendimento)
        {  
            return 0;
        }
    }
}

