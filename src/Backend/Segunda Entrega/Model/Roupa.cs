using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Roupa : Produto
{
    public string TipoRoupa { get; set; }// Valor padr�o 0 (Camisa)

    public string Tamanho { get; set; }
    public string Cor { get; set; }
}

