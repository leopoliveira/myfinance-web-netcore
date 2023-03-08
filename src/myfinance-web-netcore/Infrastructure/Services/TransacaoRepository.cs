using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain.Entities;
using myfinance_web_netcore.Domain.Services;
using myfinance_web_netcore.Infrastructure.ApplicationDbContext;

namespace myfinance_web_netcore.Infrastructure.Services
{
    public class TransacaoRepository : GenericRepository<Transacao>, ITransacaoRepository
    {
        private readonly AppDbContext _context;

        public TransacaoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Transacao>> GetAll()
        {
            return await _context.Transacao
                .OrderBy(p => p.Data)
                .Include(p => p.PlanoConta)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}