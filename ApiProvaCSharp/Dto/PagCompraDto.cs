using ApiProvaCSharp.Models;
using System.ComponentModel.DataAnnotations;


namespace ApiProvaCSharp.Dto
{
     public class PagCompraDto
     {

      [Required, Range(0.0d, double.PositiveInfinity)]
      public double Valor {get; set;}


      [Required(AllowEmptyStrings = false)]
      public CartaoCred? Cartao { get; set; }

     }
}