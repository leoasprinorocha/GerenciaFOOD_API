using Produto.Application.DTOs;
using Produto.Domain.Entities;

namespace Produto.Application.UserCases.Tools
{
    public partial class EntityMapper
    {
        public static ProdutoEntity ParseProduto(ProdutoDTO produtoDTO, string fotoProdutoBase64)
        {
            return new ProdutoEntity(
               descricao: produtoDTO.Descricao,
               custoCompra: produtoDTO.CustoCompra,
               quantidadeEmEstoque: produtoDTO.QuantidadeEmEstoque,
               tipo: produtoDTO.Tipo
            );
        }
    }
}