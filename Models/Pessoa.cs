using System.Collections.Generic;

namespace test.Models
{
    public class Pessoa
    {
        public Pessoa(string nome, decimal renda, Endereco endereco)
        {
            this.Nome = nome;
            this.RendaPessoa = renda;
            this.Endereco = endereco;
            this.Ativo = true;
            this.Contas = new List<Conta>();
        }
        public string Nome { get; set; }
        public decimal RendaPessoa { get; set; }
        public bool Ativo { get; set; }

        public List<Conta> Contas { get; set; }
        public Endereco Endereco { get; set; }
    }
}