using System;
using System.Text.RegularExpressions;
using cadastro_de_clientes.Classes;
using cadastro_de_clientes.Interfaces;
namespace cadastro_de_clientes.Classes;

public class PessoaJuridica : Pessoa, IPessoaJuridica
{
    public string? razaoSocial { get; private set; }
    public string? cnpj { get; private set; }

    public PessoaJuridica(string? Nome, Endereco Endereco) : base(Nome, Endereco) { }

    public PessoaJuridica AdicionarRazaoSocial(string? razaoSocial)
    {
        this.razaoSocial = razaoSocial;
        return this;
    }

    public PessoaJuridica adicionarCnpj(string cnpj)
    {
        if(this.ValidarCnpj(cnpj))
        {
        this.cnpj = cnpj;
        }
        return this;
    }

    public override double PagarImposto()
    {
        if(this.Rendimento != 0)
        {
            CalculadoraDeImpostos Calculadora = new CalculadoraDeImpostos();
            return Calculadora.CalculaPessoaJuridica(this.Rendimento);
        }
        return 0.0;
    }

    public bool ValidarCnpj(string Cnpj)
    {
        string Pattern = "\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}";
        Regex Regex = new (Pattern);
        if (Regex.IsMatch(Cnpj)) return true;
        return false;
    }

    public override Pessoa AdicionaRendimento(double Rendimento)
    {
        this.Rendimento = Rendimento;
        return this;
    }

    public override string ToString()
    {
        return $@"
Informações do Cliente:
Nome: {this.Nome}
CNPJ: {this.cnpj}
Razão Social: {this.razaoSocial}
Rendimento: {this.Rendimento.ToString("C")} reais
Imposto Apurado: {this.PagarImposto().ToString("C")} reais
Informações de Endereço:

{this.Endereco}

        ";
    }
}

