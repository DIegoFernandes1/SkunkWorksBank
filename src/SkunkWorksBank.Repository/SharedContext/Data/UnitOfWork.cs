using SkunkWorksBank.Domain.Shared.Data.Abstractions;

namespace SkunkWorksBank.Repository.SharedContext.Data
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task CommitAsync(CancellationToken cancellationToken = default)
            => await context.SaveChangesAsync();
    }
}
