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

        public PlanoContaViewModel PlanoDeConta { get; set; }

        public ICollection<PlanoContaViewModel>? PlanoContas { get; set; } = new List<PlanoContaViewModel>();
    }
}