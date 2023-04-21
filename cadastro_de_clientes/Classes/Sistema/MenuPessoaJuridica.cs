using System;
namespace cadastro_de_clientes.Classes.Sistema
{
	public class MenuPessoaJuridica : Menu
	{
        public MenuPessoaJuridica()
        {
            string pastaClientes = "Clientes/PessoaJuridica";
            if (!Directory.Exists(pastaClientes))
            {
                Directory.CreateDirectory(pastaClientes);
            }
        }
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
|               3. Exportar (csv)                   |
|               9. Voltar                           |
|               0. Encerrar Sistema                 |
=====================================================
";
            return Titulo;
        }
        public override void ExecutarOpcaoSelecionada()
        {
            switch (this.OpcaoSelecionada.Key)
            {
                case ConsoleKey.D1:
                    this.NovoCadastro();
                    break;
                case ConsoleKey.D2:
                    this.ListarTodos();
                    break;
                case ConsoleKey.D3:
                    this.ExportarCSV();
                    break;
                case ConsoleKey.D9:
                    Console.Clear();
                    new Sistema();
                    break;
                default:
                    Sistema.GerarMensagem("Opção Inválida", "erro");
                    new MenuPessoaJuridica();
                    break;
            }
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
        private void NovoCadastro()
        {
            Console.Clear();
            Endereco EnderecoDoCliente = AdicionarInformacoesDeEndereco();
            Console.Clear();
            PessoaJuridica Cliente = AdicionarInformacoesDeCliente(EnderecoDoCliente);
            Console.Write(Cliente);
            this.ClientesPessoaJuridica.Add(Cliente);
            string caminhoBase = AppDomain.CurrentDomain.BaseDirectory;
            string caminhoPasta = "Clientes/PessoaJuridica/";
            string nomeArquivo = $"{Cliente.Nome}.txt";
            string caminhoCompleto = Path.Combine(caminhoBase, caminhoPasta, nomeArquivo);

            using (StreamWriter Sw = new StreamWriter(caminhoCompleto))
            {
                Sw.Write($"{Cliente}");
            }
            this.Apresentacao();
        }
        private void ListarTodos()
        {
            Console.Clear();
            string pasta = "Clientes/PessoaJuridica";
            if (Directory.Exists(pasta))
            {
                string[] arquivos = Directory.GetFiles(pasta);

                if (arquivos.Length > 0)
                {
                    Console.WriteLine("Selecione o arquivo que deseja visualizar:");

                    for (int i = 0; i < arquivos.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {Path.GetFileName(arquivos[i])}");
                    }

                    int opcao = int.Parse(Console.ReadLine());

                    string nomeDoArquivo = arquivos[opcao - 1];

                    // código para visualizar o arquivo selecionado
                    //string caminhoCompleto = @"Clientes/PessoaJuridica/" + nomeDoArquivo;
                    string caminhoCompleto = Path.Combine(nomeDoArquivo);
                    Console.WriteLine(caminhoCompleto);
                    if (File.Exists(caminhoCompleto))
                    {
                        using (StreamReader sr = new StreamReader(caminhoCompleto))
                        {
                            string linha;
                            while ((linha = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(linha);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Arquivo {nomeDoArquivo} não encontrado.");
                    }
                }
                else
                {
                    Console.WriteLine("Não há arquivos salvos na pasta.");
                }
            }
            else
            {
                Console.WriteLine("A pasta não existe.");
            }
            Console.WriteLine("Pressione o número 9 para retornar");
            ConsoleKeyInfo Retornar = Escolha.SelecionarOpcao();
            if (Retornar.Key == ConsoleKey.D9)
            {
                Console.Clear();
                this.Apresentacao();
            }
        }
        private Endereco AdicionarInformacoesDeEndereco()
        {
            bool IsLogradouroPreenchido = false;
            bool IsBairroPreenchido = false;
            bool IsAdicionarMaisInfoEndereco = false;
            bool IsConcluido = false;
            string? Bairro;
            string? Logradouro;
            do
            {
                Console.Clear();
                Console.WriteLine("Digite o logradouro do cliente e pressione Enter:");
                Logradouro = Console.ReadLine();
                if (Sistema.VerificarPreenchimentoEmTexto(Logradouro))
                {
                    IsLogradouroPreenchido = true;
                }
                else
                {
                    Sistema.GerarMensagem("O logradouro precisa ser preenchido", "erro");
                }

            } while (!IsLogradouroPreenchido);
            do
            {
                Console.Clear();
                Console.WriteLine("Digite o bairro que o cliente e pressione Enter:");
                Bairro = Console.ReadLine();
                if (Sistema.VerificarPreenchimentoEmTexto(Bairro))
                {
                    IsBairroPreenchido = true;
                }
                else
                {
                    Sistema.GerarMensagem("O bairro precisa ser preenchido", "erro");
                }
            } while (IsBairroPreenchido == false);

            Endereco EnderecoDoCliente = Endereco.NovoEndereco(Logradouro, Bairro);
            do
            {
                Console.Clear();
                Console.WriteLine("Deseja Adicionar Mais Informações do Endereço? Digite S para Sim ou N para Não");
                ConsoleKeyInfo RespostaUsuario = Escolha.SelecionarOpcao();
                switch (RespostaUsuario.Key)
                {
                    case ConsoleKey.N:
                        IsAdicionarMaisInfoEndereco = true;
                        break;
                    case ConsoleKey.S:
                        AdicionarMaisInformacoesDeEndereco(EnderecoDoCliente);
                        IsAdicionarMaisInfoEndereco = true;
                        break;
                    default:
                        Sistema.GerarMensagem("Opção Inválida, Digite S para Sim ou N para Não", "erro");
                        continue;
                }
            }
            while (!IsAdicionarMaisInfoEndereco);

            do
            {
                Console.Clear();
                Console.WriteLine("Por favor, confirme as informações de Endereço, Digite S para confirmar ou N para refazer:");
                Console.WriteLine(EnderecoDoCliente);
                ConsoleKeyInfo EscolhaDoUsuario = Escolha.SelecionarOpcao();
                switch (EscolhaDoUsuario.Key)
                {
                    case ConsoleKey.N:
                        AdicionarInformacoesDeEndereco();
                        break;
                    case ConsoleKey.S:
                        IsConcluido = true;
                        break;
                    default:
                        Sistema.GerarMensagem("Opção inválida.", "erro");
                        break;
                }

            } while (!IsConcluido);
            Sistema.GerarMensagem($@"
Informações do Endereço Concluídas:
{EnderecoDoCliente}
", "sucesso", 3000);
            return EnderecoDoCliente;
        }
        private void AdicionarMaisInformacoesDeEndereco(Endereco Endereco)
        {
            Console.Clear();
            Console.WriteLine("Por favor, digite o nome da Cidade:");
            string? Cidade = Console.ReadLine();
            if (Sistema.VerificarPreenchimentoEmTexto(Cidade)) Endereco.AdicionarCidade(Cidade);
            Console.Clear();
            Console.WriteLine("Por favor, digite o nome do Estado:");
            string? Estado = Console.ReadLine();
            if (Sistema.VerificarPreenchimentoEmTexto(Estado)) Endereco.AdicionarEstado(Estado);
            Console.Clear();
            Console.WriteLine("O Endereço é Comercial? Digite S para Sim ou digite qualquer outra tecla para continuar");
            ConsoleKeyInfo EscolhaDoUsuario = Escolha.SelecionarOpcao();
            if (EscolhaDoUsuario.Key == ConsoleKey.S)
            {
                Endereco.DefinirEnderecoComoComercial();
            }
        }
        private PessoaJuridica AdicionarInformacoesDeCliente(Endereco Endereco)
        {
            string? Nome;
            bool IsNomePreenchido = false;
            bool IsAdicionarMaisInfoCliente = false;
            bool IsRendimentoPreenhido = false;
            bool IsConcluido = false;
            do
            {
                Console.WriteLine("Digite o nome do cliente e pressione Enter:");
                Nome = Console.ReadLine();
                if (Sistema.VerificarPreenchimentoEmTexto(Nome))
                {
                    IsNomePreenchido = true;
                }
                else
                {
                    Sistema.GerarMensagem("O nome precisa ser preenchido", "erro");
                }
            }
            while (IsNomePreenchido == false);
            PessoaJuridica Cliente = new PessoaJuridica(Nome, Endereco);
            do
            {
                Console.Clear();
                Console.WriteLine("Deseja Adicionar Mais Informações do Cliente? Digite S para Sim ou N para Não");
                ConsoleKeyInfo RespostaUsuario = Escolha.SelecionarOpcao();
                switch (RespostaUsuario.Key)
                {
                    case ConsoleKey.N:
                        IsAdicionarMaisInfoCliente = true;
                        break;
                    case ConsoleKey.S:
                        AdicionarMaisInformacoesDoCliente(Cliente);
                        IsAdicionarMaisInfoCliente = true;
                        break;
                    default:
                        Sistema.GerarMensagem("Opção Inválida, Digite S para Sim ou N para Não", "erro");
                        continue;
                }
            }
            while (!IsAdicionarMaisInfoCliente);
            do
            {
                Console.Clear();
                Console.WriteLine("Gostaria de adicionar o Rendimento do Cliente? ");
                ConsoleKeyInfo EscolhaDoUsuario = Escolha.SelecionarOpcao();
                switch (EscolhaDoUsuario.Key)
                {
                    case ConsoleKey.N:
                        IsRendimentoPreenhido = true;
                        break;
                    case ConsoleKey.S:
                        this.AdicionarRendimentoDoCliente(Cliente);
                        IsRendimentoPreenhido = true;
                        break;
                    default:
                        Sistema.GerarMensagem("Opção inválida.", "erro");
                        break;
                }
            } while (!IsRendimentoPreenhido);
            do
            {
                Console.Clear();
                Console.WriteLine("Por favor, confirme as informações de Endereço, Digite S para confirmar ou N para refazer:");
                Console.WriteLine(Cliente);
                ConsoleKeyInfo EscolhaDoUsuario = Escolha.SelecionarOpcao();
                switch (EscolhaDoUsuario.Key)
                {
                    case ConsoleKey.N:
                        AdicionarInformacoesDeEndereco();
                        break;
                    case ConsoleKey.S:
                        IsConcluido = true;
                        break;
                    default:
                        Sistema.GerarMensagem("Opção inválida.", "erro");
                        break;
                }

            } while (!IsConcluido);
            Console.Clear();
            Sistema.GerarMensagem($@"
Informações do Endereço Concluídas:
{Cliente}
", "sucesso", 3000);

            return Cliente;
        }
        private void AdicionarMaisInformacoesDoCliente(PessoaJuridica Cliente)
        {
            bool isCnpjPreenchido = false;
            bool isRazaoSocialPreenchida = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Por favor, digite o CNPJ do Cliente: Ex.: 00.000.000/0000-00");
                string? Cnpj = Console.ReadLine();
                if (Sistema.VerificarPreenchimentoEmTexto(Cnpj))
                {
                    if (Cliente.ValidarCnpj(Cnpj))
                    {
                        Cliente.adicionarCnpj(Cnpj);
                        isCnpjPreenchido = true;
                    }
                    else
                    {
                        Sistema.GerarMensagem("Cnpj Inválido, por favor digite novamente", "erro");
                    }
                }
            } while (!isCnpjPreenchido);

            do
            {
                Console.Clear();
                Console.WriteLine("Por favor, digite a razão social da empresa");
                string? RazaoSocial = Console.ReadLine();
                if (Sistema.VerificarPreenchimentoEmTexto(RazaoSocial))
                {
                    Cliente.AdicionarRazaoSocial(RazaoSocial);
                    isRazaoSocialPreenchida = true;
                }
            } while (!isRazaoSocialPreenchida);
        }
        private void AdicionarRendimentoDoCliente(PessoaJuridica Cliente)
        {
            Console.Clear();
            Console.WriteLine("Por favor, digite o Rendimento do Cliente e tecle Enter para confirmar: ");
            string? RendimentoInformado = Console.ReadLine();
            if (RendimentoInformado != null)
            {
                double Rendimento = double.Parse(RendimentoInformado);
                Cliente.AdicionaRendimento(Rendimento);
            }

        }
        private void ExportarCSV()
        {
            // Obtém o diretório em que o programa está sendo executado
            string diretorioAtual = Directory.GetCurrentDirectory();

            // Define o diretório de origem dos arquivos .txt
            string diretorioOrigem = Path.Combine(diretorioAtual, "Clientes/PessoaJuridica");
            Console.WriteLine(diretorioOrigem);
            // Chama o método Exportar da classe ExportadorCSV para converter os arquivos .txt para .csv
            ExportadorCSV.Exportar(diretorioOrigem);
            Console.WriteLine("Arquivo exportado com sucesso");
            Thread.Sleep(2000);
            Console.Clear();
            this.Apresentacao();
        }
    }
}


