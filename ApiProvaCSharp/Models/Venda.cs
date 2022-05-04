using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProvaCSharp.Models
{
    [Table("vendas")]
    public class Venda
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("data")]
        public DateTime? Data { get; set; }


        [Column("valor_produto")]
        public float? ValorProduto { get; set; }

        [ForeignKey("Produto")]
        [Column("id_produtos")]
        public int IdProduto { get; set; }


    }
}
