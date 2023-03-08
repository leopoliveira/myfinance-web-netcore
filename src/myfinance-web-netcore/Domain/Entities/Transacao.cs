using System.ComponentModel.DataAnnotations.Schema;

namespace myfinance_web_netcore.Domain.Entities
{
    public class Transacao : GenericEntity
    {
        [Column(TypeName = "datetime2")]
        public DateTime Data { get; set; }

        [Column(TypeName = "decimal(9, 2)")]
        public decimal Valor { get; set; }

        public string? Historico { get; set; }

        public int PlanoContaId { get; set; }

        [ForeignKey("PlanoContaId")]
        public PlanoConta PlanoConta { get; set; }
    }
}