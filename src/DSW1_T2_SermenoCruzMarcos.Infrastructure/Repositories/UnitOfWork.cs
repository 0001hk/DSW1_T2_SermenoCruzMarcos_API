using DSW1_T2_SermenoCruzMarcos.Infrastructure.Persistence;
using DSW1_T2_SermenoCruzMarcos.Domain.Ports.Out;

namespace DSW1_T2_SermenoCruzMarcos.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IBookRepository? _books;
        private ILoanRepository? _loans;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IBookRepository Books => _books ??= new BookRepository(_context);
        public ILoanRepository Loans => _loans ??= new LoanRepository(_context);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}