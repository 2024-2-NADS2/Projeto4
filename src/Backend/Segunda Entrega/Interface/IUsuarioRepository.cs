using ProjetoPI.Model;

namespace ProjetoPI.Interface
{
    public interface IUsuarioRepository
    {
        Usuario GetUsuarioByNome(string nome);
        Usuario GetUsuarioByEmailSenha(string email, string senha);
        void CriarUsuario(Usuario usuario);
    }
}
