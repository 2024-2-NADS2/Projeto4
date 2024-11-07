using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpPost]
    public async Task<IActionResult> PostarRoupa([FromBody] Roupa roupa)
    {
        var resultado = await _produtoService.PostarRoupaAsync(roupa);
        return Ok(resultado);
    }

}
