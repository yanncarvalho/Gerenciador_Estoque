using ApiProvaCSharp.Models;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ApiProvaCSharp.Dto
{
     public class ComprarProdDto
    {
        [Required, Range(1, uint.MaxValue)]
        [JsonPropertyName("produto_id")]
        public uint ProdutoId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public CartaoCred? Cartao { get; set; }

        [Required, Range(0, uint.MaxValue)]
        [JsonPropertyName("qtde_comprada")]
        public uint QtComprada { get; set; }
    }
}