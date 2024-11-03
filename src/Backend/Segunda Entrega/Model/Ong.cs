using ProjetoPI.Enum;
using ProjetoPI.Model;

namespace ProjetoPI.Model
{
    public class Ong : Usuario
    {
        private string cnpj;
        private DateTime dataCadastro;

        // Construtor para inicializar a classe
        public Ong(string nome, string email, string senha, string endereco, string telefone, string cnpj)
   : base(nome, email, senha, endereco, telefone, TipoUsuario.Ong)
        {
            this.cnpj = cnpj;
            this.dataCadastro = DateTime.Now; // Define a data de cadastro como a data atual
        }

        // Propriedades públicas para acesso
        public string Cnpj { get => cnpj; set => cnpj = value; }
        public DateTime DataCadastro { get => dataCadastro; set => dataCadastro = value; }
    }
}
