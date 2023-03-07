using System;
namespace cadastro_de_clientes.Classes.Sistema
{
	public class MenuPessoaJuridica : Menu
	{

        public override string? DefinirTitulo()
        {
            string? Titulo = $@"
=====================================================
|               Bem Vindo ao Sistema de             |
|                Cadastro de Clientes               |
|                                                   |
=====================================================
|                   Pessoa Jurídica                 |
=====================================================
|               1. Novo Cadastro                    |
|               2. Listar Todos                     |
|               3. Exportar (txt)                   |
|               4. Exportar (csv)                   |
|               9. Voltar                           |
|               0. Encerrar Sistema                 |
=====================================================
";
            return Titulo;
        }

        public override void ExecutarOpcaoSelecionada()
        {
            throw new NotImplementedException();
        }
    }
}

