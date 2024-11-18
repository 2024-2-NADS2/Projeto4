using Newtonsoft.Json;
using ProjetoPI.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public abstract class Produto
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Descricao { get; set; }

    [Required]
    public string Estado { get; set; }


    [JsonIgnore]  // Isso faz com que o 'doador' não apareça no JSON

    [ForeignKey("Doador")]
    public int DoadorId { get; set; }

    [JsonIgnore]
    public Doador? Doador { get; set; }  
}
