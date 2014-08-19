using HR.Core.BasicContract;
using HR.Core.Enums;

namespace HR.Core.Models
{
    /// <summary>
    /// Konto w systemie wspomagajace dzial HR
    /// </summary>
    public class Account : BaseEntity<long>
    {
        /// <summary>
        /// Nazwa uzytkownika tworzona z polaczenia imienia i nazwiska.
        /// np. Pawel_Nowak
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// Haslo do konta. Poczatkowo generowane przez system.
        /// Potem zmienione przez uzytkownika.
        /// </summary>
        public virtual string Password { get; set; }

        /// <summary>
        /// Zdjecie osoby
        /// </summary>
        public virtual byte[] Photo { get; set; }

        /// <summary>
        /// Rodzaj konta. Pracownik, Kierownik, HR
        /// </summary>
        public virtual AccountType AccountType { get; set; }

        /// <summary>
        /// Id osoby powiazanej z kontem
        /// </summary>
        public virtual long PersonId { get; set; }

        /// <summary>
        /// Osoba powiazana z kontem
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
