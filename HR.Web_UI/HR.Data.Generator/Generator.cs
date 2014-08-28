using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.Core.Models;
using HR.Core.Models.DictionaryModels;
using System.IO;
using HR.Core.Enums;

namespace HR.Data.Generator
{
    public class Generator
    {
        Random r;
        public Generator()
        {
             r= new Random();
        }

        public List<Position> Positions = new List<Position>
        {
            new Position {Id="AB" ,Name ="Analityk biznesowy"},
            new Position {Id="D" ,Name ="Dyrektor"},
            new Position {Id="DO" ,Name ="Dozorca"},
            new Position {Id="G" ,Name ="Grafik"},
            new Position {Id="K" ,Name ="Księgowa"},
            new Position {Id="KZ" ,Name ="Kierownik zespołu"},
            new Position {Id="MPJ" ,Name ="Młodszy programista Java"},
            new Position {Id="MPN" ,Name ="Młodszy programista .NET"},
            new Position {Id="MPP" ,Name ="Młodszy programista Python"},
            new Position {Id="MPR" ,Name ="Młodszy programista Ruby"},
            new Position {Id="MPC" ,Name ="Młodszy programista Cobol"},
            new Position {Id="MR" ,Name ="Młodszy rekruter"},
            new Position {Id="O" ,Name ="Ochroniarz"},
            new Position {Id="PJ" ,Name ="Programista Java"},
            new Position {Id="PN" ,Name ="Programista .NET"},
            new Position {Id="PP" ,Name ="Programista Pyton"},
            new Position {Id="PR" ,Name ="Programista Ruby"},
            new Position {Id="PC" ,Name ="Programista Cobol"},
            new Position {Id="R" ,Name ="Rekruter"},
            new Position {Id="S" ,Name ="Sprzątaczka"},
            new Position {Id="SPJ" ,Name ="Starszy programista Java"},
            new Position {Id="SPN" ,Name ="Starszy programista .NET"},
            new Position {Id="SPP" ,Name ="Starszy programista Pyton"},
            new Position {Id="SPR" ,Name ="Starszy programista Ruby"},
            new Position {Id="SPC" ,Name ="Starszy programista Cobol"},
            new Position {Id="T" ,Name ="Tester"},
            new Position {Id="WD" ,Name ="Wicedyrektor"}
        };

        public List<OrganiziationalUnit> OrganiziationalUnits = new List<OrganiziationalUnit>
        {
            new OrganiziationalUnit { Id="RN", Name="Rada Nadzorcza"},
            new OrganiziationalUnit { Id="DH", Name="Dział Human Resource"},
            new OrganiziationalUnit { Id="DK", Name="Dział Księgowy"},
            new OrganiziationalUnit { Id="DA", Name="Dział Administracyjny"},
            new OrganiziationalUnit { Id="DT", Name="Dział Testerów"},
            new OrganiziationalUnit { Id="DPJ", Name="Dział Programistów Java"},
            new OrganiziationalUnit { Id="DPN", Name="Dział Programistów .NET"},
            new OrganiziationalUnit { Id="DPP", Name="Dział Programistów Python"},
            new OrganiziationalUnit { Id="DPR", Name="Dział Programistów Ruby"},
            new OrganiziationalUnit { Id="DPC", Name="Dział Programistów Cobol"}
        };

        public List<Training> Tranings = new List<Training> 
        {
            new Training {Name = "Kurs języka angielskiego", Type=TrainingType.Certyfikat, Description="Odbycie kursu języka angielskiego. I zdobycie certyfikatu B2"}, 
            new Training {Name = "Kurs języka niemieckiego", Type=TrainingType.Certyfikat, Description="Odbycie kursu języka niemieckiego. I zdobycie certyfikatu B2"},
            new Training {Name = "Kurs języka rosyjskiego", Type=TrainingType.Certyfikat, Description="Odbycie kursu języka rosyjskiego. I zdobycie certyfikatu B2"},
            new Training {Name = "Warsztaty z umiejętności miękich", Type=TrainingType.Warsztat, Description="Warsztaty polegające na zwiekszeniu swoich umiejętności wypowiadania się oraz zadawania dokładnych pytań"},
            new Training {Name = "Kurs pierwszej pomocy", Type=TrainingType.Szkolenie, Description="Podstawowa umiejętność udzielania pierwszej pomocy"},
            new Training {Name = "Programming in HTML5 with JavaScript and CSS3", Type=TrainingType.Certyfikat, Description="Oficialny certyfikat Microsoftu. Obejmuje on podstawową znajomość HTML, CSS oraz JS."},
            new Training {Name = "Developing ASP.NET MVC 4 Web Applications", Type=TrainingType.Certyfikat, Description="Oficialny certyfikat Microsoftu. Osoba posiadająca ten certyfikat, posiada doświadczenie w programowaniu aplikacji przy pomocy ASP MVC 4."},
            new Training {Name = "Developing Microsoft Azure and Web Services", Type=TrainingType.Certyfikat, Description="Oficialny certyfikat Microsoftu. Informuje, że osoba posiada dużą wiedzę o serwisach REST-owych i SOAP-owych, zna również chmurę Azure."},
            new Training {Name = "Querying Microsoft SQL Server 2012", Type=TrainingType.Certyfikat, Description="Oficialny certyfikat Microsoftu. Osoba mająca go potrafi wykonywać skomplikowane zapytania w SQL."},
            new Training {Name = "Administering Microsoft SQL Server 2012 Databases", Type=TrainingType.Certyfikat, Description="Oficialny certyfikat Microsoftu. Mając ten certyfikat osoba potwierdza swoją wiedzę z administracji serwerami bazodanowymi firmy Microsoft."},
            new Training {Name = "Implementing a Data Warehouse with Microsoft SQL Server 2012", Type=TrainingType.Certyfikat, Description="Oficialny certyfikat Microsoftu. Zdanie go, potwierdza wiedzę o magazynach baz danych i wykorzystaniu ich."},
            new Training {Name = "Microsoft Office Specialist (MOS) Expert", Type=TrainingType.Certyfikat, Description="Oficialny certyfikat Microsoftu. Osoba posiada duże doświadczenie z korzystania z aplikacji biurowych z pakietu office."}
        };

        public List<CollegesDictionary> Colleges = new List<CollegesDictionary>
        {
            new CollegesDictionary{Address="gen. Jana Henryka Dąbrowskiego 69",City="Częstochowa",Country ="Polska",Name="Politechnika Częstochowska"},
            new CollegesDictionary{Address="ul. Waszyngtona 4/8",City="Częstochowa",Country ="Polska",Name="Akademia Jana Długosza"},
            new CollegesDictionary{Address="Aleja Adama Mickiewicza 30",City="Kraków",Country ="Polska",Name="Akademia Górniczo hutnicza"},
            new CollegesDictionary{Address="Warszawska 24",City="Kraków",Country ="Polska",Name="Politechnika Krakowska"},
            new CollegesDictionary{Address="ul. Gołębia 24",City="Kraków",Country ="Polska",Name="Uniwersytet Jagieloński"},
            new CollegesDictionary{Address="wybrzeże Stanisława Wyspiańskiego 27",City="Wrocław",Country ="Polska",Name="Politechnika Wrocławska"},
            new CollegesDictionary{Address="ul. Bażyńskiego 1a",City="Gdańsk",Country ="Polska",Name="Uniwersytet Gdański"},
            new CollegesDictionary{Address="ul. Wieniawskiego 1",City="Poznań",Country ="Polska",Name="Uniwersytet Adama Mickiewicza"},
            new CollegesDictionary{Address="ul. Krakowskie Przedmieście 26/28",City="Warszawa",Country ="Polska",Name="Uniwersystet Warszawski"},
            new CollegesDictionary{Address="Akademicka 2A",City="Gliwice",Country ="Polska",Name="Politechnika Śląska"},
            new CollegesDictionary{Address="ul. Żeromskiego 116",City="Łódź",Country ="Polska",Name="Politechnika Łódzka"},
            new CollegesDictionary{Address="Wiejska 45a",City="Białystok",Country ="Polska",Name="Politechnika Białostocka"},
            new CollegesDictionary{Address="Śniadeckich 2",City="Koszalin",Country ="Polska",Name="Politechnika Koszalinska"},
            new CollegesDictionary{Address="Birmingham City University",City="Birmingham",Country ="Anglia",Name="Politechnika Częstochowska"},
            new CollegesDictionary{Address="Wellington Square, Oxford OX1 2JD",City="Oxford",Country ="Anglia",Name="University of Oxford"},
            new CollegesDictionary{Address="Cambridge CB2 1TN",City="Cambrige ",Country ="Anglia",Name="University of Cambridge"},
            new CollegesDictionary{Address="Fife KY16 9AJ",City="St Andrews",Country ="Szkocja",Name="University of St Andrews"},
            new CollegesDictionary{Address="LA1 4YW",City="Lancaster",Country ="Anglia",Name="Lancaster University"},
            new CollegesDictionary{Address="Via Zamboni, 33",City="Bologna",Country ="Włochy",Name="Università di Bologna"},
            new CollegesDictionary{Address="Piazzale Aldo Moro, 5",City="Roma",Country ="Włochy",Name="La Sapienza – Università di Roma"},
            new CollegesDictionary{Address="Piazza Leonardo Da Vinci, 32",City="Milano",Country ="Włochy",Name="Politecnico di Milano"},
            new CollegesDictionary{Address="Route de Saclay",City="Palaiseau",Country ="Francja",Name="École Polytechnique"},
            new CollegesDictionary{Address="1 Rue de la Libération",City="Paris",Country ="Francja",Name="HEC Paris"},
            new CollegesDictionary{Address="Boulevard de Constance",City="Fontainebleau",Country ="Francja",Name="INSEAD"}
            
        };

        public List<BankDictionary> Banks = new List<BankDictionary> 
        {
            new BankDictionary {Address="ul. Łopuszańska 38d 02-232 Warszawa",Name="Alior Bank"},
            new BankDictionary {Address="ul. płk. Jana Pałubickiego 2 80-175 Gdańsk",Name="Bank BPH"},
            new BankDictionary {Address="ul. Stanisława Żaryna 2A 02-593 Warszawa ",Name="Bank Millennium"},
            new BankDictionary {Address="ul. Żelazna 32, 00-832 Warszawa",Name="Bank Ochrony Środowiska"},
            new BankDictionary {Address="ul. Grzybowska 53/57 Warszawa ",Name="Bank Pekao"},
            new BankDictionary {Address="ul. Przyokopowa 33 01-208 Warszawa",Name="Getin Noble Bank"},
            new BankDictionary {Address="ul. Sokolska 34, 40-086 Katowice",Name="ING Bank Śląski"},
            new BankDictionary {Address="ul. Senatorska 18, Warszawa",Name="mBank"},
            new BankDictionary {Address="ul. Strzegomska 42c 53-611 Wrocław",Name="Santander Consumer Bank"},
            new BankDictionary {Address="ul. Piękna 20, 00-549 Warszawa",Name="Raiffeisen Polbank"},
            new BankDictionary {Address="al. Armii Ludowej 26 00-609 Warszawa",Name="Credit Agricole Bank Polska"},
            new BankDictionary {Address="pl. Orląt Lwowskich 1, Wrocław 53-605",Name="Deutsche Bank Polska"},
            new BankDictionary {Address="ul. Kielecka 2 81-303 Gdynia",Name="Nordea Bank Polska"},
            new BankDictionary {Address="ul. Św. Mikołaja 72, 50-126 Wrocław",Name="Euro Bank"},
            new BankDictionary {Address="ul. Rynek 9/11 50-950 Wrocław",Name="Bank Zachodni WBK"},
            new BankDictionary {Address="ul. Postępu 15C, 02-676 Warszawa",Name="DNB Bank Polska S.A."}
        };

        public List<string> Imiona = new List<string>
        {
            "Ada", "Agata", "Agnieszka", "Aleksandra", "Alicja", "Andżelika", "Aneta", "Anita", "Anna", "Barbara", "Beata", "Bernadeta", "Blanka", "Bożena",
            "Cecylia", "Celina", "Dagmara", "Danuta", "Dominika", "Dorota", "Edyta", "Eliza", "Elżbieta", "Emilia", "Ewa", "Ewelina", "Felicja", "Grażyna",
            "Halina", "Helena", "Ilona", "Iwona", "Izabela", "Joanna", "Jolanta", "Julia", "Justyna", "Karolina", "Katarzyna", "Kinga", "Klaudia", "Krystyna",
            "Laura", "Lucyna", "Łucja", "Magdalena", "Małgorzata", "Maria", "Marta", "Marzena", "Monika", "Natalia", "Nina", "Olga", "Patrycja", "Paulina",
            "Renata", "Sabina", "Sylwia", "Teresa", "Urszula", "Weronika", "Wiktoria", "Zofia","Żaneta",

            "Adam","Adrian","Aleksander","Andrzej","Arkadiusz","Artur", "Bogusław","Bolesław", "Cezary","Cyprian","Czesław","Damian","Daniel","Dariusz","Dawid",
            "Emil","Eryk","Filip","Grzegorz","Hubert","Ireneusz","Jacek","Jakub","Jan", "Kamil","Karol","Konrad","Krzysztof", "Leszek", "Łukasz", "Maciej","Marcin","Marek",
            "Mariusz","Mateusz","Michał","Mirosław","Norbert","Patryk","Paweł","Piotr","Radosław","Rafał","Robert", "Szymon", "Tomasz", "Wojciech", "Zbigniew"
        };
        public List<string> Nazwiska = new List<string>
        {
            "Nowak","Kowalski","Wiśniewski","Wójcik","Kowalczyk","Kamiński","Lewandowski","Zieliński","Szymański","Woźniak","Dąbrowski","Kozłowski","Jankowski",
            "Mazur","Wojciechowski","Kwiatkowski","Krawczyk","Kaczmarek","Piotrowski","Grabowski","Zając","Pawłowski","Michalski","Król","Wieczorek","Jabłoński",
            "Wróbel","Nowakowski","Majewski","Olszewski","Stępień","Malinowski","Jaworski","Adamczyk","Dudek","Nowicki","Pawlak","Górski","Witkowski","Walczak",
            "Sikora", "Baran","Rutkowski","Michalak","Szewczyk","Ostrowski","Tomaszewski","Pietrzak","Zalewski","Wróblewski","Marciniak","Jasiński","Zawadzki",
            "Bąk","Jakubowski","Sadowski","Duda","Włodarczyk","Chmielewski","Borkowski","Sokołowski","Szczepański","Sawicki","Kucharski","Lis","Maciejewski",
            "Kubiak", "Kalinowski", "Mazurek","Wysocki", "Kołodziej","Kaźmierczak", "Czarnecki" , "Sobczak","Konieczny","Urbański","Głowacki","Wasilewski","Sikorski",
            "Zakrzewski","Krajewski","Krupa","Laskowski","Ziółkowski" ,"Gajewski" ,"Mróz" ,"Brzeziński","Szulc","Szymczak","Makowski","Baranowski","Przybylski",
            "Kaczmarczyk","Borowski","Błaszyk","Adamski","Górecki","Chojnacki","Kania" 

        };

        public List<CompaniesDictionary> Companies = new List<CompaniesDictionary> 
        {
            new CompaniesDictionary{Name="Kamsoft",Country="Polska",Address=" ul. 1 Maja 133, Katowice",About=""},
            new CompaniesDictionary{Name="EPAM",Country="Węgry",Address="Futó utca 47, Budapest",About=""},
            new CompaniesDictionary{Name="Accenture",Country="Polska",Address="Warszawa ul. Sienna 39",About=""},
            new CompaniesDictionary{Name="X-Kom",Country="Polska",Address="42-202 Częstochowa ul. Krakowska 45/56A",About=""},
            new CompaniesDictionary{Name="EbiCom",Country="Polska",Address="ul. Sokolska 65 40-087 Katowice",About=""},
            new CompaniesDictionary{Name="Future Processing",Country="Polska",Address="ul. Sokolska 65 40-087 Katowice",About=""},
            new CompaniesDictionary{Name="Microsoft",Country="Polska",Address="ul. Sokolska 65 40-087 Katowice",About=""},
            new CompaniesDictionary{Name="Asseco",Country="Polska",Address="ul. Sokolska 65 40-087 Katowice",About=""},
            new CompaniesDictionary{Name="IBM",Country="Polska",Address="ul. Sokolska 65 40-087 Katowice",About=""},
            new CompaniesDictionary{Name="Comarch",Country="Polska",Address="ul. Sokolska 65 40-087 Katowice",About=""},
            new CompaniesDictionary{Name="HP",Country="Polska",Address="ul. Sokolska 65 40-087 Katowice",About=""},
            new CompaniesDictionary{Name="Ericpol",Country="Polska",Address="ul. Sokolska 65 40-087 Katowice",About=""},
            new CompaniesDictionary{Name="Sii",Country="Polska",Address="ul. Sokolska 65 40-087 Katowice",About=""}

        };

        public List<long> Payment = new List<long> { 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };
        public List<long> PaymentPerHour = new List<long> { 10,15,18,20,25,28,30,35,40,45,50 };
        public Dictionary<string, string> FieldsOfStudies = new Dictionary<string, string>
        {
            {"Aplikacje internetowe","Informatyka"},
            {"Sieci komputerowe","Informatyka"},
            {"Aplikacje biznesowe","Informatyka"},
            {"Inżynieria oprogramowania","Informatyka"}, 
            {"Informatyka i Ekonometria","Literatura"},
            {"Fizyka przemysłowa","Fizyka"},
            {"Mechanika samochodów","Mechanika"},
            {"Robotyka","Mechatronika"},
            {"Systemy sterowania","Budowa maszyn"},
            {"Księgowośc","Ekonomia"},
            {"Sociologia społeczna","Sociologia"},
            {"Literatura","Filologia polska"}
        };

        public string GeneratorBlednegoPESEL()
        {
            string pesel = null;
            for (int i = 0; i < 11; i++)
            {
                pesel += r.Next(0, 10);
            }
            return pesel;
        }

        public long GeneratorTelefonu()
        {
            string pesel = null;
            for (int i = 0; i < 9; i++)
            {
                pesel += r.Next(0, 10);
            }
            return long.Parse(pesel);
        }

        public long GeneratorBlednegoNIP()
        {
            string pesel = null;
            for (int i = 0; i < 10; i++)
            {
                pesel += r.Next(0, 10);
            }
            return long.Parse(pesel);
        }

        public string GeneratorKoduPocztowego()
        {
            string kod = null;
            kod += r.Next(0, 10);
            kod += r.Next(0, 10);
            kod += "-";
            kod += r.Next(0, 10);
            kod += r.Next(0, 10);
            kod += r.Next(0, 10);

            return kod;
        }

        public char GetLetter()
        {
            int num = r.Next(0, 26); // Zero to 25
            char let = (char)('A' + num);
            return let;
        }

        public string GeneratorBłednegoNumeruDowodu()
        {
            string numerDowodu = null;
            for (int i = 0; i < 3; i++)
			{
                numerDowodu += GetLetter();
			}

            for (int i = 0; i < 6; i++)
            {
                numerDowodu += r.Next(0, 10);
            }
            return numerDowodu;
            
        }

        public byte[] GenerateMenPhoto()
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\Hi men\Source\Repos\Magisterka\HR.Web_UI\HR.Data.Generator\Zdjecia\Mezczyzni");//Assuming Test is your Folder
            //DirectoryInfo d = new DirectoryInfo(@"C:\Users\Hi men\Desktop\Mgr\HR.Web_UI\HR.Data.Generator\Zdjecia\Mezczyzni");//Assuming Test is your Folder
            //DirectoryInfo d = new DirectoryInfo(@"C:\Users\Pawel_Chmielewski@epam.com\Source\Repos\Magisterka\HR.Web_UI\HR.Data.Generator\Zdjecia\Mezczyzni");
            FileInfo[] Files = d.GetFiles("*.jpeg"); //Getting Text files

            FileInfo fileInfo = Files[r.Next(0, 5)];

            // The byte[] to save the data in
            byte[] data = new byte[fileInfo.Length];

            // Load a filestream and put its content into the byte[]
            using (FileStream fs = fileInfo.OpenRead())
            {
                fs.Read(data, 0, data.Length);
            }

            // Delete the temporary file
            //fileInfo.Delete();

            return data;
        }
        public string GenerateAccountNumber()
        {
            string account= null;
            for (int i = 0; i < 24; i++)
            {
                account += r.Next(0, 10);
            }
            return account;
        }

        public int GenerateRandom_1_to_100()
        {
            return r.Next(1, 101);
        }

        public string GenerateRandom_City()
        {
            return Miasta.ElementAt(r.Next(0, Miasta.Count)).Key;
        }

        public CollageProgressType GenerateCollageProgress()
        {
            int x = r.Next(0, 13);
            if (x < 3)
                return CollageProgressType.Zakonczono;
            else if(x>3 && x<6)
                return CollageProgressType.Nie_ukonczono;
            else if(x>6 && x<9)
                return CollageProgressType.Urlop_dziekanski;
            else
                return CollageProgressType.W_trakcie;
        }

        public long GenerateRandom_Payment()
        {
            return Payment.ElementAt(r.Next(0, Payment.Count));
        }

        public long GenerateRandom_HourPayment()
        {
            return Payment.ElementAt(r.Next(0, Payment.Count));
        }

        public byte[] GenerateWomenPhoto()
        {
            //DirectoryInfo d = new DirectoryInfo(@"C:\Users\Pawel_Chmielewski@epam.com\Source\Repos\Magisterka\HR.Web_UI\HR.Data.Generator\Zdjecia\Kobiety");//Assuming Test is your Folder
            
            //DirectoryInfo d = new DirectoryInfo(@"C:\Users\Hi men\Desktop\Mgr\HR.Web_UI\HR.Data.Generator\Zdjecia\Kobiety");
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\Hi men\Source\Repos\Magisterka\HR.Web_UI\HR.Data.Generator\Zdjecia\Kobiety");
            FileInfo[] Files = d.GetFiles("*.jpeg"); //Getting Text files

            FileInfo fileInfo = Files[r.Next(0, 5)];

            // The byte[] to save the data in
            byte[] data = new byte[fileInfo.Length];

            // Load a filestream and put its content into the byte[]
            using (FileStream fs = fileInfo.OpenRead())
            {
                fs.Read(data, 0, data.Length);
            }

            // Delete the temporary file
            //fileInfo.Delete();

            return data;
        }

        public DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1);

            int range = (DateTime.Today - start).Days;
            return start.AddDays(r.Next(range));
        }

        public DateTime RandomDay(DateTime d)
        {
            int range = (DateTime.Today - d).Days;
            return d.AddDays(r.Next(range));
        }

        public string RandomFirstName()
        {
             return Imiona[r.Next(0, Imiona.Count)];
        }

        public Training RandomTraining()
        {
            return Tranings[r.Next(0, Tranings.Count)];
        }

        public CompaniesDictionary RandomCompanyName()
        {
            return Companies[r.Next(0, Companies.Count)];
        }

        public Position RandomPosition()
        {
            return Positions[r.Next(0, Positions.Count)];
        }

        public string RandomSurname()
        {
            return Nazwiska[r.Next(0, Nazwiska.Count)];
        }
        public string RandomStreet()
        {
            return Ulice[r.Next(0, Ulice.Count)];
        }
        public string RandomDomain()
        {
            return Domain[r.Next(0, Domain.Count)];
        }

        public KeyValuePair<string,string> RandomFieldOfStudy()
        {
            return FieldsOfStudies.ElementAt(r.Next(0, FieldsOfStudies.Count));
        }

        public CollegesDictionary RandomCollege()
        {
            return Colleges[r.Next(0, Colleges.Count)];
        }


        public BankDictionary RandomBank()
        {
            return Banks[r.Next(0, Banks.Count)];
        }


        public List<Person> GeneratePersons(int count)
        {
            List<Person> p = new List<Person>();

            
            for (int i = 0; i < count; i++)
            {
                Person p1 =  new Person (){ 
                                  ApartmentNumber = GenerateRandom_1_to_100(), 
                                  BuildingNumber = GenerateRandom_1_to_100(), 
                                  City = GenerateRandom_City (),
                                  DateOfBirth = RandomDay(),
                                  FirstName = RandomFirstName(),
                                  IDCard = GeneratorBłednegoNumeruDowodu(), 
                                  NIP = GeneratorBlednegoNIP(),
                                  PESEL = GeneratorBlednegoPESEL(),
                                  Phone = GeneratorTelefonu(),
                                  PostalCode = GeneratorKoduPocztowego(),
                                  Street = RandomStreet(),
                                  Surname = RandomSurname()
                                  };

                p1.Email = p1.FirstName + "_" + p1.Surname + "_" + GenerateRandom_1_to_100() + RandomDomain();
                while (p.Select(c => c.Email).Equals(p1.Email))
                {
                    p1.Email = p1.FirstName + "_" + p1.Surname + "_" + GenerateRandom_1_to_100() + RandomDomain();
                }

                p1.Account = new Account() { AccountType = Core.Enums.AccountType.Pracownik, Password = "zaq", UserName = p1.Email };
                p1.Account.Photo = p1.FirstName.Last() =='a'  ? GenerateWomenPhoto() : GenerateMenPhoto();
                p1.Account.AccountLogs = new List<AccountLog>();
                p1.Account.AccountLogs.Add(new AccountLog ()
                                            {  
                                                Action = "Dodano pracownika "+ p1.FirstName + " " + p1.Surname, 
                                                ActionDescription="Dodano nowego pracownika dnia "+ DateTime.Now,
                                                ActionType = Core.Enums.ActionType.StworzenieKonta,
                                                StartDate = DateTime.Now,
                                                EndDate = DateTime.Now
                                            });
                p1.AdditionalInformation = new AdditionalInformation()
                                               {
                                                   FacebookAccount = r.Next(0, 100) > 50 ? "https://www.facebook.com/" + p1.FirstName.ToLower() + "." + p1.Surname.ToLower() + GenerateRandom_1_to_100() : null,
                                                   GoldenLineAccount =r.Next(0,100) > 50 ? "http://www.goldenline.pl/" + p1.FirstName.ToLower() + "_" + p1.Surname.ToLower() + GenerateRandom_1_to_100(): null,
                                                   TwitterAccount = r.Next(0, 100) > 50 ? "https://twitter.com/" + p1.FirstName.ToUpper()[0] + p1.Surname + GenerateRandom_1_to_100() : null,
                                                   LinkInAccount = r.Next(0, 100) > 50 ? "http://pl.linkedin.com/in/" + p1.FirstName.ToLower() + "_" + p1.Surname.ToLower() + GenerateRandom_1_to_100() : null,
                                                   GoogleAccount = "https://plus.google.com/" + r.Next(10000, 1000000).ToString() + r.Next(10000, 1000000).ToString() + "/posts"
                                               };
                p1.ContactPerson = new ContactPerson()
                                    {
                                        ApartmentNumber = GenerateRandom_1_to_100(),
                                        BuildingNumber = GenerateRandom_1_to_100(),
                                        City = GenerateRandom_City(), 
                                        FirstName = RandomFirstName(),
                                        Phone = GeneratorTelefonu(),
                                        PostalCode = GeneratorKoduPocztowego(),
                                        Street = RandomStreet(),
                                        Surname = p1.Surname
                                    };

                p1.ContactPerson.Email = p1.ContactPerson.FirstName + "_" + p1.ContactPerson.Surname + "_" + GenerateRandom_1_to_100() + RandomDomain();

                //add collegess 
                p1.Colleges = new List<College>();
                KeyValuePair<string,string> col = RandomFieldOfStudy();
                DateTime date = RandomDay();

                College c1 = new College
                        {
                            AcademicTitle = AcademicTitleType.Inzynier,
                            EndDate = date.AddYears(4),
                            FieldOfStudy = col.Value,
                            Name = RandomCollege().Name,
                            Progres = CollageProgressType.Zakonczono,
                            Specialization = col.Key,
                            StartDate = date,
                            TitleOfResearch = "Ładny tytuł pracy inżynierskiej"
                        };
                p1.Colleges.Add(c1);

                College c2 = null;
                if(r.Next(0,4)>1)
                {
                    c2= new College
                    {
                        AcademicTitle = AcademicTitleType.Magister,
                        EndDate = date.AddYears(1),
                        FieldOfStudy = c1.FieldOfStudy,
                        Name = RandomCollege().Name,
                        Progres = GenerateCollageProgress(),
                        Specialization = c1.Specialization,
                        StartDate = date.AddYears(4),
                        TitleOfResearch = "Ładny tytuł pracy magisterskiej"
                    };
                    p1.Colleges.Add(c2);
                 }

                if (r.Next(0, 10) < 2 && c2 !=null)
                {
                    if(c2.Progres == CollageProgressType.Zakonczono)
                    {
                        College c3 = new College
                        {
                            AcademicTitle = AcademicTitleType.Doktor,
                            EndDate = date.AddYears(9),
                            FieldOfStudy = c1.FieldOfStudy,
                            Name = RandomCollege().Name,
                            Progres = GenerateCollageProgress(),
                            Specialization = c1.Specialization,
                            StartDate = date.AddYears(5),
                            TitleOfResearch = "Ładny tytuł pracy doktorskiej"
                        };
                        p1.Colleges.Add(c3);
                    }
                }

                //add job
                p1.Jobs = new List<Job>();
                date = RandomDay();

                Job j = new Job
                        {
                            CompanyName = RandomCompanyName().Name,
                            Description = "opis",
                            Position = RandomPosition().Name,
                            StartDate = date,
                            EndDate = date.AddYears(2),
                        };

                p1.Jobs.Add(j);

                Job j1 = null;
                if(r.Next(0,10) > 2)
                {
                    j1 = new Job
                    {
                        CompanyName = RandomCompanyName().Name,
                        Description = "opis",
                        Position = RandomPosition().Name,
                        StartDate = j.EndDate.Value,
                        EndDate = j.EndDate.Value.AddYears(r.Next(1, 3)),
                    };
                    p1.Jobs.Add(j1);
                }

                if (r.Next(0, 10) > 6 && j1 != null)
                {
                    Job j2 = new Job
                    {
                        CompanyName = RandomCompanyName().Name,
                        Description = "opis",
                        Position = RandomPosition().Name,
                        StartDate = j1.EndDate.Value,
                        EndDate = j1.EndDate.Value.AddYears(r.Next(1, 3)),
                    };
                    p1.Jobs.Add(j2);
                }

                //add trainings
                p1.Trainings = new List<Training>();
                date = RandomDay();
                Training traning = RandomTraining();

                Training t = new Training()
                {
                    DateOfPass = date,
                    Description = traning.Description,
                    Name = traning.Name,
                    Type = traning.Type
                };

                Training t1 = null;
                if (r.Next(0, 10) > 2)
                {
                    t1 = new Training
                    {
                        DateOfPass = date.AddYears(1),
                        Description = traning.Description,
                        Name = traning.Name,
                        Type = traning.Type
                    };
                    p1.Trainings.Add(t1);
                }

                if (r.Next(0, 10) > 6 && t1 != null)
                {
                    Training t2 = new Training
                    {
                        DateOfPass = date.AddYears(2),
                        Description = traning.Description,
                        Name = traning.Name,
                        Type = traning.Type
                    };
                    p1.Trainings.Add(t2);
                }

                p.Add(p1);
                p1 = null;
            }
            return p;
        }



        public List<OrganiziationalUnit> OrganizeOrganiziationalUnit(ref List<Person> managers)
        {
            for (int i = 0; i < OrganiziationalUnits.Count; i++)
            {
                OrganiziationalUnits[i].Manager = managers[i];
            }

            return OrganiziationalUnits;
        }

        public Employment EmployWorker(Person p, string stanowisko, string dział, Person manager)
        {
            var bank = RandomBank();
            p.Manager = manager;
            var date = RandomDay(new DateTime(2012,1,1));
            DateTime? endDate = null;

            if (r.Next(0, 10) > 6)
            {
                endDate = DateTime.Now;
            }

            Employment e = new Employment
                            {

                                EmploymentType = Core.Enums.EmploymentType.Zatrudniony,
                                Person = p,
                                BankAccount = new BankAccount()
                                {
                                    AccountNumber = GenerateAccountNumber(),
                                    BankAddress = bank.Address,
                                    BankName = bank.Name
                                },
                                PositionCode = stanowisko,
                                OrganiziationalUnitCode = dział,
                                StartDate = date,
                                EndDate = endDate,
                                Contract = new Contract()
                                {
                                    ContractDimension = ContractDimensionType.CalyEtat,
                                    ContractType = ContractType.Umowa_o_prace,
                                    EndDate = date.AddYears(2),
                                    StartDate = date
                                }
                            };

            if(r.Next(0,2)<1)
                e.Contract.MonthBenefit = GenerateRandom_Payment();
            else
                e.Contract.BenefitPerHour = GenerateRandom_HourPayment();

            return e;
        }

        public List<Employment> EmployManagers(ref List<Person> managers)
        {
            if (managers.Count >= 11)
            {
                managers[0].Account.AccountType = AccountType.Kierownik;

                var bank = RandomBank();
                List<Employment> employment = new List<Employment>()
                {
                    new Employment
                    {
                        
                        EmploymentType = Core.Enums.EmploymentType.Zatrudniony,
                        Person = managers[0],
                        BankAccount = new BankAccount()
                        {
                            AccountNumber = GenerateAccountNumber(),
                            BankAddress = bank.Address,
                            BankName = bank.Name
                        },
                        PositionCode = "D",
                        OrganiziationalUnitCode = "RN",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        Contract = new Contract()
                        {
                            ContractDimension = ContractDimensionType.CalyEtat,
                            ContractType = ContractType.Umowa_o_prace,
                            MonthBenefit = 20000,
                            BenefitPerHour= null,
                            EndDate = DateTime.Now.AddYears(2),
                            StartDate = DateTime.Now
                        }
                    }

                };
                //WIC
                bank = RandomBank();
                managers[1].Account.AccountType = AccountType.Kierownik;

                Employment e = new Employment()
                {

                        EmploymentType = Core.Enums.EmploymentType.Zatrudniony,
                        Person = managers[1],
                        BankAccount = new BankAccount()
                        {
                            AccountNumber = GenerateAccountNumber(),
                            BankAddress = bank.Address,
                            BankName = bank.Name
                        },
                        PositionCode = "WD",
                        OrganiziationalUnitCode = "RN",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now,
                        Contract = new Contract()
                        {
                            ContractDimension = ContractDimensionType.CalyEtat,
                            ContractType = ContractType.Umowa_o_prace,
                            MonthBenefit = 15000,
                            BenefitPerHour = null,
                            EndDate = DateTime.Now.AddYears(2),
                            StartDate = DateTime.Now
                        }
                };
                employment.Add(e);

                //Human Resource Manager
                bank = RandomBank();
                managers[2].Account.AccountType = AccountType.Kierownik;
                e = new Employment()
                {

                    EmploymentType = Core.Enums.EmploymentType.Zatrudniony,
                    Person = managers[2],
                    BankAccount = new BankAccount()
                    {
                        AccountNumber = GenerateAccountNumber(),
                        BankAddress = bank.Address,
                        BankName = bank.Name
                    },
                    PositionCode = "R",
                    OrganiziationalUnitCode = "DH",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Contract = new Contract()
                    {
                        ContractDimension = ContractDimensionType.CalyEtat,
                        ContractType = ContractType.Umowa_o_prace,
                        MonthBenefit = 8000,
                        BenefitPerHour = null,
                        EndDate = DateTime.Now.AddYears(2),
                        StartDate = DateTime.Now
                    }
                };
                employment.Add(e);

                bank = RandomBank();
                managers[3].Account.AccountType = AccountType.Kierownik;
                e = new Employment()
                {

                    EmploymentType = Core.Enums.EmploymentType.Zatrudniony,
                    Person = managers[3],
                    BankAccount = new BankAccount()
                    {
                        AccountNumber = GenerateAccountNumber(),
                        BankAddress = bank.Address,
                        BankName = bank.Name
                    },
                    PositionCode = "K",
                    OrganiziationalUnitCode = "DK",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Contract = new Contract()
                    {
                        ContractDimension = ContractDimensionType.CalyEtat,
                        ContractType = ContractType.Umowa_o_prace,
                        MonthBenefit = 10000,
                        BenefitPerHour = null,
                        EndDate = DateTime.Now.AddYears(2),
                        StartDate = DateTime.Now
                    }
                };
                employment.Add(e);

                bank = RandomBank();
                managers[4].Account.AccountType = AccountType.Kierownik;
                e = new Employment()
                {

                    EmploymentType = Core.Enums.EmploymentType.Zatrudniony,
                    Person = managers[4],
                    BankAccount = new BankAccount()
                    {
                        AccountNumber = GenerateAccountNumber(),
                        BankAddress = bank.Address,
                        BankName = bank.Name
                    },
                    PositionCode = "A",
                    OrganiziationalUnitCode = "DA",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Contract = new Contract()
                    {
                        ContractDimension = ContractDimensionType.CalyEtat,
                        ContractType = ContractType.Umowa_o_prace,
                        MonthBenefit = 8000,
                        BenefitPerHour = null,
                        EndDate = DateTime.Now.AddYears(2),
                        StartDate = DateTime.Now
                    }
                };
                employment.Add(e);

                bank = RandomBank();
                managers[5].Account.AccountType = AccountType.Kierownik;
                e = new Employment()
                {

                    EmploymentType = Core.Enums.EmploymentType.Zatrudniony,
                    Person = managers[5],
                    BankAccount = new BankAccount()
                    {
                        AccountNumber = GenerateAccountNumber(),
                        BankAddress = bank.Address,
                        BankName = bank.Name
                    },
                    PositionCode = "T",
                    OrganiziationalUnitCode = "DT",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Contract = new Contract()
                    {
                        ContractDimension = ContractDimensionType.CalyEtat,
                        ContractType = ContractType.Umowa_o_prace,
                        MonthBenefit = 10000,
                        BenefitPerHour = null,
                        EndDate = DateTime.Now.AddYears(2),
                        StartDate = DateTime.Now
                    }
                };
                employment.Add(e);

                bank = RandomBank();
                managers[6].Account.AccountType = AccountType.Kierownik;
                e = new Employment()
                {

                    EmploymentType = Core.Enums.EmploymentType.Zatrudniony,
                    Person = managers[6],
                    BankAccount = new BankAccount()
                    {
                        AccountNumber = GenerateAccountNumber(),
                        BankAddress = bank.Address,
                        BankName = bank.Name
                    },
                    PositionCode = "SPJ",
                    OrganiziationalUnitCode = "DPJ",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Contract = new Contract()
                    {
                        ContractDimension = ContractDimensionType.CalyEtat,
                        ContractType = ContractType.Umowa_o_prace,
                        MonthBenefit = 15000,
                        BenefitPerHour = null,
                        EndDate = DateTime.Now.AddYears(2),
                        StartDate = DateTime.Now
                    }
                };
                employment.Add(e);

                bank = RandomBank();
                managers[7].Account.AccountType = AccountType.Kierownik;
                e = new Employment()
                {

                    EmploymentType = Core.Enums.EmploymentType.Zatrudniony,
                    Person = managers[7],
                    BankAccount = new BankAccount()
                    {
                        AccountNumber = GenerateAccountNumber(),
                        BankAddress = bank.Address,
                        BankName = bank.Name
                    },
                    PositionCode = "SPN",
                    OrganiziationalUnitCode = "DPN",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Contract = new Contract()
                    {
                        ContractDimension = ContractDimensionType.CalyEtat,
                        ContractType = ContractType.Umowa_o_prace,
                        MonthBenefit = 15000,
                        BenefitPerHour = null,
                        EndDate = DateTime.Now.AddYears(2),
                        StartDate = DateTime.Now
                    }
                };
                employment.Add(e);

                bank = RandomBank();
                managers[8].Account.AccountType = AccountType.Kierownik;
                e = new Employment()
                {

                    EmploymentType = Core.Enums.EmploymentType.Zatrudniony,
                    Person = managers[8],
                    BankAccount = new BankAccount()
                    {
                        AccountNumber = GenerateAccountNumber(),
                        BankAddress = bank.Address,
                        BankName = bank.Name
                    },
                    PositionCode = "SPP",
                    OrganiziationalUnitCode = "DPP",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Contract = new Contract()
                    {
                        ContractDimension = ContractDimensionType.CalyEtat,
                        ContractType = ContractType.Umowa_o_prace,
                        MonthBenefit = 15000,
                        BenefitPerHour = null,
                        EndDate = DateTime.Now.AddYears(2),
                        StartDate = DateTime.Now
                    }
                };
                employment.Add(e);

                bank = RandomBank();
                managers[9].Account.AccountType = AccountType.Kierownik;
                e = new Employment()
                {

                    EmploymentType = Core.Enums.EmploymentType.Zatrudniony,
                    Person = managers[9],
                    BankAccount = new BankAccount()
                    {
                        AccountNumber = GenerateAccountNumber(),
                        BankAddress = bank.Address,
                        BankName = bank.Name
                    },
                    PositionCode = "SPR",
                    OrganiziationalUnitCode = "DPR",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Contract = new Contract()
                    {
                        ContractDimension = ContractDimensionType.CalyEtat,
                        ContractType = ContractType.Umowa_o_prace,
                        MonthBenefit = 15000,
                        BenefitPerHour = null,
                        EndDate = DateTime.Now.AddYears(2),
                        StartDate = DateTime.Now
                    }
                };
                employment.Add(e);

                bank = RandomBank();
                managers[10].Account.AccountType = AccountType.Kierownik;
                e = new Employment()
                {

                    EmploymentType = Core.Enums.EmploymentType.Zatrudniony,
                    Person = managers[10],
                    BankAccount = new BankAccount()
                    {
                        AccountNumber = GenerateAccountNumber(),
                        BankAddress = bank.Address,
                        BankName = bank.Name
                    },
                    PositionCode = "SPC",
                    OrganiziationalUnitCode = "DPC",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Contract = new Contract()
                    {
                        ContractDimension = ContractDimensionType.CalyEtat,
                        ContractType = ContractType.Umowa_o_prace,
                        MonthBenefit = 15000,
                        BenefitPerHour = null,
                        EndDate = DateTime.Now.AddYears(2),
                        StartDate = DateTime.Now
                    }
                };
                employment.Add(e);


                return employment;
            }
            else
            {
                throw new Exception();
            }
        }

        // do work registry
        public List<WorkRegistry> GenerateWorkRegistry(Person p)
        {
            List<WorkRegistry> list = new List<WorkRegistry>();

            DateTime start = p.Employment.StartDate;
            DateTime? finish = p.Employment.EndDate;

            finish = finish ?? DateTime.Now;

            for (DateTime x = start; x <= finish; x = x.AddDays(1))
            {
                if (x.DayOfWeek != DayOfWeek.Sunday && x.DayOfWeek != DayOfWeek.Saturday)
                {
                    WorkRegistry wr = new WorkRegistry
                    {
                        Date = x.Date,
                        DateIn = new TimeSpan(8, 0, 0),
                        DateOut = new TimeSpan(16, 0, 0),
                        Person = p
                    };
                    list.Add(wr);
                }
            }
            p.WorkRegistrys = p.WorkRegistrys ?? new List<WorkRegistry>();
            p.WorkRegistrys = list;

            return list;
        }

#warning Podstawowa funkcjonalnosc bez brania pod uwage rodzaju umow
        public List<BenefitsProfit> GenerateBenefitsProfit(Person p)
        {
            
            List<BenefitsProfit> list = new List<BenefitsProfit>();

            DateTime start = p.Employment.StartDate;
            DateTime? finish = p.Employment.EndDate;

            finish = finish ?? DateTime.Now;

            if(p.Employment.Contract.MonthBenefit != null)
            {
                    for (DateTime x = start; x <= finish; x = x.AddMonths(1))
                    {
                            int numberOfDaysInMonth = DateTime.DaysInMonth(x.Year, x.Month);
                            DateTime startOfMonth = new DateTime(x.Year, x.Month, 1);    
                            DateTime endOfMonth = new DateTime(x.Year, x.Month, numberOfDaysInMonth);

                            BenefitsProfit bp = new BenefitsProfit
                            {
                                BenefitBrutto = (double)p.Employment.Contract.MonthBenefit,
                                Retirement = (double)(p.Employment.Contract.MonthBenefit* (9.76/100.00)), //9.76
                                Disability = (double)(p.Employment.Contract.MonthBenefit* (1.50/100.00)),//1.5
                                Sikness =  (double)(p.Employment.Contract.MonthBenefit* (2.45/100.00)),
                                Health = (double)(p.Employment.Contract.MonthBenefit* (7.766/100.00)),
                                Taxable = (double)(p.Employment.Contract.MonthBenefit* (80.75/100)),
                                AdvanceAt_PIT =  (double)(p.Employment.Contract.MonthBenefit* (5.55/100)),
                                BenefitNetto =  (double)(p.Employment.Contract.MonthBenefit* (72.974/100)),
                                BenefitType = BenefitType.Pensja,
                                EndDate = endOfMonth,
                                StartDate = startOfMonth,
                                Person = p
                            };

                            list.Add(bp);
                
                    }
            }
            else
            {
#warning Trzeba naliczanie godzinowe zrobic
                for (DateTime x = start; x <= finish; x = x.AddMonths(1))
                    {

                        if (x.DayOfWeek != DayOfWeek.Sunday && x.DayOfWeek != DayOfWeek.Saturday)
                        {
                            int numberOfDaysInMonth = DateTime.DaysInMonth(x.Year, x.Month);
                            DateTime startOfMonth = new DateTime(x.Year, x.Month, 1);
                            DateTime endOfMonth = new DateTime(x.Year, x.Month, numberOfDaysInMonth);

                            double totalBenefit = (double)p.Employment.Contract.BenefitPerHour * 8.00 * 30.00;

                            BenefitsProfit bp = new BenefitsProfit
                            {
                                BenefitBrutto = totalBenefit,
                                Retirement = (double)(totalBenefit * (9.76 / 100.00)), //9.76
                                Disability = (double)(totalBenefit * (1.50 / 100.00)),//1.5
                                Sikness = (double)(totalBenefit * (2.45 / 100.00)),
                                Health = (double)(totalBenefit * (7.766 / 100.00)),
                                Taxable = (double)(totalBenefit * (80.75 / 100)),
                                AdvanceAt_PIT = (double)(totalBenefit * (5.55 / 100)),
                                BenefitNetto = (double)(totalBenefit * (72.974 / 100)),
                                BenefitType = BenefitType.Pensja,
                                EndDate = endOfMonth,
                                StartDate = startOfMonth,
                                Person = p
                            };

                            list.Add(bp);
                        }
                    }
            }
            p.BenefitsProfits = p.BenefitsProfits ?? new List<BenefitsProfit>();
            p.BenefitsProfits = list;

            return list;
        }


        public List<string> Domain = new List<string>
        {
            "@o2.pl",
            "@wp.pl",
            "@gmail.pl",
            "@onet.pl",
            "@buziaczek.pl",
            "@outlook.pl",
            "@wimii.pl",
            "@interia.pl",
            "@gazeta.pl",
            "@epam.pl",
            "@yahoo.pl",
            "@microsoft.pl",

        };

        public Dictionary<string, string> Miasta = new Dictionary<string, string>
        {
            {"Aleksandrów Kujawski","KP"}
            ,{"Aleksandrów Łódzki","ŁD"}
            ,{"Alwernia","MP"}
            ,{"Andrychów","MP"}
            ,{"Annopol","LB"}
            ,{"Augustów","PL"}
            ,{"Babimost","LS"}
            ,{"Baborów","OP"}
            ,{"Baranów Sandomierski","PK"}
            ,{"Barcin","KP"}
            ,{"Barczewo","WM"}
            ,{"Bardo","DŚ"}
            ,{"Barlinek","ZP"}
            ,{"Bartoszyce","WM"}
            ,{"Barwice","ZP"}
            ,{"Bełchatów","ŁD"}
            ,{"Bełżyce","LB"}
            ,{"Będzin","ŚL"}
            ,{"Biała","OP"}
            ,{"Biała Piska","WM"}
            ,{"Biała Podlaska","LB"}
            ,{"Biała Rawska","ŁD"}
            ,{"Białobrzegi","MZ"}
            ,{"Białogard","ZP"}
            ,{"Biały Bór","ZP"}
            ,{"Białystok","PL"}
            ,{"Biecz","MP"}
            ,{"Bielawa","DŚ"}
            ,{"Bielsk Podlaski","PL"}
            ,{"Bielsko-Biała","ŚL"}
            ,{"Bieruń","ŚL"}
            ,{"Bierutów","DŚ"}
            ,{"Bieżuń","MZ"}
            ,{"Biłgoraj","LB"}
            ,{"Biskupiec","WM"}
            ,{"Bisztynek","WM"}
            ,{"Blachownia","ŚL"}
            ,{"Błaszki","ŁD"}
            ,{"Błażowa","PK"}
            ,{"Błonie","MZ"}
            ,{"Bobolice","ZP"}
            ,{"Bobowa","MP"}
            ,{"Bochnia","MP"}
            ,{"Bodzentyn","ŚK"}
            ,{"Bogatynia","DŚ"}
            ,{"Boguchwała","PK"}
            ,{"Boguszów-Gorce","DŚ"}
            ,{"Bojanowo","WP"}
            ,{"Bolesławiec","DŚ"}
            ,{"Bolków","DŚ"}
            ,{"Borek Wielkopolski","WP"}
            ,{"Borne Sulinowo","ZP"}
            ,{"Braniewo","WM"}
            ,{"Brańsk","PL"}
            ,{"Brodnica","KP"}
            ,{"Brok","MZ"}
            ,{"Brusy","PM"}
            ,{"Brwinów","MZ"}
            ,{"Brzeg","OP"}
            ,{"Brzeg Dolny","DŚ"}
            ,{"Brzesko","MP"}
            ,{"Brzeszcze","MP"}
            ,{"Brześć Kujawski","KP"}
            ,{"Brzeziny","ŁD"}
            ,{"Brzostek","PK"}
            ,{"Brzozów","PK"}
            ,{"Buk","WP"}
            ,{"Bukowno","MP"}
            ,{"Busko-Zdrój","ŚK"}
            ,{"Bychawa","LB"}
            ,{"Byczyna","OP"}
            ,{"Bydgoszcz","KP"}
            ,{"Bystrzyca Kłodzka","DŚ"}
            ,{"Bytom","ŚL"}
            ,{"Bytom Odrzański","LS"}
            ,{"Bytów","PM"}
            ,{"Cedynia","ZP"}
            ,{"Chełm","LB"}
            ,{"Chełmek","MP"}
            ,{"Chełmno","KP"}
            ,{"Chełmża","KP"}
            ,{"Chęciny","ŚK"}
            ,{"Chmielnik","ŚK"}
            ,{"Chocianów","DŚ"}
            ,{"Chociwel","ZP"}
            ,{"Chodecz","KP"}
            ,{"Chodzież","WP"}
            ,{"Chojna","ZP"}
            ,{"Chojnice","PM"}
            ,{"Chojnów","DŚ"}
            ,{"Choroszcz","PL"}
            ,{"Chorzele","MZ"}
            ,{"Chorzów","ŚL"}
            ,{"Choszczno","ZP"}
            ,{"Chrzanów","MP"}
            ,{"Ciechanowiec","PL"}
            ,{"Ciechanów","MZ"}
            ,{"Ciechocinek","KP"}
            ,{"Cieszanów","PK"}
            ,{"Cieszyn","ŚL"}
            ,{"Ciężkowice","MP"}
            ,{"Cybinka","LS"}
            ,{"Czaplinek","ZP"}
            ,{"Czarna Białostocka","PL"}
            ,{"Czarna Woda","PM"}
            ,{"Czarne","PM"}
            ,{"Czarnków","WP"}
            ,{"Czchów","MP"}
            ,{"Czechowice-Dziedzice","ŚL"}
            ,{"Czeladź","ŚL"}
            ,{"Czempiń","WP"}
            ,{"Czerniejewo","WP"}
            ,{"Czersk","PM"}
            ,{"Czerwieńsk","LS"}
            ,{"Czerwionka-Leszczyny","ŚL"}
            ,{"Częstochowa","ŚL"}
            ,{"Człopa","ZP"}
            ,{"Człuchów","PM"}
            ,{"Czyżew","PL"}
            ,{"Ćmielów","ŚK"}
            ,{"Daleszyce","ŚK"}
            ,{"Darłowo","ZP"}
            ,{"Dąbie","WP"}
            ,{"Dąbrowa Białostocka","PL"}
            ,{"Dąbrowa Górnicza","ŚL"}
            ,{"Dąbrowa Tarnowska","MP"}
            ,{"Debrzno","PM"}
            ,{"Dębica","PK"}
            ,{"Dęblin","LB"}
            ,{"Dębno","ZP"}
            ,{"Dobczyce","MP"}
            ,{"Dobiegniew","LS"}
            ,{"Dobra", "ZP"}
            //,{"Dobra" ,"WP"}
            ,{"Dobre Miasto","WM"}
            ,{"Dobrodzień","OP"}
            ,{"Dobrzany","ZP"}
            ,{"Dobrzyca","WP"}
            ,{"Dobrzyń nad Wisłą","KP"}
            ,{"Dolsk","WP"}
            ,{"Drawno","ZP"}
            ,{"Drawsko Pomorskie","ZP"}
            ,{"Drezdenko","LS"}
            ,{"Drobin","MZ"}
            ,{"Drohiczyn","PL"}
            ,{"Drzewica","ŁD"}
            ,{"Dukla","PK"}
            ,{"Duszniki-Zdrój","DŚ"}
            ,{"Dynów","PK"}
            ,{"Działdowo","WM"}
            ,{"Działoszyce","ŚK"}
            ,{"Działoszyn","ŁD"}
            ,{"Dzierzgoń","PM"}
            ,{"Dzierżoniów","DŚ"}
            ,{"Dziwnów","ZP"}
            ,{"Elbląg","WM"}
            ,{"Ełk","WM"}
            ,{"Frampol","LB"}
            ,{"Frombork","WM"}
            ,{"Garwolin","MZ"}
            ,{"Gąbin","MZ"}
            ,{"Gdańsk","PM"}
            ,{"Gdynia","PM"}
            ,{"Giżycko","WM"}
            ,{"Glinojeck","MZ"}
            ,{"Gliwice","ŚL"}
            ,{"Głogów","DŚ"}
            ,{"Głogów Małopolski","PK"}
            ,{"Głogówek","OP"}
            ,{"Głowno","ŁD"}
            ,{"Głubczyce","OP"}
            ,{"Głuchołazy","OP"}
            ,{"Głuszyca","DŚ"}
            ,{"Gniew","PM"}
            ,{"Gniewkowo","KP"}
            ,{"Gniezno","WP"}
            ,{"Gogolin","OP"}////
            ,{"Golczewo","ZP"}
            ,{"Goleniów","ZP"}
            ,{"Golina","WP"}
            ,{"Golub-Dobrzyń","KP"}
            ,{"Gołańcz","WP"}
            ,{"Gołdap","WM"}
            ,{"Goniądz","PL"}
            ,{"Gorlice","MP"}
            ,{"Gorzów Śląski","OP"}
            ,{"Gorzów Wielkopolski","LS"}
            ,{"Gostynin","MZ"}
            ,{"Gostyń","WP"}
            ,{"Gościno","ZP"}
            ,{"Gozdnica","LS"}
            ,{"Góra","DŚ"}
            ,{"Góra Kalwaria","MZ"}
            ,{"Górowo Iławeckie","WM"}
            ,{"Górzno","KP"}
            ,{"Grabów nad Prosną","WP"}
            ,{"Grajewo","PL"}
            ,{"Grodków","OP"}
            ,{"Grodzisk Mazowiecki","MZ"}
            ,{"Grodzisk Wielkopolski","WP"}
            ,{"Grójec","MZ"}
            ,{"Grudziądz","KP"}
            ,{"Grybów","MP"}
            ,{"Gryfice","ZP"}
            ,{"Gryfino","ZP"}
            ,{"Gryfów Śląski","DŚ"}
            ,{"Gubin","LS"}
            ,{"Hajnówka","PL"}
            ,{"Halinów","MZ"}
            ,{"Hel","PM"}
            ,{"Hrubieszów","LB"}
            ,{"Iława","WM"}
            ,{"Iłowa","LS"}
            ,{"Iłża","MZ"}
            ,{"Imielin","ŚL"}
            ,{"Inowrocław","KP"}
            ,{"Ińsko","ZP"}
            ,{"Iwonicz-Zdrój","PK"}
            ,{"Izbica Kujawska","KP"}
            ,{"Jabłonowo Pomorskie","KP"}
            ,{"Janikowo","KP"}
            ,{"Janowiec Wielkopolski","KP"}
            ,{"Janów Lubelski","LB"}
            ,{"Jarocin","WP"}
            ,{"Jarosław","PK"}
            ,{"Jasień","LS"}
            ,{"Jasło","PK"}
            ,{"Jastarnia","PM"}
            ,{"Jastrowie","WP"}
            ,{"Jastrzębie-Zdrój","ŚL"}
            ,{"Jawor","DŚ"}
            ,{"Jaworzno","ŚL"}
            ,{"Jaworzyna Śląska","DŚ"}
            ,{"Jedlicze","PK"}
            ,{"Jedlina-Zdrój","DŚ"}
            ,{"Jedwabne","PL"}
            ,{"Jelcz-Laskowice","DŚ"}
            ,{"Jelenia Góra","DŚ"}
            ,{"Jeziorany","WM"}
            ,{"Jędrzejów","ŚK"}
            ,{"Jordanów","MP"}
            ,{"Józefów","LB"}
            //,{"Józefów","MZ"}
            ,{"Jutrosin","WP"}
            ,{"Kalety","ŚL"}
            ,{"Kalisz","WP"}
            ,{"Kalisz Pomorski","ZP"}
            ,{"Kalwaria Zebrzydowska","MP"}
            ,{"Kałuszyn","MZ"}
            ,{"Kamienna Góra","DŚ"}
            ,{"Kamień Krajeński","KP"}
            ,{"Kamień Pomorski","ZP"}
            ,{"Kamieńsk","ŁD"}
            ,{"Kańczuga","PK"}
            ,{"Karczew","MZ"}
            ,{"Kargowa","LS"}
            ,{"Karlino","ZP"}
            ,{"Karpacz","DŚ"}
            ,{"Kartuzy","PM"}
            ,{"Katowice","ŚL"}
            ,{"Kazimierz Dolny","LB"}
            ,{"Kazimierza Wielka","ŚK"}
            ,{"Kąty Wrocławskie","DŚ"}
            ,{"Kcynia","KP"}
            ,{"Kędzierzyn-Koźle","OP"}
            ,{"Kępice","PM"}
            ,{"Kępno","WP"}
            ,{"Kętrzyn","WM"}
            ,{"Kęty","MP"}
            ,{"Kielce","ŚK"}
            ,{"Kietrz","OP"}
            ,{"Kisielice","WM"}
            ,{"Kleczew","WP"}
            ,{"Kleszczele","PL"}
            ,{"Kluczbork","OP"}
            ,{"Kłecko","WP"}
            ,{"Kłobuck","ŚL"}
            ,{"Kłodawa","WP"}
            ,{"Kłodzko","DŚ"}
            ,{"Knurów","ŚL"}
            ,{"Knyszyn","PL"}
            ,{"Kobylin","WP"}
            ,{"Kobyłka","MZ"}
            ,{"Kock","LB"}
            ,{"Kolbuszowa","PK"}
            ,{"Kolno","PL"}
            ,{"Kolonowskie","OP"}
            ,{"Koluszki","ŁD"}
            ,{"Kołaczyce","PK"}
            ,{"Koło","WP"}
            ,{"Kołobrzeg","ZP"}
            ,{"Koniecpol","ŚL"}
            ,{"Konin","WP"}
            ,{"Konstancin-Jeziorna","MZ"}
            ,{"Konstantynów Łódzki","ŁD"}
            ,{"Końskie","ŚK"}
            ,{"Koprzywnica","ŚK"}
            ,{"Korfantów","OP"}
            ,{"Koronowo","KP"}
            ,{"Korsze","WM"}
            ,{"Kosów Lacki","MZ"}
            ,{"Kostrzyn","WP"}
            ,{"Kostrzyn nad Odrą","LS"}
            ,{"Koszalin","ZP"}
            ,{"Kościan","WP"}
            ,{"Kościerzyna","PM"}
            ,{"Kowal","KP"}
            ,{"Kowalewo Pomorskie","KP"}
            ,{"Kowary","DŚ"}
            ,{"Koziegłowy","ŚL"}
            ,{"Kozienice","MZ"}
            ,{"Koźmin Wielkopolski","WP"}
            ,{"Kożuchów","LS"}
            ,{"Kórnik","WP"}
            ,{"Krajenka","WP"}
            ,{"Kraków","MP"}
            ,{"Krapkowice","OP"}
            ,{"Krasnobród","LB"}
            ,{"Krasnystaw","LB"}
            ,{"Kraśnik","LB"}
            ,{"Krobia","WP"}
            ,{"Krosno","PK"}
            ,{"Krosno Odrzańskie","LS"}
            ,{"Krośniewice","ŁD"}
            ,{"Krotoszyn","WP"}
            ,{"Kruszwica","KP"}
            ,{"Krynica Morska","PM"}
            ,{"Krynica-Zdrój","MP"}
            ,{"Krynki","PL"}
            ,{"Krzanowice","ŚL"}
            ,{"Krzepice","ŚL"}
            ,{"Krzeszowice","MP"}
            ,{"Krzywiń","WP"}
            ,{"Krzyż Wielkopolski","WP"}
            ,{"Książ Wielkopolski","WP"}
            ,{"Kudowa-Zdrój","DŚ"}
            ,{"Kunów","ŚK"}
            ,{"Kutno","ŁD"}
            ,{"Kuźnia Raciborska","ŚL"}
            ,{"Kwidzyn","PM"}
            ,{"Lądek-Zdrój","DŚ"}
            ,{"Legionowo","MZ"}
            ,{"Legnica","DŚ"}
            ,{"Lesko","PK"}
            ,{"Leszno","WP"}
            ,{"Leśna","DŚ"}
            ,{"Leśnica","OP"}
            ,{"Lewin Brzeski","OP"}
            ,{"Leżajsk","PK"}
            ,{"Lębork","PM"}
            ,{"Lędziny","ŚL"}
            ,{"Libiąż","MP"}
            ,{"Lidzbark","WM"}
            ,{"Lidzbark Warmiński","WM"}
            ,{"Limanowa","MP"}
            ,{"Lipiany","ZP"}
            ,{"Lipno","KP"}
            ,{"Lipsk","PL"}
            ,{"Lipsko","MZ"}
            ,{"Lubaczów","PK"}
            ,{"Lubań","DŚ"}
            ,{"Lubartów","LB"}
            ,{"Lubawa","WM"}
            ,{"Lubawka","DŚ"}
            ,{"Lubień Kujawski","KP"}
            ,{"Lubin","DŚ"}
            ,{"Lublin","LB"}
            ,{"Lubliniec","ŚL"}
            ,{"Lubniewice","LS"}
            ,{"Lubomierz","DŚ"}
            ,{"Luboń","WP"}
            ,{"Lubraniec","KP"}
            ,{"Lubsko","LS"}
            ,{"Lwówek","WP"}
            ,{"Lwówek Śląski","DŚ"}
            ,{"Łabiszyn","KP"}
            ,{"Łańcut","PK"}
            ,{"Łapy","PL"}
            ,{"Łasin","KP"}
            ,{"Łask","ŁD"}
            ,{"Łaskarzew","MZ"}
            ,{"Łaszczów","LB"}
            ,{"Łaziska Górne","ŚL"}
            ,{"Łazy","ŚL"}
            ,{"Łeba","PM"}
            ,{"Łęczna","LB"}
            ,{"Łęczyca","ŁD"}
            ,{"Łęknica","LS"}
            ,{"Łobez","ZP"}
            ,{"Łobżenica","WP"}
            ,{"Łochów","MZ"}
            ,{"Łomianki","MZ"}
            ,{"Łomża","PL"}
            ,{"Łosice","MZ"}
            ,{"Łowicz","ŁD"}
            ,{"Łódź","ŁD"}
            ,{"Łuków","LB"}
            ,{"Maków Mazowiecki","MZ"}
            ,{"Maków Podhalański","MP"}
            ,{"Malbork","PM"}
            ,{"Małogoszcz","ŚK"}
            ,{"Małomice","LS"}
            ,{"Margonin","WP"}
            ,{"Marki","MZ"}
            ,{"Maszewo","ZP"}
            ,{"Miasteczko Śląskie","ŚL"}
            ,{"Miastko","PM"}
            ,{"Michałowo","PL"}
            ,{"Miechów","MP"}
            ,{"Miejska Górka","WP"}
            ,{"Mielec","PK"}
            ,{"Mieroszów","DŚ"}
            ,{"Mieszkowice","ZP"}
            ,{"Międzybórz","DŚ"}
            ,{"Międzychód","WP"}
            ,{"Międzylesie","DŚ"}
            ,{"Międzyrzec Podlaski","LB"}
            ,{"Międzyrzecz","LS"}
            ,{"Międzyzdroje","ZP"}
            ,{"Mikołajki","WM"}
            ,{"Mikołów","ŚL"}
            ,{"Mikstat","WP"}
            ,{"Milanówek","MZ"}
            ,{"Milicz","DŚ"}
            ,{"Miłakowo","WM"}
            ,{"Miłomłyn","WM"}
            ,{"Miłosław","WP"}
            ,{"Mińsk Mazowiecki","MZ"}
            ,{"Mirosławiec","ZP"}
            ,{"Mirsk","DŚ"}
            ,{"Mława","MZ"}
            ,{"Młynary","WM"}
            ,{"Modliborzyce","LB"}
            ,{"Mogielnica","MZ"}
            ,{"Mogilno","KP"}
            ,{"Mońki","PL"}
            ,{"Morąg","WM"}
            ,{"Mordy","MZ"}
            ,{"Moryń","ZP"}
            ,{"Mosina","WP"}
            ,{"Mrągowo","WM"}
            ,{"Mrocza","KP"}
            ,{"Mrozy","MZ"}
            ,{"Mszana Dolna","MP"}
            ,{"Mszczonów","MZ"}
            ,{"Murowana Goślina","WP"}
            ,{"Muszyna","MP"}
            ,{"Mysłowice","ŚL"}
            ,{"Myszków","ŚL"}
            ,{"Myszyniec","MZ"}
            ,{"Myślenice","MP"}
            ,{"Myślibórz","ZP"}
            ,{"Nakło nad Notecią","KP"}
            ,{"Nałęczów","LB"}
            ,{"Namysłów","OP"}
            ,{"Narol","PK"}
            ,{"Nasielsk","MZ"}
            ,{"Nekla","WP"}
            ,{"Nidzica","WM"}
            ,{"Niemcza","DŚ"}
            ,{"Niemodlin","OP"}
            ,{"Niepołomice","MP"}
            ,{"Nieszawa","KP"}
            ,{"Nisko","PK"}
            ,{"Nowa Dęba","PK"}
            ,{"Nowa Ruda","DŚ"}
            ,{"Nowa Sarzyna","PK"}
            ,{"Nowa Sól","LS"}
            ,{"Nowe","KP"}
            ,{"Nowe Brzesko","MP"}
            ,{"Nowe Miasteczko","LS"}
            ,{"Nowe Miasto Lubawskie","WM"}
            ,{"Nowe Miasto nad Pilicą","MZ"}
            ,{"Nowe Skalmierzyce","WP"}
            ,{"Nowe Warpno","ZP"}
            ,{"Nowogard","ZP"}
            ,{"Nowogrodziec","DŚ"}
            ,{"Nowogród","PL"}
            ,{"Nowogród Bobrzański","LS"}
            ,{"Nowy Dwór Gdański","PM"}
            ,{"Nowy Dwór Mazowiecki","MZ"}
            ,{"Nowy Sącz","MP"}
            ,{"Nowy Staw","PM"}
            ,{"Nowy Targ","MP"}
            ,{"Nowy Tomyśl","WP"}
            ,{"Nowy Wiśnicz","MP"}
            ,{"Nysa","OP"}
            ,{"Oborniki","WP"}
            ,{"Oborniki Śląskie","DŚ"}
            ,{"Obrzycko","WP"}
            ,{"Odolanów","WP"}
            ,{"Ogrodzieniec","ŚL"}
            ,{"Okonek","WP"}
            ,{"Olecko","WM"}
            ,{"Olesno","OP"}
            ,{"Oleszyce","PK"}
            ,{"Oleśnica","DŚ"}
            ,{"Olkusz","MP"}
            ,{"Olsztyn","WM"}
            ,{"Olsztynek","WM"}
            ,{"Olszyna","DŚ"}
            ,{"Oława","DŚ"}
            ,{"Opalenica","WP"}
            ,{"Opatów","ŚK"}
            ,{"Opoczno","ŁD"}
            ,{"Opole","OP"}
            ,{"Opole Lubelskie","LB"}
            ,{"Orneta","WM"}
            ,{"Orzesze","ŚL"}
            ,{"Orzysz","WM"}
            ,{"Osieczna","WP"}
            ,{"Osiek","ŚK"}
            ,{"Ostrołęka","MZ"}
            ,{"Ostroróg","WP"}
            ,{"Ostrowiec Świętokrzyski","ŚK"}
            ,{"Ostróda","WM"}
            ,{"Ostrów Lubelski","LB"}
            ,{"Ostrów Mazowiecka","MZ"}
            ,{"Ostrów Wielkopolski","WP"}
            ,{"Ostrzeszów","WP"}
            ,{"Ośno Lubuskie","LS"}
            ,{"Oświęcim","MP"}
            ,{"Otmuchów","OP"}
            ,{"Otwock","MZ"}
            ,{"Ozimek","OP"}
            ,{"Ozorków","ŁD"}
            ,{"Ożarów","ŚK"}
            ,{"Ożarów Mazowiecki","MZ"}
            ,{"Pabianice","ŁD"}
            ,{"Paczków","OP"}
            ,{"Pajęczno","ŁD"}
            ,{"Pakość","KP"}
            ,{"Parczew","LB"}
            ,{"Pasłęk","WM"}
            ,{"Pasym","WM"}
            ,{"Pelplin","PM"}
            ,{"Pełczyce","ZP"}
            ,{"Piaseczno","MZ"}
            ,{"Piaski","LB"}
            ,{"Piastów","MZ"}
            ,{"Piechowice","DŚ"}
            ,{"Piekary Śląskie","ŚL"}
            ,{"Pieniężno","WM"}
            ,{"Pieńsk","DŚ"}
            ,{"Pieszyce","DŚ"}
            ,{"Pilawa","MZ"}
            ,{"Pilica","ŚL"}
            ,{"Pilzno","PK"}
            ,{"Piła","WP"}
            ,{"Piława Górna","DŚ"}
            ,{"Pińczów","ŚK"}
            ,{"Pionki","MZ"}
            ,{"Piotrków Kujawski","KP"}
            ,{"Piotrków Trybunalski","ŁD"}
            ,{"Pisz","WM"}
            ,{"Piwniczna-Zdrój","MP"}
            ,{"Pleszew","WP"}
            ,{"Płock","MZ"}
            ,{"Płońsk","MZ"}
            ,{"Płoty","ZP"}
            ,{"Pniewy","WP"}
            ,{"Pobiedziska","WP"}
            ,{"Poddębice","ŁD"}
            ,{"Podkowa Leśna","MZ"}
            ,{"Pogorzela","WP"}
            ,{"Polanica-Zdrój","DŚ"}
            ,{"Polanów","ZP"}
            ,{"Police","ZP"}
            ,{"Polkowice","DŚ"}
            ,{"Połaniec","ŚK"}
            ,{"Połczyn-Zdrój","ZP"}
            ,{"Poniatowa","LB"}
            ,{"Poniec","WP"}
            ,{"Poręba","ŚL"}
            ,{"Poznań","WP"}
            ,{"Prabuty","PM"}
            ,{"Praszka","OP"}
            ,{"Prochowice","DŚ"}
            ,{"Proszowice","MP"}
            ,{"Prószków","OP"}
            ,{"Pruchnik","PK"}
            ,{"Prudnik","OP"}
            ,{"Prusice","DŚ"}
            ,{"Pruszcz Gdański","PM"}
            ,{"Pruszków","MZ"}
            ,{"Przasnysz","MZ"}
            ,{"Przecław","PK"}
            ,{"Przedbórz","ŁD"}
            ,{"Przedecz","WP"}
            ,{"Przemków","DŚ"}
            ,{"Przemyśl","PK"}
            ,{"Przeworsk","PK"}
            ,{"Przysucha","MZ"}
            ,{"Pszczyna","ŚL"}
            ,{"Pszów","ŚL"}
            ,{"Puck","PM"}
            ,{"Puławy","LB"}
            ,{"Pułtusk","MZ"}
            ,{"Puszczykowo","WP"}
            ,{"Pyrzyce","ZP"}
            ,{"Pyskowice","ŚL"}
            ,{"Pyzdry","WP"}
            ,{"Rabka-Zdrój","MP"}
            ,{"Raciąż","MZ"}
            ,{"Racibórz","ŚL"}
            ,{"Radków","DŚ"}
            ,{"Radlin","ŚL"}
            ,{"Radłów","MP"}
            ,{"Radom","MZ"}
            ,{"Radomsko","ŁD"}
            ,{"Radomyśl Wielki","PK"}
            ,{"Radymno","PK"}
            ,{"Radziejów","KP"}
            ,{"Radzionków","ŚL"}
            ,{"Radzymin","MZ"}
            ,{"Radzyń Chełmiński","KP"}
            ,{"Radzyń Podlaski","LB"}
            ,{"Rajgród","PL"}
            ,{"Rakoniewice","WP"}
            ,{"Raszków","WP"}
            ,{"Rawa Mazowiecka","ŁD"}
            ,{"Rawicz","WP"}
            ,{"Recz","ZP"}
            ,{"Reda","PM"}
            ,{"Rejowiec Fabryczny","LB"}
            ,{"Resko","ZP"}
            ,{"Reszel","WM"}
            ,{"Rogoźno","WP"}
            ,{"Ropczyce","PK"}
            ,{"Różan","MZ"}
            ,{"Ruciane-Nida","WM"}
            ,{"Ruda Śląska","ŚL"}
            ,{"Rudnik nad Sanem","PK"}////
            ,{"Rumia","PM"}
            ,{"Rybnik","ŚL"}
            ,{"Rychwał","WP"}
            ,{"Rydułtowy","ŚL"}
            ,{"Rydzyna","WP"}
            ,{"Ryglice","MP"}
            ,{"Ryki","LB"}
            ,{"Rymanów","PK"}
            ,{"Ryn","WM"}
            ,{"Rypin","KP"}
            ,{"Rzepin","LS"}
            ,{"Rzeszów","PK"}
            ,{"Rzgów","ŁD"}
            ,{"Sandomierz","ŚK"}
            ,{"Sanok","PK"}
            ,{"Sejny","PL"}
            ,{"Serock","MZ"}
            ,{"Sędziszów","ŚK"}
            ,{"Sędziszów Małopolski","PK"}
            ,{"Sępopol","WM"}
            ,{"Sępólno Krajeńskie","KP"}
            ,{"Sianów","ZP"}
            ,{"Siechnice","DŚ"}
            ,{"Siedlce","MZ"}
            ,{"Siemianowice Śląskie","ŚL"}
            ,{"Siemiatycze","PL"}
            ,{"Sieniawa","PK"}
            ,{"Sieradz","ŁD"}
            ,{"Sieraków","WP"}
            ,{"Sierpc","MZ"}
            ,{"Siewierz","ŚL"}
            ,{"Skalbmierz","ŚK"}
            ,{"Skała","MP"}
            ,{"Skarszewy","PM"}
            ,{"Skaryszew","MZ"}
            ,{"Skarżysko-Kamienna","ŚK"}
            ,{"Skawina","MP"}
            ,{"Skępe","KP"}
            ,{"Skierniewice","ŁD"}
            ,{"Skoczów","ŚL"}
            ,{"Skoki","WP"}
            ,{"Skórcz","PM"}
            ,{"Skwierzyna","LS"}
            ,{"Sława","LS"}
            ,{"Sławków","ŚL"}
            ,{"Sławno","ZP"}
            ,{"Słomniki","MP"}
            ,{"Słubice","LS"}
            ,{"Słupca","WP"}
            ,{"Słupsk","PM"}
            ,{"Sobótka","DŚ"}
            ,{"Sochaczew","MZ"}
            ,{"Sokołów Małopolski","PK"}
            ,{"Sokołów Podlaski","MZ"}
            ,{"Sokółka","PL"}
            ,{"Solec Kujawski","KP"}
            ,{"Sompolno","WP"}
            ,{"Sopot","PM"}
            ,{"Sosnowiec","ŚL"}
            ,{"Sośnicowice","ŚL"}
            ,{"Stalowa Wola","PK"}
            ,{"Starachowice","ŚK"}
            ,{"Stargard Szczeciński","ZP"}
            ,{"Starogard Gdański","PM"}
            ,{"Stary Sącz","MP"}
            ,{"Staszów","ŚK"}
            ,{"Stawiski","PL"}
            ,{"Stawiszyn","WP"}
            ,{"Stąporków","ŚK"}
            ,{"Stepnica","ZP"}
            ,{"Stęszew","WP"}
            ,{"Stoczek Łukowski","LB"}
            ,{"Stronie Śląskie","DŚ"}
            ,{"Strumień","ŚL"}
            ,{"Stryków","ŁD"}
            ,{"Strzegom","DŚ"}
            ,{"Strzelce Krajeńskie","LS"}
            ,{"Strzelce Opolskie","OP"}
            ,{"Strzelin","DŚ"}
            ,{"Strzelno","KP"}
            ,{"Strzyżów","PK"}
            ,{"Sucha Beskidzka","MP"}
            ,{"Suchań","ZP"}
            ,{"Suchedniów","ŚK"}
            ,{"Suchowola","PL"}
            ,{"Sulechów","LS"}
            ,{"Sulejów","ŁD"}
            ,{"Sulejówek","MZ"}
            ,{"Sulęcin","LS"}
            ,{"Sulmierzyce","WP"}
            ,{"Sułkowice","MP"}
            ,{"Supraśl","PL"}
            ,{"Suraż","PL"}
            ,{"Susz","WM"}
            ,{"Suwałki","PL"}
            ,{"Swarzędz","WP"}
            ,{"Syców","DŚ"}
            ,{"Szadek","ŁD"}
            ,{"Szamocin","WP"}
            ,{"Szamotuły","WP"}
            ,{"Szczawnica","MP"}
            ,{"Szczawno-Zdrój","DŚ"}
            ,{"Szczebrzeszyn","LB"}
            ,{"Szczecin","ZP"}
            ,{"Szczecinek","ZP"}
            ,{"Szczekociny","ŚL"}
            ,{"Szczucin","MP"}
            ,{"Szczuczyn","PL"}
            ,{"Szczyrk","ŚL"}
            ,{"Szczytna","DŚ"}
            ,{"Szczytno","WM"}
            ,{"Szepietowo","PL"}
            ,{"Szklarska Poręba","DŚ"}
            ,{"Szlichtyngowa","LS"}
            ,{"Szprotawa","LS"}
            ,{"Sztum","PM"}
            ,{"Szubin","KP"}
            ,{"Szydłowiec","MZ"}
            ,{"Ścinawa","DŚ"}
            ,{"Ślesin","WP"}
            ,{"Śmigiel","WP"}
            ,{"Śrem","WP"}
            ,{"Środa Śląska","DŚ"}
            ,{"Środa Wielkopolska","WP"}
            ,{"Świątniki Górne","MP"}
            ,{"Świdnica","DŚ"}
            ,{"Świdnik","LB"}
            ,{"Świdwin","ZP"}
            ,{"Świebodzice","DŚ"}
            ,{"Świebodzin","LS"}
            ,{"Świecie","KP"}
            ,{"Świeradów-Zdrój","DŚ"}
            ,{"Świerzawa","DŚ"}
            ,{"Świętochłowice","ŚL"}
            ,{"Świnoujście","ZP"}
            ,{"Tarczyn","MZ"}
            ,{"Tarnobrzeg","PK"}
            ,{"Tarnogród","LB"}
            ,{"Tarnowskie Góry","ŚL"}
            ,{"Tarnów","MP"}
            ,{"Tczew","PM"}
            ,{"Terespol","LB"}
            ,{"Tłuszcz","MZ"}
            ,{"Tolkmicko","WM"}
            ,{"Tomaszów Lubelski","LB"}
            ,{"Tomaszów Mazowiecki","ŁD"}
            ,{"Toruń","KP"}
            ,{"Torzym","LS"}
            ,{"Toszek","ŚL"}
            ,{"Trzcianka","WP"}
            ,{"Trzciel","LS"}
            ,{"Trzcińsko-Zdrój","ZP"}
            ,{"Trzebiatów","ZP"}
            ,{"Trzebinia","MP"}
            ,{"Trzebnica","DŚ"}
            ,{"Trzemeszno","WP"}
            ,{"Tuchola","KP"}
            ,{"Tuchów","MP"}
            ,{"Tuczno","ZP"}
            ,{"Tuliszków","WP"}
            ,{"Turek","WP"}
            ,{"Tuszyn","ŁD"}
            ,{"Twardogóra","DŚ"}
            ,{"Tychowo","ZP"}
            ,{"Tychy","ŚL"}
            ,{"Tyczyn","PK"}
            ,{"Tykocin","PL"}
            ,{"Tyszowce","LB"}
            ,{"Ujazd","OP"}
            ,{"Ujście","WP"}
            ,{"Ulanów","PK"}
            ,{"Uniejów","ŁD"}
            ,{"Ustka","PM"}
            ,{"Ustroń","ŚL"}
            ,{"Ustrzyki Dolne","PK"}
            ,{"Wadowice","MP"}
            ,{"Wałbrzych","DŚ"}
            ,{"Wałcz","ZP"}
            ,{"Warka","MZ"}
            ,{"Warszawa","MZ"}
            ,{"Warta","ŁD"}
            ,{"Wasilków","PL"}
            ,{"Wąbrzeźno","KP"}
            ,{"Wąchock","ŚK"}
            ,{"Wągrowiec","WP"}
            ,{"Wąsosz","DŚ"}
            ,{"Wejherowo","PM"}
            ,{"Węgliniec","DŚ"}
            ,{"Węgorzewo","WM"}
            //,{"Węgorzyno","ZP"}
            ,{"Węgrów","MZ"}
            ,{"Wiązów","DŚ"}
            ,{"Wieleń","WP"}
            ,{"Wielichowo","WP"}
            ,{"Wieliczka","MP"}
            ,{"Wieluń","ŁD"}
            ,{"Wieruszów","ŁD"}
            ,{"Więcbork","KP"}
            ,{"Wilamowice","ŚL"}
            ,{"Wisła","ŚL"}
            ,{"Witkowo","WP"}
            ,{"Witnica","LS"}
            ,{"Wleń","DŚ"}
            ,{"Władysławowo","PM"}
            ,{"Włocławek","KP"}
            ,{"Włodawa","LB"}
            ,{"Włoszczowa","ŚK"}
            ,{"Wodzisław Śląski","ŚL"}
            ,{"Wojcieszów","DŚ"}
            ,{"Wojkowice","ŚL"}
            ,{"Wojnicz","MP"}
            ,{"Wolbórz","ŁD"}
            ,{"Wolbrom","MP"}
            ,{"Wolin","ZP"}
            ,{"Wolsztyn","WP"}
            ,{"Wołczyn","OP"}
            ,{"Wołomin","MZ"}
            ,{"Wołów","DŚ"}
            ,{"Woźniki","ŚL"}
            ,{"Wrocław","DŚ"}
            ,{"Wronki","WP"}
            ,{"Września","WP"}
            ,{"Wschowa","LS"}
            ,{"Wyrzysk","WP"}
            ,{"Wysoka","WP"}
            ,{"Wysokie Mazowieckie","PL"}
            ,{"Wyszków","MZ"}
            ,{"Wyszogród","MZ"}
            ,{"Wyśmierzyce","MZ"}
            ,{"Zabłudów","PL"}
            ,{"Zabrze","ŚL"}
            ,{"Zagórów","WP"}
            ,{"Zagórz","PK"}
            ,{"Zakliczyn","MP"}
            ,{"Zaklików","PK"}
            ,{"Zakopane","MP"}
            ,{"Zakroczym","MZ"}
            ,{"Zalewo","WM"}
            ,{"Zambrów","PL"}
            ,{"Zamość","LB"}
            ,{"Zator","MP"}
            ,{"Zawadzkie","OP"}
            ,{"Zawichost","ŚK"}
            ,{"Zawidów","DŚ"}
            ,{"Zawiercie","ŚL"}
            ,{"Ząbki","MZ"}
            ,{"Ząbkowice Śląskie","DŚ"}
            ,{"Zbąszynek","LS"}
            ,{"Zbąszyń","WP"}
            ,{"Zduny","WP"}
            ,{"Zduńska Wola","ŁD"}
            ,{"Zdzieszowice","OP"}
            ,{"Zelów","ŁD"}
            ,{"Zgierz","ŁD"}
            ,{"Zgorzelec","DŚ"}
            ,{"Zielona Góra","LS"}
            ,{"Zielonka","MZ"}
            ,{"Ziębice","DŚ"}
            ,{"Złocieniec","ZP"}
            ,{"Złoczew","ŁD"}
            ,{"Złotoryja","DŚ"}
            ,{"Złotów","WP"}
            ,{"Złoty Stok","DŚ"}
            ,{"Zwierzyniec","LB"}
            ,{"Zwoleń","MZ"}
            ,{"Żabno","MP"}
            ,{"Żagań","LS"}
            ,{"Żarki","ŚL"}
            ,{"Żarów","DŚ"}
            ,{"Żary","LS"}
            ,{"Żelechów","MZ"}
            ,{"Żerków","WP"}
            ,{"Żmigród","DŚ"}
            ,{"Żnin","KP"}
            ,{"Żory","ŚL"}
            ,{"Żukowo","PM"}
            ,{"Żuromin","MZ"}
            ,{"Żychlin","ŁD"}
            ,{"Żyrardów","MZ"}
            ,{"Żywiec","ŚL"}

        };

        public List<string> Ulice = new List<string>
        {
            "12 Pułku Piechoty",
            "Ady Sari",
            "Bałysa",
            "Barska",
            "Baśniowa",
            "Batorego",
            "Beskidzka",
            "Błonie",
            "Bohaterów Getta",
            "Bohaterów Monte Cassino",
            "Brzozowa",
            "Chopina",
            "Cicha",
            "Doktora Edmunda Wojtyły",
            "dr. J. Putka",
            "Emilii i Karola Wojtyłów",
            "Energetyków",
            "Fabryczna",
            "Gimnazjalna",
            "Gotowizna",
            "Graniczna",
            "Groble",
            "Iwańskiego",
            "Jagiellońska",
            "Jana III Sobieskiego",
            "Jana Pawła II",
            "Janiny Brzostowskiej",
            "Jaśminowa",
            "Jasna",
            "Jaworowa",
            "Jedność",
            "Jesionowe",
            "Karmelicka",
            "Kasztanowa",
            "Klonowa",
            "Kochanowskiego",
            "Konstytucji 3 Maja",
            "Kopernika",
            "Kościelna",
            "Kościuszki",
            "Krakowska",
            "Krasińskiego",
            "Krótka",
            "Kwiatowa",
            "Łąki",
            "Łazówka",
            "Legionów",
            "Leśna",
            "Leszczynowa",
            "Lipowa",
            "Lwowska",
            "marsz. Józefa Piłsudskiego",
            "Matejki",
            "Matki Bożej Fatimskiej",
            "Mickiewicza",
            "Miedzne",
            "Miejski",
            "Młyńska",
            "Mydlarska",
            "M. Wadowity",
            "Nadbrzeżna",
            "Niecała",
            "Niwy",
            "Obrońców Westerplatte",
            "Olbrychta",
            "Parkowa",
            "Piaskowa",
            "Piastowskie",
            "Podgórska",
            "Podmiejska",
            "Podstawie",
            "Pod Skarpą",
            "Pogodna",
            "Polna",
            "Poprzeczna",
            "prof. Nikliborca",
            "Pułaskiego",
            "Rodziny Nowobilskich",
            "Sadowa",
            "Sienkiewicza",
            "Sikorskiego",
            "Słoneczne",
            "Słowackiego",
            "Sosnowa",
            "Spadzista",
            "Spokojna",
            "Spółdzielców",
            "Sportowców",
            "Świerkowa",
            "Szkolna",
            "Szpitalna",
            "Tatrzańska",
            "Teatralna",
            "Topolowa",
            "Trybunalska",
            "Wadowity",
            "Wałowa",
            "Wenecja",
            "Widok",
            "Wiosenna",
            "Wiśniowa",
            "Wojska Polskiego",
            "Wolności",
            "Wowry",
            "XX-lecia PRL",
            "Zaskawie",
            "Zatorska",
            "Zegadłowicza",
            "Żeromskiego",
            "Zielona",
            "Źródlana",
            "Żwirki i Wigury",
            "Zygmunta I Starego"
        };

    }
}
