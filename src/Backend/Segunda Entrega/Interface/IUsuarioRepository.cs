using ProjetoPI.Model;

namespace ProjetoPI.Interface
{
    public interface IUsuarioRepository
    {
        Usuario GetUsuarioByEmail(string email);
        Task AdicionarUsuario(Usuario usuario);
        List<Usuario> GetAllUsuarios();
        Usuario GetUsuarioByEmailSenha(string email, string senha);
        Usuario GetUsuarioById(int id);
        int GetQuantidadeUsuarios(); 
    }

}
