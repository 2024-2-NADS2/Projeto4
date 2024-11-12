using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Livro : Produto
{
    public string Genero { get; set; }
    public string Autor { get; set; }
    public string Editora { get; set; }

}