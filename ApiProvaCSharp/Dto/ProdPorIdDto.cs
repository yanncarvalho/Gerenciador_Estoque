using ApiProvaCSharp.Models;
using System.Text.Json.Serialization;

namespace ApiProvaSharp.Dto
{
    public class ProdutoPorId
    {
        public ProdutoPorId(Produto produto, Venda? venda)
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

        public string Nome { get; set; }

        [JsonPropertyName("valor_unitario")]
        public float ValUnitario { get; set; }

        [JsonPropertyName("qtde_estoque")]
        public int QtdeEstoque { get; set; }
        [JsonPropertyName("dt_ult_venda")]
        public DateTime? DtUltVenda { get; set; }

        [JsonPropertyName("val_ult_venda")]
        public float? ValUltVenda { get; set; }

        [JsonPropertyName("id_produto")]
        public int IdProduto { get; set; }

    }
}
