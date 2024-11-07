using ProjetoPI.Interface;
using ProjetoPI.Model;

namespace ProjetoPI.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool ValidarLogin(string email, string senha)
        {
            var usuario = _usuarioRepository.GetUsuarioByEmailSenha(email, senha);
            return usuario != null; // Retorna verdadeiro se o usuário foi encontrado
        }


        public void CadastrarUsuario(Usuario usuario)
        {
            _usuarioRepository.AdicionarUsuario(usuario);
        }

        public List<Usuario> ObterTodosUsuarios()
        {
            return _usuarioRepository.GetAllUsuarios();
        }
        public Usuario GetUsuarioByEmailSenha(string email, string senha)
        {
            return _usuarioRepository.GetUsuarioByEmailSenha(email, senha);
        }


    }
}