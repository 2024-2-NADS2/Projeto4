using ProjetoPI.Model;

namespace ProjetoPI.Interface
{
    public interface IUsuarioService
    {
        bool ValidarLogin(string email, string senha);
        void CadastrarUsuario(Usuario usuario);
        //List<Usuario> GetAllUsuarios();
        Usuario GetUsuarioByEmailSenha(string email, string senha);


    }
}
