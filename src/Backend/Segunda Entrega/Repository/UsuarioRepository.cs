using ProjetoPI.Interface;
using ProjetoPI.Model;

namespace ProjetoPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private List<Usuario> usuarios = new List<Usuario>(); // Lista para simular o banco de dados


        public Usuario GetUsuarioByNome(string nome)
        {
            if (nome == "usuario da silva")
            {
            return usuarios.FirstOrDefault(u => u.GetNome() == nome);
               
            }
            return null;
        }

        public Usuario GetUsuarioByEmailSenha(string email, string senha)
        {
            if (email == "teste@teste.com" && senha == "1232")
            {
                return new Usuario(email, senha);
            }
            return null;
        }


      

        //public Usuario GetUsuarioByEmailSenha(string email, string senha)
        //{
        //    // Busca o usuário pelo email e senha na lista simulada
        //    return usuarios.FirstOrDefault(u => u.GetEmail() == email && u.GetSenha() == senha);
        //}

        public void CriarUsuario(Usuario usuario)
        {
            // Adiciona o usuário à lista simulada
            usuarios.Add(usuario);
        }
    }
}
