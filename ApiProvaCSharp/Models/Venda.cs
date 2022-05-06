using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProvaCSharp.Models
{
    [Table("vendas")]
    public class Venda
    {
        [Key, Column("id"), JsonProperty("id")]
        [JsonRequired, Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Column("data"), JsonProperty("data")]
        public DateTime Data { get; set; }



        [Column("valor_produto"), JsonProperty("valor_produto")]
        [JsonRequired, Range(0.0d, double.MaxValue)]
        public double ValorProduto { get; set; }

        [ForeignKey("Produto"), Column("id_produto"), JsonProperty("id_produto")]
        [JsonRequired, Range(1, int.MaxValue)]
        public int IdProduto { get; set; }


    }
}
