using ProjetoPI.Model;

public interface IProdutoService
{
    Task<Roupa> PostarRoupaAsync(Roupa roupa);
    Task<int> PostarLivroAsync(Livro livro);
    Task<int> PostarCalcadoAsync(Calcado calcado);
}
