using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_netcore.Models
{
    public class TransacaoViewModel
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public decimal Valor { get; set; }

        public string? Historico { get; set; }

        public int PlanoContaId { get; set; }

        public PlanoContaViewModel PlanoConta { get; set; }

        public IEnumerable<SelectListItem> PlanoContas { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}