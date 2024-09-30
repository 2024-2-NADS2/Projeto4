namespace ProjetoPI.Model
{
    public class Usuario
    {
        protected string Nome;
        protected string Email;
        protected string Senha;
        
        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public string GetNome()
        {
            return Nome;
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public string GetEmail()
        {
            return Email;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public string GetSenha()
        {
            return Senha;
        }

        public void SetSenha(string senha)
        {
            Senha = senha;
        }
    }
}
