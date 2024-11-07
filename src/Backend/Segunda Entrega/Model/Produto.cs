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
    public EstadoProduto Estado { get; set; } 

    [ForeignKey("Doador")]
    public int DoadorId { get; set; }

    
    public Doador? Doador { get; set; }  
}

public enum EstadoProduto
{
    Novo,
    Semiusado,
    Desgastado
}
