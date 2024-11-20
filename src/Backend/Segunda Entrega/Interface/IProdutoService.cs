using ProjetoPI.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public interface IProdutoService
{
    Task<Roupa> PostarRoupaAsync(Roupa roupa);
    Task<Livro> PostarLivroAsync(Livro livro);
    Task<Calcado> PostarCalcadoAsync(Calcado calcado);
    // Métodos READ
    Task<Roupa> GetRoupaByIdAsync(int id);
    Task<List<Roupa>> GetAllRoupasAsync();
    Task<Livro> GetLivroByIdAsync(int id);
    Task<List<Livro>> GetAllLivrosAsync();
    Task<Calcado> GetCalcadoByIdAsync(int id);
    Task<List<Calcado>> GetAllCalcadosAsync();

    // Métodos UPDATE
    Task<Roupa> AtualizarRoupaAsync(int id, Roupa roupaAtualizada);
    Task<Livro> AtualizarLivroAsync(int id, Livro livroAtualizado);
    Task<Calcado> AtualizarCalcadoAsync(int id, Calcado calcadoAtualizado);

    // Métodos DELETE
    Task<bool> DeletarRoupaAsync(int id);
    Task<bool> DeletarLivroAsync(int id);
    Task<bool> DeletarCalcadoAsync(int id);

}


