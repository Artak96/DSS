using DSS.Entityes;

namespace DSS.Repositories.Absractions
{
    public interface IUserRepository
    {
        Task AddUser(User user);
    }
}
