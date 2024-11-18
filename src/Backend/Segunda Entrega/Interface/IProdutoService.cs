using ProjetoPI.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public interface IProdutoService
{
    Task<Roupa> PostarRoupaAsync(Roupa roupa);
    Task<Livro> PostarLivroAsync(Livro livro);
    Task<Calcado> PostarCalcadoAsync(Calcado calcado);
}
