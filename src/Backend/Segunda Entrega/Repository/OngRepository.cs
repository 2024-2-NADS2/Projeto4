using ProjetoPI.Data;
using ProjetoPI.Interface;
using ProjetoPI.Model;

namespace ProjetoPI.Repository
{
    public class OngRepository : IOngRepository
    {
        private readonly ApplicationDbContext _context;

        public OngRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Ong GetOngByEmail(string email)
        {
            return _context.Ongs.FirstOrDefault(o => o.Email == email);
        }

        public void AdicionarOng(Ong ong)
        {
            _context.Ongs.Add(ong);
            _context.SaveChanges(); // Salva as alterações no banco de dados
        }

        public List<Ong> GetAllOngs()
        {
            return _context.Ongs.ToList();
        }

        public int GetQuantidadeOngs()
        {
            return _context.Ongs.Count();
        }
    }
}