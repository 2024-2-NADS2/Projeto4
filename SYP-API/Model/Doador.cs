using ProjetoPI.Model;

namespace ProjetoPI.Model
{
    public class Doador : Usuario
    {
        private string CPF;
        private List<Produto> ProdutosParaDoar;

        public Doador(string nome, string email, string senha, string cpf)
            : base(nome, email, senha)
        {
            CPF = cpf;
             ProdutosParaDoar = new List<Produto>();
        }
        public string GetCPF()
        {
            return CPF;
        }

        public void SetCPF(string cpf)
        {
            CPF = cpf;
        }
    }
}
