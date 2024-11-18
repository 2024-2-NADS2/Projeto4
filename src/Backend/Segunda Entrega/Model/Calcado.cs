using ProjetoPI.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoPI.Model
{
    public class Calcado : Produto
    {      
        public string Tamanho { get; set; }

      
    }
}