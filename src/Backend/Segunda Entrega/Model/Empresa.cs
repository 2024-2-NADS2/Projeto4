using ProjetoPI.Model;

namespace ProjetoPI.Model
{
    public class Empresa : Usuario
    {

        private string CNPJ;
        public Empresa(string nome, string email, string senha, string cnpj, string user)
            : base(nome, email, senha, user)
        {
            CNPJ = cnpj;
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
