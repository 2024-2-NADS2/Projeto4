using Microsoft.AspNetCore.Mvc;
using ProjetoPI.Model;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpPost("roupa")]
    public async Task<IActionResult> PostarRoupa([FromBody] Roupa roupa)
    {
        var resultado = await _produtoService.PostarRoupaAsync(roupa);
        return Ok(resultado);
    }

    [HttpPost("livro")]
    public async Task<IActionResult> PostarLivro([FromBody] Livro livro)
    {
        var resultado = await _produtoService.PostarLivroAsync(livro);
        return Ok(resultado);
    }

    [HttpPost("calcado")]
    public async Task<IActionResult> PostarCalcado([FromBody] Calcado calcado)
    {
        var resultado = await _produtoService.PostarCalcadoAsync(calcado);
        return Ok(resultado);
    }
    // READ
    [HttpGet("roupa/{id}")]
    public async Task<IActionResult> GetRoupaById(int id)
    {
        var resultado = await _produtoService.GetRoupaByIdAsync(id);
        if (resultado == null) return NotFound();
        return Ok(resultado);
    }

    [HttpGet("roupas")]
    public async Task<IActionResult> GetAllRoupas()
    {
        var resultado = await _produtoService.GetAllRoupasAsync();
        return Ok(resultado);
    }

    [HttpGet("livro/{id}")]
    public async Task<IActionResult> GetLivroById(int id)
    {
        var resultado = await _produtoService.GetLivroByIdAsync(id);
        if (resultado == null) return NotFound();
        return Ok(resultado);
    }

    [HttpGet("livros")]
    public async Task<IActionResult> GetAllLivros()
    {
        var resultado = await _produtoService.GetAllLivrosAsync();
        return Ok(resultado);
    }

    [HttpGet("calcado/{id}")]
    public async Task<IActionResult> GetCalcadoById(int id)
    {
        var resultado = await _produtoService.GetCalcadoByIdAsync(id);
        if (resultado == null) return NotFound();
        return Ok(resultado);
    }

    [HttpGet("calcados")]
    public async Task<IActionResult> GetAllCalcados()
    {
        var resultado = await _produtoService.GetAllCalcadosAsync();
        return Ok(resultado);
    }

    // UPDATE
    [HttpPut("roupa/{id}")]
    public async Task<IActionResult> AtualizarRoupa(int id, [FromBody] Roupa roupa)
    {
        var resultado = await _produtoService.AtualizarRoupaAsync(id, roupa);
        return Ok(resultado);
    }

    [HttpPut("livro/{id}")]
    public async Task<IActionResult> AtualizarLivro(int id, [FromBody] Livro livro)
    {
        var resultado = await _produtoService.AtualizarLivroAsync(id, livro);
        return Ok(resultado);
    }

    [HttpPut("calcado/{id}")]
    public async Task<IActionResult> AtualizarCalcado(int id, [FromBody] Calcado calcado)
    {
        var resultado = await _produtoService.AtualizarCalcadoAsync(id, calcado);
        return Ok(resultado);
    }

    // DELETE
    [HttpDelete("roupa/{id}")]
    public async Task<IActionResult> DeletarRoupa(int id)
    {
        var sucesso = await _produtoService.DeletarRoupaAsync(id);
        if (!sucesso) return NotFound();
        return NoContent();
    }

    [HttpDelete("livro/{id}")]
    public async Task<IActionResult> DeletarLivro(int id)
    {
        var sucesso = await _produtoService.DeletarLivroAsync(id);
        if (!sucesso) return NotFound();
        return NoContent();
    }

    [HttpDelete("calcado/{id}")]
    public async Task<IActionResult> DeletarCalcado(int id)
    {
        var sucesso = await _produtoService.DeletarCalcadoAsync(id);
        if (!sucesso) return NotFound();
        return NoContent();
    }


}


