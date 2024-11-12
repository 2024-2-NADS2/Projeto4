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


    public async Task<Livro> PostarLivroAsync(Livro livro)
    {
        // Verifica se o usuário existe
        var usuarioExistente = _usuarioRepository.GetUsuarioById(livro.DoadorId);

        if (usuarioExistente == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        // Lógica para criação da roupa
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();

        return livro;
    }

    public async Task<Calcado> PostarCalcadoAsync(Calcado calcado)
    {
        // Verifica se o usuário existe
        var usuarioExistente = _usuarioRepository.GetUsuarioById(calcado.DoadorId);

        if (usuarioExistente == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        // Lógica para criação da roupa
        _context.Calcados.Add(calcado);
        await _context.SaveChangesAsync();

        return calcado;
    }
}
