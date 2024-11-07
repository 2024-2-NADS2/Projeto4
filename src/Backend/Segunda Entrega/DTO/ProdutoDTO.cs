using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPI.Enum;

namespace ProjetoPI.DTO
{
    public class ProdutoDTO
    {

        public string Descricao { get; set; }
        public EstadoItem Estado { get; set; }
        public Tipo Tipo { get; set; }
        public string? Tamanho { get; set; } 
        public string Genero { get; set; } 

        public string Autor { get; set; }

    }
}