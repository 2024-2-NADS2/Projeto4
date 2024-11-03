using ProjetoPI.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoPI.Model
{
    public class Usuario
    {
        [Key]
        private int idUsuario;
        private string nome;
        private string email;
        private string senha;
        private string endereco;
        private string telefone;
        private TipoUsuario tipoUsuario;

        public Usuario() { }

        // Construtor para inicializar a classe
        [JsonConstructor]
        public Usuario(string nome, string email, string senha, string endereco, string telefone, TipoUsuario tipoUsuario)
        {
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.endereco = endereco;
            this.telefone = telefone;
            this.tipoUsuario = tipoUsuario;
        }

        public Usuario(string email, string senha)
        {
            this.email = email;
            this.senha = senha;
        }

        // Propriedades públicas para desserialização JSON
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Senha { get => senha; set => senha = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public TipoUsuario TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }
    }
}
