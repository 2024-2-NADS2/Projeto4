using Microsoft.EntityFrameworkCore;
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

    // Métodos READ
    public async Task<Roupa> GetRoupaByIdAsync(int id)
    {
        return await _context.Roupas.FindAsync(id);
    }

    public async Task<List<Roupa>> GetAllRoupasAsync()
    {
        return await _context.Roupas.ToListAsync();
    }

    public async Task<Livro> GetLivroByIdAsync(int id)
    {
        return await _context.Livros.FindAsync(id);
    }

    public async Task<List<Livro>> GetAllLivrosAsync()
    {
        return await _context.Livros.ToListAsync();
    }

    public async Task<Calcado> GetCalcadoByIdAsync(int id)
    {
        return await _context.Calcados.FindAsync(id);
    }

    public async Task<List<Calcado>> GetAllCalcadosAsync()
    {
        return await _context.Calcados.ToListAsync();
    }

    // Métodos UPDATE
    public async Task<Roupa> AtualizarRoupaAsync(int id, Roupa roupaAtualizada)
    {
        var roupaExistente = await _context.Roupas.FindAsync(id);

        if (roupaExistente == null)
            throw new Exception("Roupa não encontrada.");

        // Atualiza os campos necessários
        roupaExistente.TipoRoupa = roupaAtualizada.TipoRoupa;
        roupaExistente.Tamanho = roupaAtualizada.Tamanho;
        roupaExistente.Cor = roupaAtualizada.Cor;

        await _context.SaveChangesAsync();
        return roupaExistente;
    }

    public async Task<Livro> AtualizarLivroAsync(int id, Livro livroAtualizado)
    {
        var livroExistente = await _context.Livros.FindAsync(id);

        if (livroExistente == null)
            throw new Exception("Livro não encontrado.");

        livroExistente.Genero = livroAtualizado.Genero;
        livroExistente.Autor = livroAtualizado.Autor;
        livroExistente.Editora = livroAtualizado.Editora;

        await _context.SaveChangesAsync();
        return livroExistente;
    }

    public async Task<Calcado> AtualizarCalcadoAsync(int id, Calcado calcadoAtualizado)
    {
        var calcadoExistente = await _context.Calcados.FindAsync(id);

        if (calcadoExistente == null)
            throw new Exception("Calçado não encontrado.");

        calcadoExistente.Tamanho = calcadoAtualizado.Tamanho;

        await _context.SaveChangesAsync();
        return calcadoExistente;
    }

    // Métodos DELETE
    public async Task<bool> DeletarRoupaAsync(int id)
    {
        var roupa = await _context.Roupas.FindAsync(id);

        if (roupa == null)
            return false;

        _context.Roupas.Remove(roupa);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletarLivroAsync(int id)
    {
        var livro = await _context.Livros.FindAsync(id);

        if (livro == null)
            return false;

        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletarCalcadoAsync(int id)
    {
        var calcado = await _context.Calcados.FindAsync(id);

        if (calcado == null)
            return false;

        _context.Calcados.Remove(calcado);
        await _context.SaveChangesAsync();
        return true;
    }
}


