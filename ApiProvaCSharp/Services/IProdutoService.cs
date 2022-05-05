using ApiProvaCSharp.Models;
using ApiProvaCSharp.Dto;

namespace ApiProvaCSharp.Services
{
    public interface IProdutoService
    {
      public void Cadastrar(Produto produto);

      public Produto[] BuscarTodos();

      public ProdPorIdDto? BuscarPorId(int? id);

      public void Remover(int id);

    }
}
