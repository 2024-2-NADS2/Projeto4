using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;  // Importando o namespace para ILogger
using MySql.Data.MySqlClient;
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
        private readonly TelemetryClient _telemetryClient;
        private readonly ILogger<UsuarioController> _logger; // Adicionando o logger

        // Construtor atualizado com o ILogger
        public UsuarioController(
            IUsuarioService usuarioService,
            IUsuarioRepository usuarioRepository,
            IDoadorRepository doadorRepository,
            IOngRepository ongRepository,
            TelemetryClient telemetryClient,
            ILogger<UsuarioController> logger)
        {
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
            _doadorRepository = doadorRepository; // Inicializa o repositório de doadores
            _ongRepository = ongRepository;       // Inicializa o repositório de ONGs
            _telemetryClient = telemetryClient;
            _logger = logger;  // Inicializa o logger
        }
        [HttpGet("teste-conexao")]
        public IActionResult TestarConexao()
        {
            try
            {
                using (var connection = new MySqlConnection("Server=sypbancodedados.mysql.database.azure.com;Database=testeazure;User=admin_syp;Password=Syp12345;SslMode=Required;AllowPublicKeyRetrieval=True;"))
                {
                    connection.Open();
                    return Ok("Conexão bem-sucedida!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro: {ex.Message}");
            }
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
            try
            {
                if (novaOng == null)
                {
                    return BadRequest("Dados inválidos.");
                }

                if (string.IsNullOrEmpty(novaOng.Nome) ||
                    string.IsNullOrEmpty(novaOng.Email) ||
                    string.IsNullOrEmpty(novaOng.Senha) ||
                    string.IsNullOrEmpty(novaOng.Cnpj) ||
                    string.IsNullOrEmpty(novaOng.Endereco))
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
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);  // Registra a exceção no Application Insights
                _logger.LogError($"Erro ao cadastrar ONG: {ex.Message}", ex);  // Usando o logger para registrar o erro
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

        [HttpGet("quantidade")]
        public IActionResult GetQuantidadeUsuarios()
        {
            try
            {
                int quantidade = _usuarioRepository.GetQuantidadeUsuarios(); // Método no repositório
                return Ok(new { Quantidade = quantidade });
            }
            catch (Exception ex)
            {
                _telemetryClient.TrackException(ex);  // Registra a exceção no Application Insights
                _logger.LogError($"Erro ao obter quantidade de usuários: {ex.Message}", ex);  // Usando o logger para registrar o erro
                return StatusCode(500, "Erro interno no servidor.");
            }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioDTO usuarioCadastrado)
        {
            try
            {
                if (usuarioCadastrado == null || string.IsNullOrEmpty(usuarioCadastrado.Email) || string.IsNullOrEmpty(usuarioCadastrado.Senha))
                {
                    return BadRequest(new { message = "Email e senha são obrigatórios." });
                }

                var usuario = _usuarioRepository.GetUsuarioByEmail(usuarioCadastrado.Email);
                if (usuario != null && usuario.Senha == usuarioCadastrado.Senha)
                {
                    // Armazenando dados do usuário na sessão
                    HttpContext.Session.SetInt32("UserId", usuario.IdUsuario);
                    HttpContext.Session.SetString("UserName", usuario.Nome);
                    HttpContext.Session.SetString("UserEmail", usuario.Email);

                    // Retornando o nome do usuário junto com o tipo
                    return Ok(new
                    {
                        message = "Login bem-sucedido!",
                        tipoUsuario = usuario.TipoUsuario,
                        userName = usuario.Nome // Retornando o nome do usuário
                    });
                }

                return Unauthorized(new { message = "Email ou senha inválidos." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao fazer login: {ex.Message}", ex);
                return StatusCode(500, new { message = "Erro interno no servidor." });
            }
        }



        [HttpGet("get-user-id")]
        public IActionResult GetUserId()
        {
            try
            {
                // Obtendo o ID do usuário da sessão
                var usuarioId = HttpContext.Session.GetInt32("UserId");

                if (usuarioId == null)
                {
                    return Unauthorized("Usuário não está logado.");
                }

                return Ok(new { UserId = usuarioId });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao obter ID do usuário: {ex.Message}", ex);
                return StatusCode(500, "Erro interno no servidor.");
            }
        }

    }
}
