using Produto.Application.UserCases.Commands;

namespace Produto.Application.UserCases.Handlers
{
    public interface IProcessarProdutoHandler
    {
        RequestResult Handle(ProcessarProdutoCommand command);
    }
}