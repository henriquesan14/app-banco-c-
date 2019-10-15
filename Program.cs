using System;
using test.Exceptions;
using test.Models;

namespace test
{
    class Program
    {
        static Agencia Agencia =  new Agencia(1, new Endereco("Rua Agência", "55555-000", "centro", "123", "Jampa"));
        static int idConta = 0;
        static void Main(string[] args)
        {   
            MenuContas();
        }

        static void MenuContas(){
            int opc;
            do{
                Console.WriteLine("GERENCIAR CONTAS");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Cadastrar contas");
                Console.WriteLine("2. Listar contas");
                Console.WriteLine("3. Acessar uma conta");
                Console.WriteLine("4. Sair");
                Console.WriteLine("-------------------");
                opc = int.Parse(Console.ReadLine());
                switch(opc){
                    case 1:
                        CadastrarConta();
                        break;
                    case 2:
                        Agencia.ExibeContas();
                        break;
                    case 3:
                        AcessarConta();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }while(opc != 4);
        }

        static void MenuOperacoes(Conta conta){
            int opc;
            do{
                Console.WriteLine("GERENCIAR CONTA Nº " + conta.Numero);
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Saque");
                Console.WriteLine("2. Depósito");
                Console.WriteLine("3. Transferência");
                Console.WriteLine("4. Extrato");
                Console.WriteLine("5. Sair");
                Console.WriteLine("-------------------");
                opc = int.Parse(Console.ReadLine());
                switch(opc){
                    case 1:
                        Console.WriteLine("Informe o valor do saque: ");
                        decimal valorSaque = decimal.Parse(Console.ReadLine());
                        try{
                            conta.Sacar(valorSaque);
                            Console.WriteLine("Saque realizado!");
                        }catch(Exception e){
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Informe o valor do depósito: ");
                        decimal valorDeposito = decimal.Parse(Console.ReadLine());
                        try{
                            conta.Depositar(valorDeposito);
                            Console.WriteLine("Depósito realizado!");
                        }catch(Exception e){
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        Console.WriteLine("Informe o valor da transferência: ");
                        decimal valorTransferencia = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Informe o número da conta destino: ");
                        int numeroContaDestino = int.Parse(Console.ReadLine());
                        try{
                            conta.Transferir(valorTransferencia, numeroContaDestino);
                            Console.WriteLine("Transferência realizada!");
                        }catch(Exception e){
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 4:
                        conta.ExibeExtrato();
                        MenuOperacoes(conta);
                        break;
                    case 5:
                        MenuContas();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }while(opc != 4);
        }

        static Pessoa CadastrarPessoa(){
            Console.WriteLine("Informe seu nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe sua renda: ");
            decimal renda = decimal.Parse(Console.ReadLine());
            Console.WriteLine("ENDEREÇO");
            Console.WriteLine("Informe a rua: ");
            string rua = Console.ReadLine();
            Console.WriteLine("Informe o  número: ");
            string numero = Console.ReadLine();
            Console.WriteLine("Informe o  bairro: ");
            string bairro = Console.ReadLine();
            Console.WriteLine("Informe o  CEP: ");
            string cep = Console.ReadLine();
            Console.WriteLine("Informe a cidade: ");
            string cidade = Console.ReadLine();
            Console.WriteLine("Informe 1 para Pessoa Física");
            Console.WriteLine("Informe 2 para Pessoa Jurídica");
            int tipoPessoa = int.Parse(Console.ReadLine());
            if(tipoPessoa == 1){
                Console.WriteLine("Informe o CPF: ");
                string cpf = Console.ReadLine();
                Console.WriteLine("Informe o RG: ");
                string rg = Console.ReadLine();
                return new PessoaFisica(nome, renda, 
                new Endereco(rua, cep, bairro, numero, cidade), cpf, rg);
            }
            Console.WriteLine("Informe o CNPJ: ");
            string cnpj = Console.ReadLine();
            return new PessoaJuridica(nome, renda, 
                new Endereco(rua, cep, bairro, numero, cidade), cnpj);
        }

        static void CadastrarConta(){
            Pessoa pessoa = CadastrarPessoa();
            Console.WriteLine("Informe uma  senha para sua conta: ");
            string senha = Console.ReadLine();
            Conta conta = new Conta(idConta++, senha, Agencia, pessoa);
            Agencia.CadastrarConta(conta);
            Console.WriteLine("Conta Cadastrada!");
        } 

        static void AcessarConta(){
            if(Agencia.Contas.Count > 0){
                Console.WriteLine("Informe o número da conta: ");
                int numero = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe a senha da conta: ");
                string senha = Console.ReadLine();
                try{
                    Conta conta = Agencia.AcessarConta(numero, senha);
                    MenuOperacoes(conta);
                }catch(Exception e){
                    Console.WriteLine(e.Message);
                }
                return;
            }
            Console.WriteLine("Essa Agência não possui contas");
        }
    }
}
