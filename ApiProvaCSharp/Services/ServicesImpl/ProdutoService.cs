using ApiProvaCSharp.Models;
using ApiProvaSharp.Dto;

namespace ApiProvaCSharp.Services.ServicesImpl
{
    public class ProdutoService : IProdutoService
    {
        private readonly ApiContext _context;


        public ProdutoService(ApiContext context)
        {
            _context = context;
        }

        public ProdutoPorId? buscarPorId(int id)
        {
          var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return null;
            }

            var venda = _context.Vendas.OrderByDescending(v => v.Data).Where(venda => venda.IdProduto == produto.Id).FirstOrDefault();

          return new ProdutoPorId(produto, venda);
         
        }

        public Produto[] buscarTodos()
        {
            return _context.Produtos.ToArray();
        }

        public bool cadastrar(Produto produto)
        { 
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return true;
        }

        public bool Remover(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto != null)
            {
                var vendasProduto  = (from venda in _context.Vendas where venda.IdProduto == produto.Id select venda).ToArray();
            
                _context.Vendas.RemoveRange(vendasProduto); 
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
                return true;

            }

            return false;

        }
    }
}
