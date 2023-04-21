using System;
namespace cadastro_de_clientes.Classes.Sistema;

public class MenuPrincipal : Menu
{
    
    public override string DefinirTitulo()
    {
        this.Titulo = $@"
        =====================================================
        |               Bem Vindo ao Sistema de             |
        |               Cadastro de Clientes                |
        |                                                   |
        =====================================================
        |               1. Pessoa Física                    |
        |               2. Pessoa Jurídica                  |
        |               0. Encerrar Sistema                 |
        =====================================================
";
        return Titulo;
    }

    public override void Apresentacao()
    {
        Console.Clear();
        this.Titulo = DefinirTitulo();
        Console.Write(this.Titulo);
        var OpcaoSelecionada = Escolha.SelecionarOpcao();
        this.OpcaoSelecionada = OpcaoSelecionada;
        this.ExecutarOpcaoSelecionada();
    }

    public override void ExecutarOpcaoSelecionada()
    {
        switch(this.OpcaoSelecionada.Key)
        {
            case ConsoleKey.D0:
                Sistema.Encerrar();
                break;
            case ConsoleKey.D1:
                new MenuPessoaFisica().Apresentacao();
                break;
            case ConsoleKey.D2:
                new MenuPessoaJuridica().Apresentacao();
                break;

            default:
                Sistema.GerarMensagem("Opção Inválida", "erro");
                new MenuPrincipal().Apresentacao();
                break;
        }
    }
}

