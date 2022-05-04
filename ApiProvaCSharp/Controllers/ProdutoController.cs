using ApiProvaCSharp.Models;
using ApiProvaCSharp.Services;
using ApiProvaCSharp.Services.ServicesImpl;
using Microsoft.AspNetCore.Mvc;

using System.Net.Mime;


namespace ApiProvaCSharp.Controllers
{
    [Route("/api/produtos")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        //TODO filtro para erro 402
        public ActionResult cadastrar([FromBody] Produto produto)
        {
            _service.cadastrar(produto);
            return Ok();

        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult buscarTodos()
        {
            Produto[] produtos = _service.buscarTodos();
            return Ok(produtos);

        }

        [HttpGet("{produtoId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult buscarPorId(int produtoId)
        {
            var produto = _service.buscarPorId(produtoId);
            if (produto == null)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro desconhecido"});
            }
            return Ok(produto);

        }

        [HttpDelete("{produtoId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Remover(int produtoId)
        {
            var hasRemoved = _service.Remover(produtoId);
            if (!hasRemoved)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro desconhecido" });
            }
            return Ok(new { mensagem = "Produto excluído com sucesso" });

        }

    }
}
