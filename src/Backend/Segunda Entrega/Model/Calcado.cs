using ProjetoPI.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoPI.Model
{
    public class Calcado : Produto
    {
        [Required]
        private TipoCalcado tipoCalcado;
        [Required]
        private int tamanho;

        //public Calcado() { }

        //[JsonConstructor]
        //public Calcado(string descricao, EstadoItem estado, TipoCalcado tipoCalcado, int tamanho)
        //    : base(descricao, estado, Enum.Tipo.Calcado )
        //{
        //    this.tipoCalcado = tipoCalcado;
        //    this.tamanho = tamanho;
        //}

        //public TipoCalcado TipoCalcado { get => tipoCalcado; set => tipoCalcado = value; }
        //public int Tamanho { get => tamanho; set => tamanho = value; }
        public string Tamanho { get; set; }

        //public Calcado(string descricao, EstadoItem estado, string tamanho)
        //                : base(descricao, estado, Enum.Tipo.Calcado) // Passar Tipo.Calcado corretamente

        //{
        //    Tamanho = tamanho;
    }
}