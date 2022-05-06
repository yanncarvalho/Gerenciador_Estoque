using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProvaCSharp.Models
{
    [Table("Produtos")]
    public class Produto
    {

        
        [Key, Column("id")]
        [Newtonsoft.Json.JsonIgnore]
        public int Id { get; set; }

      
        [Required(AllowEmptyStrings = false), MaxLength(255)]
        [Column("nome"), JsonProperty("nome")]
        public string? Nome { get; set; }


        [JsonProperty("valor_unitario"), Column("valor_unitario")]
        [JsonRequired, Range(0.0d, double.MaxValue)]
        public double ValorUnitario { get; set; }

        [JsonProperty("qtde_estoque"), Column("qtde_estoque")]
        [JsonRequired, Range(0, int.MaxValue)]
        public int QtdeEstoque { get; set; }


    }
}
