using System;
using cadastro_de_clientes.Dominio.Enderecos;

namespace cadastro_de_clientes.Dominio.Pessoas;

public class PessoaJuridica : Pessoa
{
    public string? razaoSocial { get; private set; }
    public string? cnpj { get; private set; }

    public PessoaJuridica(string Nome, Endereco Endereco) : base(Nome, Endereco) { }

    public PessoaJuridica AdicionarRazaoSocial(string razaoSocial)
    {
        this.razaoSocial = razaoSocial;
        return this;
    }

    public PessoaJuridica adicionarCnpj(string cnpj)
    {
        // TODO VALIDAR CNPJ;
        this.cnpj = cnpj;
        return this;
    }

    public override double PagarImposto(double rendimento)
    {
        // TODO ADICIONAR REGRA DE CÁLCULO DE IMPOSTO
        throw new NotImplementedException();
    }
}

