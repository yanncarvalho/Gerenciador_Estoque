using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProvaCSharp.Models
{
    [Table("vendas")]
    public class Venda
    {
        [Key, Column("id")]
        [Required, Range(1, uint.MaxValue)]
        public uint Id { get; set; }

        [Column("data")]
        public DateTime? Data { get; set; }


        [Column("valor_produto")]
        [Required, Range(0.0, double.PositiveInfinity)]
        public double? ValorProduto { get; set; }

        [ForeignKey("Produto"), Column("id_produtos")]
        [Required, Range(1, uint.MaxValue)]
        public uint IdProduto { get; set; }


    }
}
