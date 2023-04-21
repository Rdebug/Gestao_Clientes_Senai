using System;
namespace cadastro_de_clientes.Classes.Sistema
{
    public class MenuPessoaFisica : Menu
    {
        public MenuPessoaFisica()
        {
            string pastaClientes = "Clientes/PessoaFisica";
            if (!Directory.Exists(pastaClientes))
            {
                Directory.CreateDirectory(pastaClientes);
            }
        }
        public override string DefinirTitulo()
        {
            this.Titulo = $@"
            =====================================================
            |               Bem Vindo ao Sistema de             |
            |                Cadastro de Clientes               |
            |                                                   |
            =====================================================
            |                   Pessoa Física                   |
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
                    new MenuPessoaFisica();
                    break;
            }
        }
        private void NovoCadastro()
        {
            Console.Clear();
            Endereco EnderecoDoCliente = AdicionarInformacoesDeEndereco();
            Console.Clear();
            PessoaFisica Cliente = AdicionarInformacoesDeCliente(EnderecoDoCliente);
            this.ClientesPessoaFisica.Add(Cliente);
            string caminhoBase = AppDomain.CurrentDomain.BaseDirectory;
            string caminhoPasta = "Clientes/PessoaFisica/";
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
            string pasta = "Clientes/PessoaFisica";
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
                    //string caminhoCompleto = @"Clientes/PessoaFisica/" + nomeDoArquivo;
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


            //if (this.ClientesPessoaFisica.Count > 0)
            //{
            //    foreach (PessoaFisica Cliente in this.ClientesPessoaFisica)
            //    {
            //        Console.Write(Cliente);
            //        Console.WriteLine("\n---------------------------------------------------------------\n");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("\nNenhum Cliente Adicionado.");
            //}
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
            if(EscolhaDoUsuario.Key == ConsoleKey.S)
            {
                Endereco.DefinirEnderecoComoComercial();
            }
        }
        private PessoaFisica AdicionarInformacoesDeCliente(Endereco Endereco)
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
            PessoaFisica Cliente = new PessoaFisica(Nome, Endereco);
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
        private void AdicionarMaisInformacoesDoCliente(PessoaFisica Cliente)
        {
            bool IsCpfPreenchido = false;
            bool IsDataNascimentoPreenchido = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Por favor, digite o CPF do Cliente: Ex.: 000.000.000-00");
                string? Cpf = Console.ReadLine();
                if (Sistema.VerificarPreenchimentoEmTexto(Cpf))
                {
                    if (Cliente.ValidarCpf(Cpf))
                    {
                        Cliente.AdicionarCpf(Cpf);
                        IsCpfPreenchido = true;
                    }
                    else
                    {
                        Sistema.GerarMensagem("CPF Inválido, por favor digite novamente", "erro");
                    }
                }
            } while (!IsCpfPreenchido);

            do
            {
                Console.Clear();
                Console.WriteLine("Por favor, digite a data de nascimento: Ex.: 01/01/1990");
                string? DataNascimento = Console.ReadLine();
                if(Sistema.VerificarPreenchimentoEmTexto(DataNascimento))
                {
                    if (DateTime.TryParse(DataNascimento, out DateTime Data))
                    {
                        if(Cliente.ValidarDataNascimento(Data))
                        {
                            Cliente.AdicionarDataNascimento(Data);
                            IsDataNascimentoPreenchido = true;
                        }
                        else
                        {
                            Sistema.GerarMensagem("O Cliente deve ter no mínimo 18 anos.", "erro");
                        }
                    }
                }
            } while (!IsDataNascimentoPreenchido);
        }
        private void AdicionarRendimentoDoCliente (PessoaFisica Cliente)
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
            string diretorioOrigem = Path.Combine(diretorioAtual, "Clientes/PessoaFisica");
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

