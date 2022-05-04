using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace ApiProvaCSharp.Models
{
    [Table("Produtos")]
    public class Produto
    {
    
        [Key]
        [JsonIgnore]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("nome")]
        public string Nome { get; set; }

        [Required]
        [JsonPropertyName("valor_unitario")]
        [Column("valor_unitario")]
        public float ValorUnitario { get; set; }

        [Required]
        [JsonPropertyName("qtde_estoque")]
        [Column("qtde_estoque")]
        public int QtdeEstoque { get; set; }

     
    }
}
