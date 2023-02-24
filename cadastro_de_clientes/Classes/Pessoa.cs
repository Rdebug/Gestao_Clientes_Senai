﻿using System;
using cadastro_de_clientes.Dominio.Enderecos;
namespace cadastro_de_clientes.Dominio.Pessoas
{
	public abstract class Pessoa
	{
		public string? Nome { get; private set; }
		public Endereco? Endereco { get; private set; }
		public Pessoa(string Nome, Endereco Endereco)
		{
			this.Nome = Nome;
			this.Endereco = Endereco;
		}
		public abstract double PagarImposto(double rendimento);
	}
}
