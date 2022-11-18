using Produto.Domain.Enums;

namespace Produto.Domain.Entities

{
    public class ProdutoEntity : EntityBase
    {
        public ProdutoEntity(string descricao, double custoCompra, int quantidadeEmEstoque, TipoProduto tipo)
        {
            Descricao = descricao;
            CustoCompra = custoCompra;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            Tipo = tipo;
        }

        public string Descricao { get; private set; }
        public double CustoCompra { get; private set; }
        public string FotoProdutoBase64 { get; private set; }
        public int QuantidadeEmEstoque { get; private set; }
        public TipoProduto Tipo { get; private set; }
        public bool EhValido => Validacao();
        public bool CustoDeCompraVazio => CustoCompraPodeSerNuloBaseadoNoTipo();
        public bool FotoPodeSerVazia => FotoPodeSerVaziaBaseadoNoTipo();

        private bool Validacao()
        {
            return !string.IsNullOrEmpty(this.Descricao);
        }

        private bool CustoCompraPodeSerNuloBaseadoNoTipo() =>
            this.Tipo == TipoProduto.InsumoParaConsumivel || this.Tipo == TipoProduto.Manutencao;

        private bool FotoPodeSerVaziaBaseadoNoTipo() =>
        this.Tipo != TipoProduto.ConsumivelFinal;
    }
}