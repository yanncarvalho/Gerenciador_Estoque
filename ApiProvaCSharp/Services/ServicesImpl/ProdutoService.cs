using ApiProvaCSharp.Models;
using ApiProvaCSharp.Dto;

namespace ApiProvaCSharp.Services.ServicesImpl
{
    public class ProdutoService : IProdutoService
    {
        private readonly ApiContext _context;


        public ProdutoService(ApiContext context)
        {
            _context = context;
        }

        public ProdPorIdDto? BuscarPorId(int? id)
        {
          var produto = _context.Produtos.Find(id);
            if (produto is null) { 
                throw new InvalidOperationException("Ocorreu um erro desconhecido");
            }

            var venda = _context.Vendas.OrderByDescending(v => v.Data).Where(venda => venda.IdProduto == produto.Id).FirstOrDefault();

          return new ProdPorIdDto(produto, venda);

        }

        public Produto[] BuscarTodos()
        {
            return _context.Produtos.ToArray();
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

        }

        public void Remover(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto is null)
            {
                throw new InvalidOperationException("Ocorreu um erro desconhecido");
            }

            var vendasProduto  = (from venda in _context.Vendas where venda.IdProduto == produto.Id select venda).ToArray();

                _context.Vendas.RemoveRange(vendasProduto);
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
        }
    }
}
