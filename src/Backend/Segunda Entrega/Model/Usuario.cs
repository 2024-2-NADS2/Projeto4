using ProjetoPI.DTO;

namespace ProjetoPI.Model
{
    public class Usuario
    {
        public int Id { get; set; } // Chave primária
        protected string NomeCompleto;
        protected string Email;
        protected string Senha;
        protected string User;

        // Construtor que recebe um UsuarioDTO
        public Usuario(UsuarioDTO usuarioDTO)
        {
            NomeCompleto = usuarioDTO.Nome;
            Email = usuarioDTO.Email;
            Senha = usuarioDTO.Senha;
            User = usuarioDTO.User;
        }

        public Usuario()
        {

        }

        public string GetNome()
        {
            return NomeCompleto;
        }

        public void SetNome(string nome)
        {
            NomeCompleto = nome;
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

        public string GetUser()
        {
            return User;
        }

        public void SetUser(string user)
        {
            User = user;
        }
    }
}
