
using GerenciadorEstoque.ValidationAnnotations;
using System;
using Xunit;

namespace GerenciadorEstoqueTest.ValidationAnnotations
{

    public class DataCartaoCredTest
    {

      private readonly DataCartaoCred _validador = new();

       private static DateTime RandomDateTimeGen(DateTime inicial, DateTime final)
       {
            var gen = new Random();
            var end = final.Day;
            return inicial.AddDays(gen.Next(end));
       }

      
        [Fact (DisplayName = "Quando DataCartaoCred >= DataHoje Retorna válida")]
        public void Quando_DataCartaoCred_MaiorOuIgualA_DataHoje_Retorna_Valida()
        {
            var dtInicial = DateTime.Now.AddMonths(1);
            var dtRandom = RandomDateTimeGen(dtInicial, DateTime.MaxValue);
            var dtRequisicao = string.Format($"{dtRandom.Month:00}/{dtRandom.Year:0000}");

            Assert.True(_validador.IsValid(dtRequisicao));
        }


        [Fact(DisplayName = "Quando DataCartaoCred < DataHoje Retorna inválida")]
        public void Quando_DataCartaoCred_MenorQue_DataHoje_Retorna_Invalida()
        {
            var hoje = DateTime.Now;
            var dtRandom = RandomDateTimeGen(DateTime.MinValue, hoje);
            var dtRequisicao = string.Format($"{dtRandom.Month:00}/{dtRandom.Year:0000}");
            Assert.False(_validador.IsValid(dtRequisicao));
        }

    }
}
