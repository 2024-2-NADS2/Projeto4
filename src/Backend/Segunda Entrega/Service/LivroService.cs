using ProjetoPI.Interface;
using ProjetoPI.Model;

namespace ProjetoPI.Service
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public void CadastrarLivro(Livro livro)
        {
            // O serviço vai tratar a inserção do livro
            _livroRepository.AdicionarLivro(livro);
        }

        public List<Livro> ObterTodosLivros()
        {
            return _livroRepository.GetAllLivros();
        }

        public Livro GetLivroById(int id)
        {
            return _livroRepository.GetLivroById(id);
        }
    }
}
