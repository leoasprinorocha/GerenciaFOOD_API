using Produto.Domain.Enums;

namespace Produto.Application.DTOs
{
    public class ProdutoDTO
    {
        public string Descricao { get; set; }
        public double CustoCompra { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public TipoProduto Tipo { get; set; }
    }
}