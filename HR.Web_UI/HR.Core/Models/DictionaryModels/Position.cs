
using HR.Core.BasicContract;
namespace HR.Core.Models.DictionaryModels
{
    /// <summary>
    /// Slownik zawierajacy stanowiska ktore mozna objac w firmie
    /// </summary>
    public class Position : BaseEntity<long>
    {
        /// <summary>
        /// Nazwa obejnowanej pozycji
        /// </summary>
        public string Name { get; set; } // nie zmieniac na enum, zeby latwo mozna bylo dodawac pozycje
    }
}
