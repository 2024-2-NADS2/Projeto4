using Microsoft.EntityFrameworkCore;
using ProjetoPI.Data;
using ProjetoPI.Interface;
using ProjetoPI.Model;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _context;

    public UsuarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Usuario GetUsuarioByEmail(string email)
    {
        return _context.Usuarios.FirstOrDefault(u => u.Email == email);
    }

    public async Task AdicionarUsuario(Usuario usuario)
    {
        if (await VerificarUsuarioExistente(usuario.Email))
        {
            throw new Exception("Usuário já existe com este e-mail.");
        }

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync(); 
    }

    public List<Usuario> GetAllUsuarios()
    {
        return _context.Usuarios.ToList();
    }

    public Usuario GetUsuarioByEmailSenha(string email, string senha)
    {
        return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
    }

    public int GetQuantidadeUsuarios()
    {
        return _context.Usuarios.Count();
    }

    public Usuario GetUsuarioById(int id)
    {
        return  _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
    }

    public async Task<bool> VerificarUsuarioExistente(string email)
    {
        var usuarioExistente = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Email == email);

        return usuarioExistente != null;
    }
}
