using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Roupa : Produto
{
    [Required]
    public TipoRoupa TipoRoupa { get; set; }
    public string Tamanho { get; set; }
    public string Cor { get; set; }
}

public enum TipoRoupa
{
    Camisa,
    Calca,
    Sapato,
    Acessorio
}
