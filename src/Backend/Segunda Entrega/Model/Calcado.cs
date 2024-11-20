using ProjetoPI.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoPI.Model
{
    public class Calcado : Produto
    {
        public int? Tamanho { get; set; }  // Tamanho pode ser nulo


    }
}