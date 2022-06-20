using Moq;
using GerenciadorEstoque.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;


namespace GerenciadorEstoqueTest.Mocks
{
    public class VendaMock
    {

        public readonly DateTime DtUltimaVenda = DateTime.MaxValue;
        public readonly DateTime DtVendaAntiga = DateTime.MinValue;

        public readonly Venda VENDA_ID_1 = new() { Id = 1, IdProduto = 1, Data = DateTime.MaxValue, ValorProduto = 1d };
        public readonly Venda VENDA_ID_2 = new() { Id = 2, IdProduto = 1, Data = DateTime.MinValue, ValorProduto = 1d };
        public readonly Venda VENDA_ID_3 = new() { Id = 2, IdProduto = 2, Data = DateTime.MaxValue, ValorProduto = 1d };

        public Mock<DbSet<Venda>> Get()
        {

            var vendas = FakeDbVendas();

            var mockSetVenda = new Mock<DbSet<Venda>>();
            mockSetVenda.As<IQueryable<Venda>>().Setup(m => m.Provider).Returns(vendas.Provider);
            mockSetVenda.As<IQueryable<Venda>>().Setup(m => m.Expression).Returns(vendas.Expression);
            mockSetVenda.As<IQueryable<Venda>>().Setup(m => m.ElementType).Returns(vendas.ElementType);
            mockSetVenda.As<IQueryable<Venda>>().Setup(m => m.GetEnumerator()).Returns(vendas.GetEnumerator());

            return mockSetVenda;
        }

        private IQueryable<Venda> FakeDbVendas()
        {
            return new List<Venda>
            {
                    VENDA_ID_1,
                    VENDA_ID_2,
                    VENDA_ID_3

            }.AsQueryable();
        }
    }
}






