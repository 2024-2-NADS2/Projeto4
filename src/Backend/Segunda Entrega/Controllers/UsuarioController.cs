using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoPI.Data;
using ProjetoPI.DTO;
using ProjetoPI.Model;

namespace ProjetoPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
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

                // Simulação de verificação de usuário
                if (email == "usuario@exemplo.com" && senha == "123456")
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
                return null;
            }

        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult CadastrarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest("Usuário não pode ser nulo.");
            }
            // Criar um novo usuário a partir do DTO
            var novoUsuario = new Usuario(usuarioDTO);

            // Adicionar o novo usuário ao contexto
            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(CadastrarUsuario), new { id = novoUsuario.GetUser() }, novoUsuario);
        }
    }

}


