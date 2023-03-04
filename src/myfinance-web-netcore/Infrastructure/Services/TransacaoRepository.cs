using myfinance_web_netcore.Domain.Entities;
using myfinance_web_netcore.Domain.Services;
using myfinance_web_netcore.Infrastructure.ApplicationDbContext;

namespace myfinance_web_netcore.Infrastructure.Services
{
    public class TransacaoRepository : GenericRepository<Transacao>, ITransacaoRepository
    {
        public TransacaoRepository(AppDbContext context) : base(context)
        {
        }
    }
}