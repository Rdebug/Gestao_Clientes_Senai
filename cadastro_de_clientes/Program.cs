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
            
            PessoaJuridica pessoaJuridica = new PessoaJuridica(nome, endereco);
            pessoaJuridica.adicionarCnpj("01.028.928/0001-92");
            pessoaJuridica.AdicionarRazaoSocial("Moura Tecnologia");

            Console.WriteLine(pessoaFisica.DataNascimento);
            Console.WriteLine(pessoaJuridica);
        }
    }
}