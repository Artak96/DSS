using DSS.Data.Context;
using DSS.Repositories.Absractions;

namespace DSS.Repositories.Implimentations
{
    public class TaskEntityRepository : ITaskEntityRepository
    {
        private readonly DSSDbContext _dbContext;

        public TaskEntityRepository(DSSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
