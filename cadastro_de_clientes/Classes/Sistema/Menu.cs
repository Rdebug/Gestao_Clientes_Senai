using System;
namespace cadastro_de_clientes.Classes.Sistema
{
	public abstract class Menu
	{
        protected List<PessoaFisica> ClientesPessoaFisica = new List<PessoaFisica>();
        public Menu()
		{
			//this.Apresentacao();
		}
		protected ConsoleKeyInfo OpcaoSelecionada { get; set; }
		protected string? Titulo { get; set; }
		public abstract string? DefinirTitulo();
		public void Apresentacao()
		{
			Console.Clear();
			this.Titulo = DefinirTitulo();
			Console.Write(this.Titulo);
            var OpcaoSelecionada = Escolha.SelecionarOpcao();
            this.OpcaoSelecionada = OpcaoSelecionada;
            this.ExecutarOpcaoSelecionada();
        }
		public abstract void ExecutarOpcaoSelecionada();
	}
}