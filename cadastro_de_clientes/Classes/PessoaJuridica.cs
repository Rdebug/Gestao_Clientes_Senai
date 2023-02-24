using System;
using cadastro_de_clientes.Classes;
using cadastro_de_clientes.Interfaces;
namespace cadastro_de_clientes.Classes;

public class PessoaJuridica : Pessoa, IPessoaJuridica
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

    public bool ValidarCnpj(string Cnpj)
    {
        throw new NotImplementedException();
    }
}

