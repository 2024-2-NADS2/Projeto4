using ProjetoPI.Model;

public interface IProdutoService
{
    Task<Roupa> PostarRoupaAsync(Roupa roupa);
    Task<Livro> PostarLivroAsync(Livro livro);
    Task<Calcado> PostarCalcadoAsync(Calcado calcado);
}
