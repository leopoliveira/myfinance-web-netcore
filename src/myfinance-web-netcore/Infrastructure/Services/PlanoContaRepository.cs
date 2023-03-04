using myfinance_web_netcore.Domain.Entities;
using myfinance_web_netcore.Domain.Services;
using myfinance_web_netcore.Infrastructure.ApplicationDbContext;

namespace myfinance_web_netcore.Infrastructure.Services
{
    public class PlanoContaRepository : GenericRepository<PlanoConta>, IPlanoContaRepository
    {
        public PlanoContaRepository(AppDbContext context) : base(context)
        {
        }
    }
}