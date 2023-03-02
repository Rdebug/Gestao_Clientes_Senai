using System;
using cadastro_de_clientes.Classes;
namespace CadastroDeClientes
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Gerar um endereço
            string logradouro = "Rua Guilherme Suassuna, 1894";
            string bairro = "São Caetano";
            Endereco endereco = Endereco.NovoEndereco(logradouro, bairro);
            endereco.DefinirEnderecoComoComercial();
            endereco.AdicionarCidade("São Paulo");
            endereco.AdicionarEstado("São Paulo");

            string nome = "Ramon Moura";
            DateTime dataNascimento = new DateTime(1990,02,23);

            PessoaFisica pessoaFisica = new PessoaFisica(nome, endereco);
            pessoaFisica.AdicionarCpf("928.192.042-09");
            pessoaFisica.AdicionarDataNascimento(dataNascimento);
            pessoaFisica.AdicionaRendimento(2000.0);
            
            PessoaJuridica pessoaJuridica = new PessoaJuridica(nome, endereco);
            pessoaJuridica.adicionarCnpj("01.028.928/0001-92");
            pessoaJuridica.AdicionarRazaoSocial("Moura Tecnologia");
            pessoaJuridica.AdicionaRendimento(5000.00);

            CalculadoraDeImpostos Calculadora = new CalculadoraDeImpostos();
            double ImpostoPessoaFisica = Calculadora.CalculaPessoaFisica(pessoaFisica.Rendimento);
            double ImpostoPessoaJuridica = Calculadora.CalculaPessoaJuridica(pessoaJuridica.Rendimento);
            Console.WriteLine(ImpostoPessoaFisica);
            Console.WriteLine(ImpostoPessoaJuridica);


        }
    }
}