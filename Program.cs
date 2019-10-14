﻿using System;
using test.Exceptions;
using test.Models;

namespace test
{
    class Program
    {
        static Agencia Agencia =  new Agencia(1, new Endereco("Rua Agência", "55555-000", "centro", "123", "Jampa"));
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
                Console.WriteLine("Informe o RG: ");
            return new PessoaJuridica(nome, renda, 
                new Endereco(rua, cep, bairro, numero, cidade), cnpj);
        }

        static void CadastrarConta(){
            Pessoa pessoa = CadastrarPessoa();
            Console.WriteLine("Informe uma  senha para sua conta: ");
            string senha = Console.ReadLine();
            Conta conta = new Conta(1, senha, Agencia, pessoa);
            Agencia.CadastrarConta(conta);
        } 
    }
}
