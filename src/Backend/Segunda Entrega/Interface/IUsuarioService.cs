using ProjetoPI.Model;

namespace ProjetoPI.Interface
{
    public interface IUsuarioService
    {
        bool ValidarLogin(string email, string senha);
        void CriarUsuario(Usuario usuario);

    }
}
