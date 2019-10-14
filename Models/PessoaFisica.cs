namespace test.Models
{
    public class PessoaFisica : Pessoa
    {
      public PessoaFisica(string nome, decimal renda, Endereco endereco, string cpf, string rg) : base(nome, renda, endereco)
      {
          this.Cpf = cpf;
          this.Rg = Rg;
      }  
      
      public string Cpf { get; set; }
      public string Rg { get; set; }
    }
}