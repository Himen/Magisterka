
using HR.Core.BasicContract;
namespace HR.Core.Models
{
    public class OrganiziationalUnit : BaseEntity<long>
    {
        public string Name { get; set; }
        public long IdManager { get; set; }

        public virtual Person Manager { get; set; }
    }
}
