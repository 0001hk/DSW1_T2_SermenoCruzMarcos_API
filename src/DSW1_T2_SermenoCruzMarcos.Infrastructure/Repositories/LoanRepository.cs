using DSW1_T2_SermenoCruzMarcos.Domain.Entities;
using DSW1_T2_SermenoCruzMarcos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using DSW1_T2_SermenoCruzMarcos.Domain.Ports.Out;

namespace DSW1_T2_SermenoCruzMarcos.Infrastructure.Repositories
{
    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        public LoanRepository(ApplicationDbContext context) : base(context)
        {
        }
        public new async Task<IEnumerable<Loan>> GetAllAsync()
        {
            return await _context.Loans.Include(l => l.Book).ToListAsync();
        }
    }
}