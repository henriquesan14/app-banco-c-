using System;
using System.Collections.Generic;
using test.Exceptions;

namespace test.Models
{
    public class Conta
    {
        public Conta(int numero, string senha, Agencia agencia,  Pessoa pessoa)
        {
            this.Numero = numero;
            this.Senha = senha;
            this.Agencia = agencia;
            this.DataAbertura = DateTime.Now;
            this.Ativo = true;
            this.Saldo = decimal.Zero;
            this.Pessoa = pessoa;
            this.Movimentos = new List<Movimento>();
        }
        public int Numero { get; set; }
        public DateTime DataAbertura { get; set; }
        public bool Ativo { get; set; }

        public string Senha { get; set; }
        public decimal Saldo { get; set; }

        public Agencia Agencia { get; set; }

        public List<Movimento> Movimentos { get; set; }

        public Pessoa Pessoa { get; set; }

        public void Sacar(decimal valor){
            if(valor <= 0)
                throw new ValorInvalidoException("Saque deve ser maior que 0");
            if(valor > this.Saldo)
                throw new SaldoInsuficienteException("O Saldo é insuficiente");
            this.Saldo -= valor;
            Movimento movimento = new Movimento(TipoMovimento.SAQUE, valor, this);
            this.Movimentos.Add(movimento);
        }

        public void Depositar(decimal valor){
            if(valor <= 0)
                throw new ValorInvalidoException("Depósito deve ser maior que 0");
            this.Saldo += valor;
            Movimento movimento = new Movimento(TipoMovimento.DEPOSITO, valor, this);
            this.Movimentos.Add(movimento);
        }

        public void Transferir(decimal valor, int contaDestino){
            if(contaDestino <= 0)
                throw new ContaDestinoNaoInformadaException("Conta destino não informada");
            if(valor <= 0)
                throw new ValorInvalidoException("Transferencia deve ser maior que 0");
            if(valor > this.Saldo)
                throw new SaldoInsuficienteException("O Saldo é insuficiente");
            this.Saldo -= valor;
            Conta conta = this.BuscarConta(contaDestino);
            if(conta == null){
                throw new ContaNaoEncontradaException("Conta destino não encontrada");
            }
            conta.Depositar(valor);
            Movimento movimento = new Movimento(TipoMovimento.TRANSFERENCIA, valor, this);
            this.Movimentos.Add(movimento);
        }

        private Conta BuscarConta(int numero){
            foreach(Conta c in Agencia.Contas){
                if(c.Numero == numero){
                    return c;
                }
            }
             return null;
        }

        public void ExibeExtrato(){
            if(this.Movimentos.Count > 0){
                foreach(Movimento m in this.Movimentos){
                    Console.WriteLine(m.Tipo + " | Data/hora: " + m.DataHora + " | Valor Movimentado: " + m.ValorMovimento);
                }
                return;
            }
            Console.WriteLine("Conta não possui movimentos");
        }
    }
}