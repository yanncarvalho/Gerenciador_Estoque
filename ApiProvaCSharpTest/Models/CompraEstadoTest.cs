using ApiProvaCSharp.Models;
using System;
using Xunit;

namespace ApiProvaCSharpTest.Models
{
    public class CompraEstadoTest
    {
        private readonly Random _genValor = new();

        [Fact(DisplayName = "Quando compra estado é >= 100 Retorna aprovado")]
        public void Quando_CompraEstado_MaiorIgual100_Retorna_Aprovado()
        {
            var valor = _genValor.Next(100, int.MaxValue);

            Assert.Equal(CompraEstado.Status.APROVADO, CompraEstado.Get(valor));
        }

        [Fact(DisplayName = "Quando compra estado é < 100 Retorna reprovado")]
        public void Quando_CompraEstado_Menor100_Retorna_Reprovado()
        {
            var valor = _genValor.Next(1, 99);

            Assert.Equal(CompraEstado.Status.REJEITADO, CompraEstado.Get(valor));
        }
    }
}
