using System;
using System.Text.RegularExpressions;
using cadastro_de_clientes.Interfaces;
namespace cadastro_de_clientes.Classes;

public class PessoaFisica : Pessoa, IPessoaFisica
{
    public string? Cpf { get; private set; }
    public DateTime DataNascimento { get; private set; }

    public PessoaFisica(string Nome, Endereco Endereco) : base(Nome, Endereco) { }

    public PessoaFisica AdicionarCpf(string Cpf)
    {
        if(this.ValidarCpf(Cpf))
        {
            this.Cpf = Cpf;
        }
            return this;

    }

    public PessoaFisica AdicionarDataNascimento(DateTime DataNascimento)
    {
        if(this.ValidarDataNascimento(DataNascimento))
        {
            this.DataNascimento = DataNascimento;
        }
        return this;
    }

    public override double PagarImposto()
    {
        if(this.Rendimento != 0)
        {
            CalculadoraDeImpostos Calculadora = new CalculadoraDeImpostos();
            return Calculadora.CalculaPessoaFisica(this.Rendimento);
        }
        return 0.0;
    }

    public bool ValidarCpf(string Cpf)
    {
        string Pattern = "\\d{3}\\.?\\d{3}\\.?\\d{3}\\-?\\d{2}";
        Regex Regex = new(Pattern);
        if (Regex.IsMatch(Cpf)) return true;
        return false;
    }

    public bool ValidarDataNascimento(DateTime DataNascimento)
    {
        DateTime Hoje = DateTime.Today;
        double Idade = (Hoje - DataNascimento).TotalDays / 365;
        if (Idade >= 18) return true;
        return false;
    }

    public override Pessoa AdicionaRendimento(double Rendimento)
    {
        this.Rendimento = Rendimento;
        return this;
    }
}

