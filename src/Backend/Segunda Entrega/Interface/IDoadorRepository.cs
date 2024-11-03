using ProjetoPI.Model;

namespace ProjetoPI.Interface
{
    public interface IDoadorRepository
    {
        Doador GetDoadorByEmail(string email);
        void AdicionarDoador(Doador doador);
        List<Doador> GetAllDoadores();
        int GetQuantidadeDoadores();
    }
}
