using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain.Entities;
using myfinance_web_netcore.Domain.Services;
using myfinance_web_netcore.Infrastructure.ApplicationDbContext;

namespace myfinance_web_netcore.Infrastructure.Services
{
    public class PlanoContaRepository : GenericRepository<PlanoConta>, IPlanoContaRepository
    {
        private readonly AppDbContext _context;

        public PlanoContaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<PlanoConta>> GetAll()
        {
            return await _context.PlanoConta
                .OrderBy(p => p.Descricao)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}