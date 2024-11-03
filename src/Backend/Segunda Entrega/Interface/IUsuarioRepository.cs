using ProjetoPI.Model;

namespace ProjetoPI.Interface
{
    public interface IUsuarioRepository
    {
        Usuario GetUsuarioByEmail(string email);
        void AdicionarUsuario(Usuario usuario);
        List<Usuario> GetAllUsuarios();
        Usuario GetUsuarioByEmailSenha(string email, string senha);
        int GetQuantidadeUsuarios(); // Adicione esta linha
    }

}
