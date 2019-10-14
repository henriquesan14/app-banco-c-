using System;

namespace test.Models
{
    public class Movimento
    {
        public Movimento(int tipo, decimal valorMovimento, Conta conta)
        {
            this.Tipo = tipo;
            this.ValorMovimento = valorMovimento;
            this.Conta = conta;
        }
        public int Tipo { get; set; }
        public DateTime DataHora { get; set; }
        public decimal ValorMovimento { get; set; }
        public Conta Conta { get; set; }
    }
}