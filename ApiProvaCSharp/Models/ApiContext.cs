using Microsoft.EntityFrameworkCore;
namespace ApiProvaCSharp.Models
{
    public class ApiContext : DbContext

    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Venda> Vendas { get; set; } = null!;
    }
}
