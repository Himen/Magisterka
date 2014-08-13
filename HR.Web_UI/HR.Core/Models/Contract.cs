
using HR.Core.BasicContract;
namespace HR.Core.Models
{
    public class Contract:BaseEntity<long>
    {
        public long IdEmployment { get; set; }
        public decimal? MonthBenefit { get; set; }
        public decimal? BenefitPerHour { get; set; }

        public virtual Employment Employment { get; set; }
    }
}
