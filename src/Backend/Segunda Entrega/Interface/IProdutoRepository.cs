public interface IProdutoRepository
{
    Task<int> AddProdutoAsync(Produto produto);
    // Método para obter um produto pelo ID
    Task<Produto?> GetProdutoByIdAsync(int id);

    // Método para listar todos os produtos
    Task<List<Produto>> GetAllProdutosAsync();

    // Método para atualizar um produto
    Task UpdateProdutoAsync(Produto produto);

    // Método para excluir um produto
    Task DeleteProdutoAsync(int id);

}



