using DSS.Entityes;

namespace DSS.Repositories.Absractions
{
    public interface ITaskEntityRepository
    {
        Task<bool> CreateTask(Task task);
        Task<bool> DeleteTask(Task task);
        Task<bool> GetAllUnconfirmedEmail();
        Task<int> GetCountWithUnconfirmedEmail();

        Task<List<TaskEntity>> GetAllUncompletedTask();
        Task GetUsersWithThreeUncompletedTask();
    }
}
