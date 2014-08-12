using HR.Core.Enums;

namespace HR.Core.Models
{
    public class Account
    {
        public virtual long Id { get; set; }
        public virtual int DataState { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual byte[] Photo { get; set; }
        public virtual AccountType AccountType { get; set; }
    }
}
