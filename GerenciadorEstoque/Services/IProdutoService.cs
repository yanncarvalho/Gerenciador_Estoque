using GerenciadorEstoque.Models;
using GerenciadorEstoque.Dto;

namespace GerenciadorEstoque.Services
{
    public interface IProdutoService
    {
      public void Cadastrar(Produto produto);

      public Produto[] BuscarTodos();

      public ProdPorIdDto? BuscarPorId(int? id);

      public void Remover(int id);

    }
}
