using System;
using test.Models;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {   
            Endereco endereco = new Endereco("Rua teste", "555555", "centro", "123", "Jampa");
            Pessoa pessoa = new PessoaFisica("José", 100, endereco, "12345678900", "9783661");
            Agencia agencia = new Agencia(1, endereco);
            Conta conta = new Conta(1, "123456", agencia, pessoa);
            conta.Depositar(100);
            conta.Sacar(50);
            conta.ExibeExtrato();
        }
    }
}
