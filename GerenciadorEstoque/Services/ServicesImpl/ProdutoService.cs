using GerenciadorEstoque.Models;
using GerenciadorEstoque.Dto;

namespace GerenciadorEstoque.Services.ServicesImpl
{
    public class ProdutoService : IProdutoService
    {
        private readonly ApiContext _Context;

        public ProdutoService(ApiContext context)
        {
            _Context = context;
        }

        public ProdPorIdDto? BuscarPorId(int? id)
        {
          var produto = _Context.Produtos.Find(id)!;
          var venda = _Context.Vendas.OrderByDescending(v => v.Data).Where(venda => venda.IdProduto == produto.Id).FirstOrDefault()!;

          return new ProdPorIdDto(produto, venda);

        }

        public Produto[] BuscarTodos()
        {
            return _Context.Produtos.ToArray();
        }

        public void Cadastrar(Produto produto)
        {
            _Context.Produtos.Add(produto);
            _Context.SaveChanges();

        }

        public void Remover(int id)
        {
            var produto = _Context.Produtos.Find(id)!;

            var vendasProduto  = (from venda in _Context.Vendas where venda.IdProduto == produto.Id select venda).ToArray();

            _Context.Vendas.RemoveRange(vendasProduto);
            _Context.Produtos.Remove(produto);
            _Context.SaveChanges();
        }
    }
}
