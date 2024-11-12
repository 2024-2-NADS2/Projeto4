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
}
