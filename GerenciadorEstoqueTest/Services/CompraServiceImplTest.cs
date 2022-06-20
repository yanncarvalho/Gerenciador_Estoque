using GerenciadorEstoque.Services.ServicesImpl;
using Xunit;
using Moq;
using GerenciadorEstoque.Models;
using GerenciadorEstoque.Dto;
using System;
using GerenciadorEstoqueTest.Mocks;

namespace GerenciadorEstoqueTest.Services
{
    public class CompraServiceImplTest
    {
        private readonly ProdutoMock _MockProdutos = new();
        private readonly VendaMock _MockVendas = new();
        private readonly Mock<ApiContext> _MockContext = new();

        [Fact(DisplayName = "Quando compra produto mais do que o estoque então Retorna exceção")]
        public void Quando_compra_produto_mais_do_que_estoque_Retorna_excecao()
        {
            //Arrange
            _MockContext.Setup(c => c.Produtos).Returns(_MockProdutos.Get().Object);
            _MockContext.Setup(c => c.Vendas).Returns(_MockVendas.Get().Object);
            var service = new CompraService(_MockContext.Object);
      
            //Act
            var ex = Record.Exception(() => service.Comprar(new ComprarProdDto { ProdutoId = _MockProdutos.ANY_ID, QtComprada = int.MaxValue }));

            //Assert
            Assert.NotNull(ex);
            Assert.IsType<InvalidOperationException>(ex);

        }

    }

}