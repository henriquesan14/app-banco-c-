using System;
using System.Collections.Generic;

namespace test.Models
{
    public class Conta
    {
        public Conta(int numero, string senha, Agencia agencia)
        {
            this.Numero = numero;
            this.Senha = senha;
            this.Agencia = agencia;
            this.DataAbertura = DateTime.Now;
            this.Ativo = true;
            this.Movimentos = new List<Movimento>();
        }
        public int Numero { get; set; }
        public DateTime DataAbertura { get; set; }
        public bool Ativo { get; set; }

        public string Senha { get; set; }
        public decimal Saldo { get; set; }

        public Agencia Agencia { get; set; }

        public List<Movimento> Movimentos { get; set; }
    }
}