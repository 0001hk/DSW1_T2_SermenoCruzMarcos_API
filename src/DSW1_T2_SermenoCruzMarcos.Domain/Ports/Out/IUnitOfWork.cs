namespace DSW1_T2_SermenoCruzMarcos.Domain.Ports.Out
{
    public interface IUnitOfWork
    {
        IBookRepository Books { get; }
        ILoanRepository Loans { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}