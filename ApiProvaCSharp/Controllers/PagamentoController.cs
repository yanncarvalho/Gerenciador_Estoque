using Microsoft.AspNetCore.Mvc;

using ApiProvaCSharp.Models;

using System.Net.Mime;

using ApiProvaCSharp.Dto;
using Swashbuckle.AspNetCore.Annotations;


namespace ApiProvaCSharp.Controllers
{
  [ApiController, Route("api/pagamento")]
  public class PagamentoController : Controller
    {
        [HttpPost("compras")]
        [Produces(MediaTypeNames.Application.Json), Consumes(MediaTypeNames.Application.Json)]
        [SwaggerResponse(200)]
        [SwaggerResponse(400, description: "retorna: Ocorreu um erro desconhecido")]
        public ActionResult Compras([FromBody] PagCompraDto pagCompraDto)
        {

            return Ok(new {valor = pagCompraDto.Valor, estado = CompraEstado.Get(pagCompraDto.Valor) });


        }
   }
}
