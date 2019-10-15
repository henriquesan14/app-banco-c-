using System;
using test.Exceptions;
using test.Models;

namespace test
{
    class Program
    {
        static Agencia Agencia =  new Agencia(1, new Endereco("Rua Agência", "55555-000", "centro", "123", "Jampa"));
        static int numeroSequencialContas = 1;
        static void Main(string[] args)
        {   
            MenuContas();
        }

        static void MenuContas(){
            int opc;
            string input;
            bool isInt;
            do{
                Console.WriteLine("-------------------");
                Console.WriteLine("GERENCIAR CONTAS");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Cadastrar contas");
                Console.WriteLine("2. Listar contas");
                Console.WriteLine("3. Acessar uma conta");
                Console.WriteLine("4. Sair");
                Console.WriteLine("-------------------");
                input = Console.ReadLine();
                isInt = int.TryParse(input, out opc);
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
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Console.WriteLine("-------------------");
                        break;
                }
            }while(opc != 4 || !isInt);
        }

        static void MenuOperacoes(Conta conta){
            int opc;
            bool isInt;
            string input;
            do{
                Console.WriteLine("GERENCIAR CONTA Nº " + conta.Numero);
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Saque");
                Console.WriteLine("2. Depósito");
                Console.WriteLine("3. Transferência");
                Console.WriteLine("4. Extrato");
                Console.WriteLine("5. Exibir Saldo");
                Console.WriteLine("6. Sair");
                Console.WriteLine("-------------------");
                input = Console.ReadLine();
                isInt = int.TryParse(input, out opc);
                bool isDecimal;
                decimal valor;
                switch(opc){
                    case 1:
                        do{
                            Console.WriteLine("Informe o valor do saque: ");
                            isDecimal = decimal.TryParse(Console.ReadLine(), out valor);
                            if(!isDecimal)
                                Console.WriteLine("Valor inválido!");
                        }while(!isDecimal);
                        try{
                            conta.Sacar(valor);
                            Console.WriteLine("Saque realizado!");
                            Console.WriteLine("-------------------");
                        }catch(Exception e){
                            Console.WriteLine(e.Message);
                            Console.WriteLine("-------------------------");
                        }
                        break;
                    case 2:
                        do{
                            Console.WriteLine("Informe o valor do depósito: ");
                            Console.WriteLine("-------------------------");
                            isDecimal = decimal.TryParse(Console.ReadLine(), out valor);
                            if(!isDecimal)
                                Console.WriteLine("Valor inválido!");
                        }while(!isDecimal);
                        try{
                            conta.Depositar(valor);
                            Console.WriteLine("Depósito realizado!");
                            Console.WriteLine("-------------------------");
                        }catch(Exception e){
                            Console.WriteLine(e.Message);
                            Console.WriteLine("-------------------------");
                        }
                        break;
                    case 3:
                        do{
                            Console.WriteLine("Informe o valor da transferência: ");
                            Console.WriteLine("-------------------------");
                            isDecimal = decimal.TryParse(Console.ReadLine(), out valor);
                            if(!isDecimal)
                                Console.WriteLine("Valor inválido!");
                        }while(!isDecimal);
                            int numeroContaDestino;
                            bool isInteiro;
                            do{
                                Console.WriteLine("Informe o número da conta destino: ");
                                Console.WriteLine("-------------------------");
                                isInteiro = int.TryParse(Console.ReadLine(), out numeroContaDestino);
                                if(!isInteiro)
                                Console.WriteLine("Valor inválido!");
                            }while(!isInteiro);
                        try{
                            conta.Transferir(valor, numeroContaDestino);
                            Console.WriteLine("Transferência realizada!");
                            Console.WriteLine("-------------------------");
                        }catch(Exception e){
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 4:
                        conta.ExibeExtrato();
                        MenuOperacoes(conta);
                        break;
                    case 5:
                        conta.ExibeSaldo();
                        break;
                    case 6:
                        MenuContas();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        Console.WriteLine("-------------------------");
                        break;
                }
            }while(opc != 4 || !isInt);
        }

        static Pessoa CadastrarPessoa(){
            Console.WriteLine("Informe seu nome: ");
            Console.WriteLine("-------------------------");
            string nome = Console.ReadLine();
            decimal renda;
            string input;
            bool isDecimal;
            do{
                Console.WriteLine("Informe sua renda: ");
                input = Console.ReadLine();
                isDecimal = decimal.TryParse(input, out renda);
                if(!isDecimal)
                    Console.WriteLine("Valor inválido, renda deve ser caracteres númericos");
                    Console.WriteLine("-------------------------");
            }
            while(!isDecimal);
            Console.WriteLine("ENDEREÇO");
            Console.WriteLine("Informe a rua: ");
            Console.WriteLine("-------------------------");
            string rua = Console.ReadLine();
            Console.WriteLine("Informe o  número: ");
            Console.WriteLine("-------------------------");
            string numero = Console.ReadLine();
            Console.WriteLine("Informe o  bairro: ");
            Console.WriteLine("-------------------------");
            string bairro = Console.ReadLine();
            Console.WriteLine("Informe o  CEP: ");
            Console.WriteLine("-------------------------");
            string cep = Console.ReadLine();
            Console.WriteLine("Informe a cidade: ");
            Console.WriteLine("-------------------------");
            string cidade = Console.ReadLine();
            int tipoPessoa;
            string inputTipoPessoa;
            bool isInt;
            do{
                Console.WriteLine("Informe seu tipo Pessoa: ");
                Console.WriteLine("[1] Pessoa Física | [2] Pessoa Jurídica");
                Console.WriteLine("-------------------------");
                inputTipoPessoa = Console.ReadLine();
                isInt = int.TryParse(inputTipoPessoa, out tipoPessoa);
                if(!isInt)
                    Console.WriteLine("Valor inválido, tente novamente.");
                    Console.WriteLine("-------------------------");
            }while(!isInt);
            if(tipoPessoa == 1){
                Console.WriteLine("Informe o CPF: ");
                Console.WriteLine("-------------------------");
                string cpf = Console.ReadLine();
                Console.WriteLine("Informe o RG: ");
                Console.WriteLine("-------------------------");
                string rg = Console.ReadLine();
                return new PessoaFisica(nome, renda, 
                new Endereco(rua, cep, bairro, numero, cidade), cpf, rg);
            }
            Console.WriteLine("Informe o CNPJ: ");
            Console.WriteLine("-------------------------");
            string cnpj = Console.ReadLine();
            return new PessoaJuridica(nome, renda, 
                new Endereco(rua, cep, bairro, numero, cidade), cnpj);
        }

        static void CadastrarConta(){
            Pessoa pessoa = CadastrarPessoa();
            Console.WriteLine("Informe uma  senha para sua conta: ");
            Console.WriteLine("-------------------------");
            string senha = Console.ReadLine();
            Conta conta = new Conta(numeroSequencialContas++, senha, Agencia, pessoa);
            Agencia.CadastrarConta(conta);
            Console.WriteLine("Conta Cadastrada!");
            Console.WriteLine("-------------------------");
        } 

        static void AcessarConta(){
            if(Agencia.Contas.Count > 0){
                Console.WriteLine("Informe o número da conta: ");
                Console.WriteLine("-------------------------");
                int numero = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe a senha da conta: ");
                Console.WriteLine("-------------------------");
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
            Console.WriteLine("-------------------------");
        }
    }
}
