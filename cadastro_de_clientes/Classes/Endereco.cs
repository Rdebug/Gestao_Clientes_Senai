using System;
namespace cadastro_de_clientes.Classes
{
	public class Endereco
	{
		public string? logradouro { get; private set; }
		public string? bairro { get; private set; }
		public string? cidade { get; private set; }
		public string? estado { get; private set; }
        public bool isComercial { get; private set; }

		private Endereco(string logradouro, string bairro )
		{
			this.logradouro = logradouro;
			this.bairro = bairro;
		}

		/**
		 * Método responsável pela montagem de um novo endereço
		 */
		public static Endereco NovoEndereco(string logradouro, string bairro)
		{
			Endereco novoEndereco = new Endereco(logradouro, bairro);
			return novoEndereco;
		}

		/**
		 * Builder para adicionar Cidade
		 */
		public Endereco AdicionarCidade(string cidade)
		{
			this.cidade = cidade;
			return this;
		}

		/**
		 * Builder para adicionar tipo de endereço como comercial
		 */
		public void DefinirEnderecoComoComercial()
		{
			this.isComercial = true;
		}

		/**
		 * Builder para adicionar Estado
		 */
		public Endereco AdicionarEstado(string estado)
		{
			this.estado = estado;
			return this;
		}

		/**
		 * Retorna o endereço completo
		 */
		public override string ToString()
		{
			return $"Logradouro: {this.logradouro}\nBairro: {this.bairro}\nCidade: {this.cidade}\nEstado: {this.estado}\nTipo: {(isComercial?"Comercial":"Residencial")}";
		}
	}
}

