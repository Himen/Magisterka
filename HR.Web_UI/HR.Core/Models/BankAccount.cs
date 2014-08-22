
using HR.Core.BasicContract;
namespace HR.Core.Models
{
    /// <summary>
    /// Numer konta i nazwa na ktore przesylane jest wynagrodzenie 
    /// </summary>
    public class BankAccount : BaseEntity<long>
    {
        /// <summary>
        /// Nazwa banku
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Adres banku
        /// </summary>
        public string BankAddress { get; set; }

        /// <summary>
        /// Numer konta
        /// </summary>
        public string AccountNumber { get; set; }

        public virtual Employment Employment { get; set; }
    }
}
