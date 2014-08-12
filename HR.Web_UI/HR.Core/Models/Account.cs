using HR.Core.Enums;

namespace HR.Core.Models
{
    public class Account
    {
        public long Id { get; set; }
        public int DataState { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public AccountType AccountType { get; set; }
    }
}
