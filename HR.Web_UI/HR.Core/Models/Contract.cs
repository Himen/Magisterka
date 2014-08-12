
namespace HR.Core.Models
{
    public class Contract
    {
        public long Id { get; set; }
        public long IdEmployment { get; set; }
        public int DataState { get; set; }
        public decimal? MonthBenefit { get; set; }
        public decimal? BenefitPerHour { get; set; }

        public virtual Employment Employment { get; set; }
    }
}
