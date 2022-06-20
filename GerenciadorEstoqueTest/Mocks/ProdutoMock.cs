using Moq;
using GerenciadorEstoque.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace GerenciadorEstoqueTest.Mocks
{

    public class ProdutoMock
    {
        public readonly int ANY_ID = 1;
        public readonly Produto PRODUTO_1 = new() { Id = 1, Nome = "PRODUTO 1", ValorUnitario = 1d, QtdeEstoque = 1 };
        public readonly Produto PRODUTO_2 = new() { Id = 2, Nome = "PRODUTO 2", ValorUnitario = 2d, QtdeEstoque = 2 };
        public readonly int TAMANHO = 2;
        public Mock<DbSet<Produto>> Get()
        {

            var produtos = FakeDbProduto();

            var mockSetProduto = new Mock<DbSet<Produto>>();
            mockSetProduto.As<IQueryable<Produto>>().Setup(m => m.Provider).Returns(produtos.Provider);
            mockSetProduto.As<IQueryable<Produto>>().Setup(m => m.Expression).Returns(produtos.Expression);
            mockSetProduto.As<IQueryable<Produto>>().Setup(m => m.ElementType).Returns(produtos.ElementType);
            mockSetProduto.As<IQueryable<Produto>>().Setup(m => m.GetEnumerator()).Returns(produtos.GetEnumerator());
            mockSetProduto.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => produtos.FirstOrDefault(d => d.Id == (int)ids[0]));

            return mockSetProduto;
        } 

        private IQueryable<Produto> FakeDbProduto()
        {
            return new List<Produto>
            {
                PRODUTO_1,
                PRODUTO_2,
            }.AsQueryable();
        }
    }
}

