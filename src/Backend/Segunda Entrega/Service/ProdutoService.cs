using ProjetoPI.Data;
using ProjetoPI.Interface;
using ProjetoPI.Model;
using System.Threading.Tasks;
public class ProdutoService : IProdutoService
{
    private readonly ApplicationDbContext _context;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IProdutoRepository _produtoRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ProdutoService(ApplicationDbContext context, IUsuarioRepository usuarioRepository, IProdutoRepository produtoRepository, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _usuarioRepository = usuarioRepository;
        _produtoRepository = produtoRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Roupa> PostarRoupaAsync(Roupa roupa)
    {
        var usuarioId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");

        // Verifica se o usuário está logado
        if (usuarioId == null)
        {
            throw new Exception("Usuário não está logado.");
        }

        roupa.DoadorId = usuarioId.Value;
        // Verifica se o usuário logado é o mesmo que está tentando postar a roupa
        if (roupa.DoadorId != usuarioId.Value)
        {
            throw new Exception("O doador da roupa não corresponde ao usuário logado.");
        }

        // Lógica para criação da roupa
        _context.Roupas.Add(roupa);
        await _context.SaveChangesAsync();

        return roupa;
    }

    public async Task<Livro> PostarLivroAsync(Livro livro)
    {
        // Verifica se o usuário existe
        var usuarioId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");

        // Verifica se o usuário está logado
        if (usuarioId == null)
        {
            throw new Exception("Usuário não está logado.");
        }

        livro.DoadorId = usuarioId.Value;
        // Verifica se o usuário logado é o mesmo que está tentando postar a roupa
        if (livro.DoadorId != usuarioId.Value)
        {
            throw new Exception("O doador da roupa não corresponde ao usuário logado.");
        }
        // Lógica para criação da roupa
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();

        return livro;
    }

    public async Task<Calcado> PostarCalcadoAsync(Calcado calcado)
    {
        // Verifica se o usuário existe
        // Verifica se o usuário existe
        var usuarioId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");

        // Verifica se o usuário está logado
        if (usuarioId == null)
        {
            throw new Exception("Usuário não está logado.");
        }

        calcado.DoadorId = usuarioId.Value;
        // Verifica se o usuário logado é o mesmo que está tentando postar a roupa
        if (calcado.DoadorId != usuarioId.Value)
        {
            throw new Exception("O doador da roupa não corresponde ao usuário logado.");
        }
        // Lógica para criação da roupa
        _context.Calcados.Add(calcado);
        await _context.SaveChangesAsync();

        return calcado;
    }
}
