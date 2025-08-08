using Valhalla.Lib.SharedKernel;
using Valhalla.Lib.Specification.EntityFrameworkCore;

namespace Trak.Infrastructure.Data.PostgreSQL
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public EfRepository(PgSqlDbContext dbContext) : base(dbContext)
        {
        }
    }
}