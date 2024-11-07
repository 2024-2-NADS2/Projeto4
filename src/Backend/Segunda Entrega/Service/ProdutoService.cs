using ProjetoPI.Data;
using ProjetoPI.Interface;
using ProjetoPI.Model;
using System.Threading.Tasks;

public class ProdutoService : IProdutoService
{
   

    
    private readonly ApplicationDbContext _context;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(ApplicationDbContext context, IUsuarioRepository usuarioRepository, IProdutoRepository produtoRepository)
    {
        _context = context;
        _usuarioRepository = usuarioRepository;
        _produtoRepository = produtoRepository;
    }

    public async Task<Roupa> PostarRoupaAsync(Roupa roupa)
    {
        // Verifica se o usuário existe
        var usuarioExistente =  _usuarioRepository.GetUsuarioById(roupa.DoadorId);

        if (usuarioExistente == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        // Lógica para criação da roupa
        _context.Roupas.Add(roupa);
        await _context.SaveChangesAsync();

        return roupa;
    }


    //realizar testes mais tarde

    public async Task<int> PostarLivroAsync(Livro livro)
    {
        return await _produtoRepository.AddProdutoAsync(livro);
    }

    public async Task<int> PostarCalcadoAsync(Calcado calcado)
    {
        return await _produtoRepository.AddProdutoAsync(calcado);
    }
}
