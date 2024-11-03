using ProjetoPI.Model;

namespace ProjetoPI.Interface
{
    public interface IOngRepository
    {
        Ong GetOngByEmail(string email);
        void AdicionarOng(Ong ong);
        List<Ong> GetAllOngs();
        int GetQuantidadeOngs();
    }
}
