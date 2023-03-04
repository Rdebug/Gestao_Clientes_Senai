using System;
using cadastro_de_clientes.Classes;
namespace cadastro_de_clientes.Classes;

public abstract class Pessoa
{
	public string? Nome { get; private set; }
	public Endereco? Endereco { get; private set; }
	public double Rendimento { get; protected set; }
	public Pessoa(string Nome, Endereco Endereco)
	{
		this.Nome = Nome;
		this.Endereco = Endereco;
	}
	public abstract double PagarImposto();
	public abstract Pessoa AdicionaRendimento(double Rendimento);
}

