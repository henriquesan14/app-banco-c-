namespace test.Models
{
    public class PessoaJuridica : Pessoa
    {
        public PessoaJuridica(string nome, decimal renda, Endereco endereco, string cnpj) : base(nome, renda, endereco)
        {
            this.Cnpj = cnpj;
        }

        public string Cnpj { get; set; }
    }
}