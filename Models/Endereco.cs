using System.Collections.Generic;

namespace test.Models
{
    public class Endereco
    {
        public Endereco(string rua, string cep, string bairro, string numero, string cidade)
        {
            this.Rua = rua;
            this.Cep = cep;
            this.Bairro = bairro;
            this.Numero = numero;
            this.Cidade = cidade;
            this.Agencias = new List<Agencia>();
            this.Pessoas = new List<Pessoa>();
        }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public List<Agencia> Agencias { get; set; }
        public List<Pessoa> Pessoas { get; set; }
    }
}