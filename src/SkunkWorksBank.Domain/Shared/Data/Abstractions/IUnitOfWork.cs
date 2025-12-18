namespace SkunkWorksBank.Domain.Shared.Data.Abstractions
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
