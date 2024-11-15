using DSS.Repositories.UOW.Abstraction;
using DSS.Services.Abstractions;

namespace DSS.Services.Implimentations
{
    public class TaskEntityServic : ITaskEntityServic
    {
        private readonly IUnitOfWork _unitOfWork;
     
        public TaskEntityServic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
