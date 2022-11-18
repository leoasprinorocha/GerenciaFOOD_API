using Produto.Application.UserCases.Commands;
using Produto.Application.UserCases.Handlers;

namespace Produto.Application.Repositories
{
    public interface IProdutoRepository
    {
        Task<RequestResult> RecuperaProduto(ICommand command);
    }
}