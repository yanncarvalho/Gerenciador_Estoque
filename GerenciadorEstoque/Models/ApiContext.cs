using Microsoft.EntityFrameworkCore;
namespace GerenciadorEstoque.Models
{
 
      

    public class ApiContext : DbContext
    {
        public ApiContext() { }
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options) { }
        public virtual DbSet<Produto> Produtos { get; set; } = null!;
        public virtual DbSet<Venda> Vendas { get; set; } = null!;
       
    }
    
}
