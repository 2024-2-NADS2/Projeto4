using ProjetoPI.Model;

namespace ProjetoPI.Model
{
    public class Empresa : Usuario
    {

        private string CNPJ;
        public Empresa(string nome, string email, string senha, string cpf)
            : base(nome, email, senha)
        {
            CNPJ = cpf;
        }
        public string GetCNPJ()
        {
            return CNPJ;
        }

        public void SetCNPJ(string cnpj)
        {
            CNPJ = cnpj;
        }
    }
}
