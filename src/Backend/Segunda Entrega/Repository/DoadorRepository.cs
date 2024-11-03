using ProjetoPI.Data;
using ProjetoPI.Interface;
using ProjetoPI.Model;

namespace ProjetoPI.Repository
{
    public class DoadorRepository : IDoadorRepository
    {
        private readonly ApplicationDbContext _context;

        public DoadorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Doador GetDoadorByEmail(string email)
        {
            return _context.Doadores.FirstOrDefault(d => d.Email == email);
        }

        public void AdicionarDoador(Doador doador)
        {
            _context.Doadores.Add(doador);
            _context.SaveChanges(); // Salva as alterações no banco de dados
        }

        public List<Doador> GetAllDoadores()
        {
            return _context.Doadores.ToList();
        }

        public int GetQuantidadeDoadores()
        {
            return _context.Doadores.Count();
        }
    }
}