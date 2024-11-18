using ProjetoPI.Enum;
using ProjetoPI.Model;

public class Doador : Usuario
{
    private string cpf;
    private DateTime dataNascimento;
    private DateTime dataCadastro;
    private string dataNascimentoString;
    // Construtor para inicializar a classe
    public Doador(string nome, string email, string senha, string endereco, string telefone, string cpf, DateTime dataNascimento, string dataNascimentoString)
        : base(nome, email, senha, endereco, telefone, TipoUsuario.Doador)
    {
        this.cpf = cpf;
        this.dataNascimento = dataNascimento;
        this.dataCadastro = DateTime.Now; // Define a data de cadastro como a data atual
        this.dataNascimentoString = dataNascimentoString;
    }
    public Doador() { }
    // Propriedades públicas para acesso
    public string Cpf { get => cpf;  set => cpf = value; }
    public DateTime DataNascimento { get => dataNascimento; set => dataNascimento = value; }
    public DateTime DataCadastro { get => dataCadastro; set => dataCadastro = value; }
    public string DataNascimentoString { get => dataNascimentoString; set => dataNascimentoString = value; }
}
