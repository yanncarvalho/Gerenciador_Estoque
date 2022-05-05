using ApiProvaCSharp.Models;
using ApiProvaCSharp.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;


namespace ApiProvaCSharp.Controllers
{
    [Route("/api/produtos")]
    [ApiController]

      [SwaggerResponse(400, description: "retorna: Ocorreu um erro desconhecido")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json), Consumes(MediaTypeNames.Application.Json)]
        [SwaggerResponse(200)]
        [SwaggerResponse(412, description: "retorna: Os valores informados não são válidos")]
        public ActionResult Cadastrar([FromBody] Produto produto)
        {
            _service.Cadastrar(produto);
            return Ok("Produto Cadastrado");

        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(200, type: typeof(Produto[]))]
        public ActionResult BuscarTodos()
        {
            Produto[] produtos = _service.BuscarTodos();
            return Ok(produtos);

        }

        [HttpGet("{produtoId}")]
        [Produces(MediaTypeNames.Application.Json), Consumes(MediaTypeNames.Application.Json)]
        [SwaggerResponse(200, type: typeof(Produto))]
        public ActionResult BuscarPorId (int produtoId)
        {
            var produto = _service.BuscarPorId(produtoId);
            return Ok(produto);

        }

        [HttpDelete("{produtoId}")]
        [Produces(MediaTypeNames.Application.Json), Consumes(MediaTypeNames.Application.Json)]
        [SwaggerResponse(200, description: "retorna: Produto excluído com sucesso")]
        public ActionResult Remover (int produtoId)
        {
            _service.Remover(produtoId);
            return Ok ("Produto excluído com sucesso");

        }

    }
}
