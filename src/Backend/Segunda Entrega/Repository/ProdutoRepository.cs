using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoPI.Data;

public class ProdutoRepository : IProdutoRepository
{
    private readonly ApplicationDbContext _context;

    public ProdutoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddProdutoAsync(Produto produto)
    {
        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();
        return produto.Id;
    }

    // Leitura (Read) - Obter produto pelo ID
    public async Task<Produto?> GetProdutoByIdAsync(int id)
    {
        return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
    }

    // Leitura (Read) - Listar todos os produtos
    public async Task<List<Produto>> GetAllProdutosAsync()
    {
        return await _context.Produtos.ToListAsync();
    }

    // Atualização (Update)
    public async Task UpdateProdutoAsync(Produto produto)
    {
        _context.Produtos.Update(produto);
        await _context.SaveChangesAsync();
    }

    // Remoção (Delete)
    public async Task DeleteProdutoAsync(int id)
    {
        var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        if (produto != null)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

    }
}



