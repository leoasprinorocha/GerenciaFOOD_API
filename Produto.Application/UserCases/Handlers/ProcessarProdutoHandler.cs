using Produto.Application.Repositories;
using Produto.Application.UserCases.Commands;

namespace Produto.Application.UserCases.Handlers
{
    public class ProcessarProdutoHandler : IHandler<ProcessarProdutoCommand>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProcessarProdutoHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<RequestResult> Handle(ProcessarProdutoCommand command)
        {
            var produtoResult = await _produtoRepository.RecuperaProduto(command);
            return produtoResult;
        }
    }
}