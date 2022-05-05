using ApiProvaCSharp.Models;
using System.Text.Json.Serialization;

namespace ApiProvaCSharp.Dto
{
    public class ProdPorIdDto
    {
        public ProdPorIdDto(Produto produto, Venda? venda)
        {
            if(venda != null)
            {
                DtUltVenda = venda.Data;
                ValUltVenda = venda.ValorProduto;
            }

            IdProduto = produto.Id;
            Nome = produto.Nome;
            QtdeEstoque = produto.QtdeEstoque;
            ValUnitario = produto.ValorUnitario;

        }

        public string? Nome { get; set; }

        [JsonPropertyName("valor_unitario")]
        public double ValUnitario { get; set; }

        [JsonPropertyName("qtde_estoque")]
        public uint QtdeEstoque { get; set; }

        [JsonPropertyName("dt_ult_venda")]
        public DateTime? DtUltVenda { get; set; }

        [JsonPropertyName("val_ult_venda")]
        public double? ValUltVenda { get; set; }

        [JsonPropertyName("id_produto")]
        public uint IdProduto { get; set; }

    }
}
