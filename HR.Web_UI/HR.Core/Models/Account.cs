using HR.Core.BasicContract;
using HR.Core.Enums;

namespace HR.Core.Models
{
    public class Account : BaseEntity<long>
    {
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual byte[] Photo { get; set; }
        public virtual AccountType AccountType { get; set; }
    }
}
