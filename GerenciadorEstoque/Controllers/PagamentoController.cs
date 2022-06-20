using Microsoft.AspNetCore.Mvc;

using GerenciadorEstoque.Models;

using System.Net.Mime;

using GerenciadorEstoque.Dto;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorEstoque.Controllers
{
  [ApiController, Route("api/pagamento")]
  public class PagamentoController : Controller
    {
        [HttpPost("compras")]
        [Produces(MediaTypeNames.Application.Json), Consumes(MediaTypeNames.Application.Json)]
        [SwaggerResponse(200)]
        [SwaggerResponse(400, description: "retorna: Ocorreu um erro desconhecido")]
        public ActionResult PagCompra([FromBody]PagCompraDto pagCompraDto)
        {

            return Ok(new {valor = pagCompraDto.Valor, estado = CompraEstado.Get(pagCompraDto.Valor) });


        }
   }
}
