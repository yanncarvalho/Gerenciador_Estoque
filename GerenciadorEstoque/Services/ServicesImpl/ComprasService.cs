using GerenciadorEstoque.Models;
using GerenciadorEstoque.Dto;


namespace GerenciadorEstoque.Services.ServicesImpl
{
    public class CompraService : ICompraService
    {
        private readonly ApiContext _context;


        public CompraService(ApiContext context)
        {
            _context = context;
        }

         public void Comprar(ComprarProdDto compra){

            Produto? produto = _context.Produtos.Find(compra.ProdutoId);
            if(produto is null || compra.QtComprada > produto.QtdeEstoque){
                throw new InvalidOperationException("Ocorreu um erro desconhecido");
            }
             produto.QtdeEstoque -= compra.QtComprada;
            _context.Vendas.Add(new Venda
            {
                IdProduto = produto.Id,
                ValorProduto = produto.ValorUnitario,
                Data = DateTime.Now
            }) ;

            _context.SaveChanges();
         }


    }
}
