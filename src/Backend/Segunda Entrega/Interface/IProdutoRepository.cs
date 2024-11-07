public interface IProdutoRepository
{
    Task<int> AddProdutoAsync(Produto produto);
}
