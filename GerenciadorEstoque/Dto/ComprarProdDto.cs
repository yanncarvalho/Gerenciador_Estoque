using GerenciadorEstoque.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorEstoque.Dto
{
     public class ComprarProdDto
    {
        [Required, Range(1, int.MaxValue)]
        [JsonProperty("produto_id")]
        public int ProdutoId { get; set; }

        [JsonRequired]
        public CartaoCred? Cartao { get; set; }

        [JsonRequired, Range(1, int.MaxValue)]
        [JsonProperty("qtde_comprada")]
        public int QtComprada { get; set; }
    }
}