using DSS.Enums;

namespace DSS.Entityes
{
    public class TaskEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskEnum Status { get; set; }
        public DateTime CratedDate { get; set; }
        public DateTime ModifyiedDate { get; set; }

        public User User { get; set; }
        public long UserId { get; set; }

        public TaskEntity()
        {
                
        }
    }
}
