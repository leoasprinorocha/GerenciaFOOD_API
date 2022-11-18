using Produto.Application.UserCases.Commands;

namespace Produto.Application.UserCases.Handlers
{
    public interface IHandler<in T> where T : ICommand
    {
        Task<RequestResult> Handle(T command);
    }
}