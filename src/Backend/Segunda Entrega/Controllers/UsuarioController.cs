using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPI.Interface;
using ProjetoPI.Model;

namespace ProjetoPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // Endpoint para login
        [HttpPost("login")]
        public IActionResult Login(string email, string senha)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
                {
                    return BadRequest("Email e senha são obrigatórios.");
                }

                var loginValido = _usuarioService.ValidarLogin(email, senha);

                if (loginValido)
                {
                    return Ok("Login bem-sucedido.");
                }
                else
                {
                    return Unauthorized("Usuário ou senha incorretos.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro no servidor.");
            }
        }

        [HttpPost("criar")]
        public IActionResult CriarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario.GetEmail()) || string.IsNullOrEmpty(usuario.GetSenha()))
                {
                    return BadRequest("Email e senha são obrigatórios.");
                }

                _usuarioService.CriarUsuario(usuario);
                return Ok("Usuário criado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro no servidor.");
            }
        }
    }
}
