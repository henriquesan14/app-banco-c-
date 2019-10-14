using System.Collections.Generic;

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
    }
}