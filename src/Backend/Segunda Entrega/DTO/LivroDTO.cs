namespace ProjetoPI.DTO
{
    public class LivroDTO : ProdutoDTO
    {
        public string Genero { get; set; }     // Gênero literário
        public string Autor { get; set; }      // Autor do livro
        public string Editora { get; set; }    // Editora do livro
    }

}
