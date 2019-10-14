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
            this.Pessoa = Pessoa;
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
        }

        public void Depositar(decimal valor){
            if(valor <= 0)
                throw new ValorInvalidoException("Depósito deve ser maior que 0");
            this.Saldo += valor;
            Movimento movimento = new Movimento(TipoMovimento.DEPOSITO, valor, this);
        }

        
    }
}