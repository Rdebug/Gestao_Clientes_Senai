using System;
namespace cadastro_de_clientes.Classes.Sistema
{
	public abstract class Menu
	{
        protected List<PessoaFisica> ClientesPessoaFisica = new List<PessoaFisica>();
        protected List<PessoaJuridica> ClientesPessoaJuridica = new List<PessoaJuridica>();
        public Menu()
		{
			//this.Apresentacao();
		}
		protected ConsoleKeyInfo OpcaoSelecionada { get; set; }
		protected string? Titulo { get; set; }
		public abstract string? DefinirTitulo();
		public abstract void Apresentacao();
		public abstract void ExecutarOpcaoSelecionada();
	}
}