using DSW1_T2_SermenoCruzMarcos.Domain.Entities;
using DSW1_T2_SermenoCruzMarcos.Domain.Ports.Out;
using DSW1_T2_SermenoCruzMarcos.Infrastructure.Persistence;

namespace DSW1_T2_SermenoCruzMarcos.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context) { }
    }
}