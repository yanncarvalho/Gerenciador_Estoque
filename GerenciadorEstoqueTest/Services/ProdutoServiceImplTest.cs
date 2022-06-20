using Xunit;
using Moq;
using GerenciadorEstoque.Models;


using GerenciadorEstoque.Services.ServicesImpl;
using GerenciadorEstoqueTest.Mocks;

namespace GerenciadorEstoqueTest.Services
{
    public class ProdutoServiceImplTest
    {
        private readonly ProdutoMock _MockProdutos = new();
        private readonly VendaMock _MockVendas = new();
        private readonly Mock<ApiContext> _MockContext = new();


        [Fact(DisplayName = "Quando busca produto por id Retorna a data da ultima venda")]
        public void Quando_busca_produto_por_id_Retorna_data_ultima_venda()
        {
            //Arrange
            _MockContext.Setup(c => c.Produtos).Returns(_MockProdutos.Get().Object);
            _MockContext.Setup(c => c.Vendas).Returns(_MockVendas.Get().Object);
            var service = new ProdutoService(_MockContext.Object);

            //Act
            var result = service.BuscarPorId(_MockProdutos.ANY_ID)!;

            //Assert 
            Assert.Equal(_MockVendas.DtUltimaVenda, result.DtUltVenda);

        }

        [Fact(DisplayName = "Quando busca todos produtos Retorna todos os produtos")]
        public void Quando_busca_todos_produto_retorna_todos_os_Produtos()
        {

            //Arrange
            _MockContext.Setup(c => c.Produtos).Returns(_MockProdutos.Get().Object);
            var service = new ProdutoService(_MockContext.Object);

            //Act
            Produto[] result = service.BuscarTodos();

            //Assert 
            Assert.Equal(_MockProdutos.TAMANHO, result.Length);
            Assert.Equal(_MockProdutos.PRODUTO_1, result[0]);
            Assert.Equal(_MockProdutos.PRODUTO_2, result[1]);

        }

        [Fact(DisplayName = "Quando remover produto então o produto é removido")]
        public void Quando_remover_produto_Entao_produto_removido()
        {
            //Arrange
            var mockSetProduto = _MockProdutos.Get();
            var mockSetVenda = _MockVendas.Get();
            _MockContext.Setup(c => c.Produtos).Returns(mockSetProduto.Object);
            _MockContext.Setup(c => c.Vendas).Returns(mockSetVenda.Object);
            var service = new ProdutoService(_MockContext.Object);

            //Act
            service.Remover(_MockProdutos.ANY_ID);

            //Assert
            mockSetVenda.Verify(m => m.RemoveRange(It.IsAny<Venda[]>()), Times.Once);
            mockSetProduto.Verify(m => m.Remove(It.IsAny<Produto>()), Times.Once);
        }
    } 
}


