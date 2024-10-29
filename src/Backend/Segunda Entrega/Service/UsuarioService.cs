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
            return usuario != null;
        }
        public void CriarUsuario(Usuario usuario)
        {
            _usuarioRepository.CriarUsuario(usuario);
        }

    }
}
