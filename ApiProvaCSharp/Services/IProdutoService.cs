using ApiProvaCSharp.Models;
using ApiProvaSharp.Dto;

namespace ApiProvaCSharp.Services
{
    public interface IProdutoService
    {
      public bool cadastrar(Produto produto);

      public Produto[] buscarTodos();

      public ProdutoPorId buscarPorId(int id);

     public bool Remover(int id);
    }
}
