using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPI.DTO;
using ProjetoPI.Interface;
using ProjetoPI.Model;
using ProjetoPI.Repository;
using System.Globalization;

namespace ProjetoPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository; // Repositório para usuários
        private readonly IDoadorRepository _doadorRepository;   // Repositório para doadores
        private readonly IOngRepository _ongRepository;         // Repositório para ONGs

        public UsuarioController(IUsuarioService usuarioService, IUsuarioRepository usuarioRepository, IDoadorRepository doadorRepository, IOngRepository ongRepository)
        {
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
            _doadorRepository = doadorRepository; // Inicializa o repositório de doadores
            _ongRepository = ongRepository;       // Inicializa o repositório de ONGs
        }

        [HttpPost("cadastrar-doador")]
        public IActionResult CadastrarDoador([FromBody] Doador novoDoador)
        {
            if (novoDoador == null)
            {
                return BadRequest("Dados inválidos.");
            }

            if (string.IsNullOrEmpty(novoDoador.Nome) ||
                string.IsNullOrEmpty(novoDoador.Email) ||
                string.IsNullOrEmpty(novoDoador.Senha) ||
                string.IsNullOrEmpty(novoDoador.Cpf) ||
                string.IsNullOrEmpty(novoDoador.Endereco) ||
                string.IsNullOrEmpty(novoDoador.DataNascimentoString)) // Aqui está a string preenchida pelo usuário
            {
                return BadRequest("Todos os campos são obrigatórios e devem ser preenchidos corretamente.");
            }

            // Tente converter a DataNascimentoString em DateTime
            if (!DateTime.TryParseExact(novoDoador.DataNascimentoString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNascimento))
            {
                return BadRequest("Data de nascimento deve estar no formato dd/MM/yyyy.");
            }

            novoDoador.DataNascimento = dataNascimento; // Atribua a data convertida

            // Verificar se o e-mail ou CPF já estão cadastrados
            var usuarioExistente = _usuarioRepository.GetUsuarioByEmail(novoDoador.Email);
            if (usuarioExistente != null)
            {
                return BadRequest("Este e-mail já está cadastrado.");
            }

            // Preencher DataCadastro com a data atual
            novoDoador.DataCadastro = DateTime.Now;

            // Persistir o novo doador no banco de dados
            _doadorRepository.AdicionarDoador(novoDoador); // Persistindo com o repositório de doadores

            return Ok("Doador cadastrado com sucesso!");
        }


        [HttpPost("cadastrar-ong")]
        public IActionResult CadastrarOng([FromBody] Ong novaOng)
        {
            if (novaOng == null)
            {
                return BadRequest("Dados inválidos.");
            }

            if (string.IsNullOrEmpty(novaOng.Nome) ||
                string.IsNullOrEmpty(novaOng.Email) ||
                string.IsNullOrEmpty(novaOng.Senha) ||
                string.IsNullOrEmpty(novaOng.Cnpj) ||
                string.IsNullOrEmpty(novaOng.Endereco) ||
                string.IsNullOrEmpty(novaOng.Telefone))
            {
                return BadRequest("Todos os campos são obrigatórios e devem ser preenchidos corretamente.");
            }

            // Verificar se o e-mail ou CNPJ já estão cadastrados
            var ongExistente = _ongRepository.GetOngByEmail(novaOng.Email);
            if (ongExistente != null)
            {
                return BadRequest("Este e-mail já está cadastrado.");
            }

            // Preencher DataCadastro com a data atual
            novaOng.DataCadastro = DateTime.Now;

            // Persistir a nova ONG no banco de dados
            _ongRepository.AdicionarOng(novaOng);

            return Ok("ONG cadastrada com sucesso!");
        }

        [HttpGet("quantidade")]
        public IActionResult GetQuantidadeUsuarios()
        {
            int quantidade = _usuarioRepository.GetQuantidadeUsuarios(); // Método no repositório
            return Ok(new { Quantidade = quantidade });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioDTO usuarioCadastrado)
        {
            if (usuarioCadastrado == null || string.IsNullOrEmpty(usuarioCadastrado.Email) || string.IsNullOrEmpty(usuarioCadastrado.Senha))
            {
                return BadRequest("Email e senha são obrigatórios.");
            }

            bool isValid = _usuarioService.ValidarLogin(usuarioCadastrado.Email, usuarioCadastrado.Senha);
            if (isValid)
            {
                return Ok("Login bem-sucedido!");
            }
            return Unauthorized("Email ou senha inválidos.");
        }
    }
}
