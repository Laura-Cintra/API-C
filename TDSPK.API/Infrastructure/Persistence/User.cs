using TDSPK.API.Domain;
using TDSPK.API.Domain.Enums;

namespace TDSPK.API.Infrastructure.Persistence
{
    public class User : Audit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }      

        public User()
        {
            Status = StatusType.Active;
        }
    }
}
