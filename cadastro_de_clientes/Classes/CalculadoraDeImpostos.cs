using System;
using cadastro_de_clientes.Interfaces;
using cadastro_de_clientes.Classes.CalculoDeImposto.PessoaFisica;
using cadastro_de_clientes.Classes.CalculoDeImposto.PessoaJuridica;
namespace cadastro_de_clientes.Classes;

public class CalculadoraDeImpostos : ICalculadoraDeImposto
{ 
    public double CalculaPessoaFisica(double rendimento)
    {
        Imposto Ate1500 = new Ate1500Reais();
        Imposto Entre1500e3500 = new Entre1500e3500();
        Imposto Entre3500e6000 = new Entre3500e6000();
        Imposto AcimaDe6000 = new AcimaDe6000();

        AcimaDe6000.Proximo = Entre3500e6000;
        Entre3500e6000.Proximo = Entre1500e3500;
        Entre1500e3500.Proximo = Ate1500;
        return AcimaDe6000.CalculaImposto(rendimento);
    }

    public double CalculaPessoaJuridica(double rendimento)
    {
        Imposto Ate3000 = new Ate3000Reais();
        Imposto Entre3000e6000 = new Entre3000e6000();
        Imposto Entre6000e10000 = new Entre6000e10000();
        Imposto AcimaDe10000 = new AcimaDe10000();

        AcimaDe10000.Proximo = Entre6000e10000;
        Entre6000e10000.Proximo = Entre3000e6000;
        Entre3000e6000.Proximo = Ate3000;
        return AcimaDe10000.CalculaImposto(rendimento);
    }
}

