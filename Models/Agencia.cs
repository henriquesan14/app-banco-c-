using System;
using System.Collections.Generic;
using test.Exceptions;

namespace test.Models
{
    public class Agencia
    {
        public Agencia(int numero, Endereco endereco)
        {
            this.Numero = Numero;
            this.Endereco = endereco;
            this.Contas = new List<Conta>();
        }
        public int Numero { get; set; }

        public List<Conta> Contas { get; set; }

        public Endereco Endereco { get; set; }


        public void CadastrarConta(Conta conta){
            this.Contas.Add(conta);
        }

        public Conta AcessarConta(int numero, string senha){
            if(this.Contas.Count > 0){
                if(numero <= 0)
                    throw new ValorInvalidoException("Número da conta inválido");
                foreach(Conta c in this.Contas){
                    if(c.Numero == numero){
                        if(ComparaSenha(senha, c.Senha)){
                            return c;
                        }
                        throw new SenhaInvalidaException("Senha Inválida");
                    }
                }
                throw new ContaNaoEncontradaException("Conta de número " + numero + " não foi encontrada");
            }
            return null;
        }

        public void ExibeContas(){
            if(this.Contas.Count > 0){
                foreach(Conta c in this.Contas){
                    Console.WriteLine("Conta Nº :" +c.Numero + " | Nome Pessoa: " + c.Pessoa.Nome + " | Saldo: " + c.Saldo);
                }
                return;
            }
            Console.WriteLine("Essa agência não possui contas");
        }

        private bool ComparaSenha(string senhaInformada, string senhaConta){
            return senhaConta.Equals(senhaInformada);
        }
    }
}