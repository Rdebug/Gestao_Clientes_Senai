using System;
using cadastro_de_clientes.Dominio.Enderecos;

namespace cadastro_de_clientes.Dominio.Pessoas;

public class PessoaFisica : Pessoa
{
    public PessoaFisica(string Nome, Endereco Endereco) : base(Nome, Endereco)
    {
    }

    public override double CalcularImposto(double rendimento)
    {
        throw new NotImplementedException();
    }
}

