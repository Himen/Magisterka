
using HR.Core.BasicContract;
namespace HR.Core.Models
{
    public class BankAccount : BaseEntity<long>
    {
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public long AccountNumber { get; set; }
    }
}
