using DSS.Data.Context;
using DSS.Repositories.Absractions;
using DSS.Repositories.Implimentations;
using DSS.Repositories.UOW.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace DSS.Repositories.UOW.Implimentation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DSSDbContext _dbContext;
        public UnitOfWork(DSSDbContext dbContext)
        {
            _dbContext = dbContext;                
        }


        private TaskEntityRepository? _task;
        public ITaskEntityRepository TaskEntityRepository => _task ??= new TaskEntityRepository(_dbContext);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch
            {
                throw;
            }
        }
    }
}
