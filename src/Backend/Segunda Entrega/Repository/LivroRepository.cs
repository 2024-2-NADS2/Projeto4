using Microsoft.EntityFrameworkCore;
using ProjetoPI.Data;
using ProjetoPI.Interface;
using ProjetoPI.Model;

public class LivroRepository : ILivroRepository
{
    private readonly ApplicationDbContext _context;

    public LivroRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Livro GetLivroById(int id)
    {
        return _context.Livros.FirstOrDefault(l => l.Id == id);
    }

    public void AdicionarLivro(Livro livro)
    {
        _context.Livros.Add(livro);
        _context.SaveChanges(); // Salva as alterações no banco de dados
    }

    public List<Livro> GetAllLivros()
    {
        return _context.Livros.ToList();
    }

    public int GetQuantidadeLivros()
    {
        return _context.Livros.Count();
    }
}