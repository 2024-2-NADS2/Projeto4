using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoPI.Enum;

namespace ProjetoPI.DTO
{
    public class ProdutoDTO
    {

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
    }
}