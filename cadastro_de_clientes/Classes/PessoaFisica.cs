﻿using System;
using cadastro_de_clientes.Dominio.Enderecos;

namespace cadastro_de_clientes.Dominio.Pessoas;

public class PessoaFisica : Pessoa
{
    public string? Cpf { get; private set; }
    public DateTime DataNascimento { get; private set; }

    public PessoaFisica(string Nome, Endereco Endereco) : base(Nome, Endereco) { }

    public PessoaFisica AdicionarCpf(string Cpf)
    {
        this.Cpf = Cpf;
        return this;
    }
    public PessoaFisica AdicionarDataNascimento(DateTime DataNascimento)
    {
        this.DataNascimento = DataNascimento;
        return this;
    }
    public override double PagarImposto(double rendimento)
    {
        throw new NotImplementedException();
    }
}

