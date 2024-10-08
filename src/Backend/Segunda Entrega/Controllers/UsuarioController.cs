using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // Endpoint para login
        [HttpPost("login")]
        public IActionResult Login(string email, string senha)
        {
            try
            {
                // Aqui você pode realizar a verificação do usuário
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
                {
                    return BadRequest("Email e senha são obrigatórios.");
                }

                // Simulação de verificação de usuário
                if (email == "usuario@exemplo.com" && senha == "123456")
                {
                    return Ok("Login bem-sucedido.");
                }
                else
                {
                    return Unauthorized("Usuário ou senha incorretos.");
                }
            } catch(Exception ex)
            {
                Console.WriteLine("Ocorreu um erro" + ex);
                return null;
            }
           
        }
    }
}
