
using HR.Core.BasicContract;
namespace HR.Core.Models
{
    public class Position : BaseEntity<long>
    {
        public string Name { get; set; } // nie zmieniac na enum, zeby latwo mozna bylo dodawac pozycje
    }
}
