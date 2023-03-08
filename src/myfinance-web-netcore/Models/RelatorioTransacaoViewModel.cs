namespace myfinance_web_netcore.Models
{
    public class RelatorioTransacaoViewModel
    {
        public IEnumerable<TransacaoViewModel>? Receitas { get; set; }

        public decimal TotalReceitas { get; set; }

        public IEnumerable<TransacaoViewModel>? Despesas { get; set; }

        public decimal TotalDespesas { get; set; }
    }
}