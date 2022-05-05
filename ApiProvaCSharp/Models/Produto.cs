using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace ApiProvaCSharp.Models
{
    [Table("Produtos")]
    public class Produto
    {

        [JsonIgnore]
        [Key, Column("id")]
        public uint Id { get; set; }

        //não sao permitidos carcateres numerios, especiais ou acentuação
        [Required(AllowEmptyStrings = false), RegularExpression(@"^\w|\s*$")]
        [Column("nome")]
        public string? Nome { get; set; }


        [JsonPropertyName("valor_unitario"), Column("valor_unitario")]
        [Required, Range(0.0d, double.PositiveInfinity)]
        public double ValorUnitario { get; set; }

        [JsonPropertyName("qtde_estoque"), Column("qtde_estoque")]
        [Required, Range(0, uint.MaxValue)]
        public uint QtdeEstoque { get; set; }


    }
}
