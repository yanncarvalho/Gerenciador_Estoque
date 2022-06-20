using GerenciadorEstoque.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace GerenciadorEstoque.Dto
{
     public class PagCompraDto
     {

      [JsonRequired, Range(0.0d, double.MaxValue)]
      public double Valor {get; set;}


      [JsonRequired]
      public CartaoCred? Cartao { get; set; }

     }
}