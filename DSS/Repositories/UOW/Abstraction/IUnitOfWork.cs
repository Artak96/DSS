using DSS.Repositories.Absractions;

namespace DSS.Repositories.UOW.Abstraction
{
    public interface IUnitOfWork
    {
        ITaskEntityRepository TaskEntityRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
