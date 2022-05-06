using ApiProvaCSharp.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ApiProvaCSharp.Dto
{
    public class ProdPorIdDto
    {
        public ProdPorIdDto(Produto produto, Venda venda)
        {
            if(venda != null)
            {
                DtUltVenda = venda.Data;
                ValUltVenda = venda.ValorProduto;
            }

            IdProduto = produto.Id;
            Nome = produto.Nome!;
            QtdeEstoque = produto.QtdeEstoque;
            ValUnitario = produto.ValorUnitario;

        }

        public string Nome { get; set; }

        [JsonProperty("valor_unitario")]
        public double ValUnitario { get; set; }

        [JsonProperty("qtde_estoque")]
        public int QtdeEstoque { get; set; }

        [JsonProperty("dt_ult_venda")]
        public DateTime? DtUltVenda { get; set; }

        [JsonProperty("val_ult_venda")]
        public double ValUltVenda { get; set; }

        [JsonProperty("id_produto")]
        public int IdProduto { get; set; }

    }
}
