using Microsoft.AspNetCore.Mvc;

using ApiProvaCSharp.Services;

using System.Net.Mime;

using ApiProvaCSharp.Dto;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiProvaCSharp.Controllers
{
    [Route("api/compras")]
    [ApiController]
    public class ComprasController : Controller
    {
        private readonly ICompraService _service;

        public ComprasController(ICompraService service)
        {
            _service = service;
        }


        [HttpPost]
        [Produces(MediaTypeNames.Application.Json), Consumes(MediaTypeNames.Application.Json)]
        [SwaggerResponse(200, description: "retorna: Venda realizada com sucesso")]
        [SwaggerResponse(400, description: "retorna: Ocorreu um erro desconhecido")]
        [SwaggerResponse(412, description: "retorna: Os valores informados não são válidos")]
   
        public ActionResult ComprarProd([FromBody] ComprarProdDto compra)
        {
            _service.Comprar(compra);
            return Ok("Venda realizada com sucesso");

        }
    }
}
