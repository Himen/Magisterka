using DotNet.Highcharts;
using DotNet.Highcharts.Options;
using HR.Core.Models;
using HR.Data.Generator;
using HR.Web_UI.Services.ServicesInferface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Web_UI.Controllers
{
    /// <summary>
    /// Tutaj powinny być umieszczone testy opbierania i zapisywania oraz moze wykresy tych testów
    /// Inserting data
    /// Getiing data
    /// Searching data
    /// Ordering data
    /// Update data 
    /// Delete data
    /// 
    /// Kometarz: przy dawaniu 1000 wierszow w forze 10 wystapilo out of memory
    /// </summary>
    public class OrmTestsController : Controller
    {
        IORMTestService service;
        Generator g;
        SqlConnection con;
        string connString = ConfigurationManager.ConnectionStrings["HR_Database"].ToString();

        public OrmTestsController(IORMTestService service)
        {
            this.service = service;
            g = new Generator();
        }
        // GET: OrmTests
        public ActionResult Index()
        {
            return View();
        }

        //dodac 10 pomiarow 
        #region EF TESTS
        public ActionResult EFInsertDataTestUsingForLoop()
        {
            Stopwatch stopwatch = null;

            List<Person> testPersons = null;
            List<TimeSpan> listOfGeneratedTimes = new List<TimeSpan>();

            for (int i = 0; i < 9; i++)
            {       
                //dla 10 prob zrobic petle i pobrac wyniki
                testPersons = g.GeneratePersons(100);

                // Begin timing
                stopwatch = new Stopwatch();
                stopwatch.Start();

                service.InsertPersonsEF(testPersons);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed);
                testPersons = null;
                stopwatch = null;
            }

            object[] series1 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series1[i] = listOfGeneratedTimes[i].TotalSeconds;
            }

            listOfGeneratedTimes = new List<TimeSpan>();

            for (int i = 0; i < 9; i++)
            {
                //dla 10 prob zrobic petle i pobrac wyniki
                testPersons = g.GeneratePersons(200);

                // Begin timing
                stopwatch = new Stopwatch();
                stopwatch.Start();

                /*for (int i = 0; i < testPersons.Count; i++)
                {*/
                service.InsertPersonsEF(testPersons);
                /*}*/

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed);
                testPersons = null;
                stopwatch = null;
            }

            object[] series2 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series2[i] = listOfGeneratedTimes[i].TotalSeconds;
            }

            listOfGeneratedTimes = new List<TimeSpan>();
            for (int i = 0; i < 9; i++)
            {
                //dla 10 prob zrobic petle i pobrac wyniki
                testPersons = g.GeneratePersons(300);

                // Begin timing
                stopwatch = new Stopwatch();
                stopwatch.Start();

                /*for (int i = 0; i < testPersons.Count; i++)
                {*/
                service.InsertPersonsEF(testPersons);
                /*}*/

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed);
                testPersons = null;
                stopwatch = null;
            }

            object[] series3 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series3[i] = listOfGeneratedTimes[i].TotalSeconds;
            }

            Series[] series = new Series[3];
            series[0] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series1),
                Name = "Dla 100 osób"
            };
            series[1] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series2),
                Name = "Dla 200 osób"
            };
            series[2] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series3),
                Name = "Dla 300 osób"
            };

            var chart = CreateChart(series, "Wstawianie pracowników do bazy danych. EF.");

            return View(chart);
        }

        public ActionResult EFInsertDataRelatedTestUsingForLoop()
        {
            Stopwatch stopwatch = null;

            List<Person> testPersons = null;

            List<Employment> listWorkersToEmploy = null;

            List<TimeSpan> listOfGeneratedTimes = new List<TimeSpan>();

            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();
                testPersons = g.GeneratePersons(100);
                listWorkersToEmploy = new List<Employment>();

                for (int j = 0; j < testPersons.Count; j = j + 1)
                {
                    listWorkersToEmploy.Add(g.EmployWorkerWithOutManager(testPersons[j], "MPJ", "DPJ"));
                }

                // Begin timing
                stopwatch.Start();

                service.InsertEmployeesEF(listWorkersToEmploy);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed);

                stopwatch = null;
                testPersons = null;
                listWorkersToEmploy = null;
            }

            object[] series1 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series1[i] = listOfGeneratedTimes[i].TotalSeconds;
            }

            listOfGeneratedTimes = new List<TimeSpan>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();
                testPersons = g.GeneratePersons(200);
                listWorkersToEmploy = new List<Employment>();

                for (int j = 0; j < testPersons.Count; j = j + 1)
                {
                    listWorkersToEmploy.Add(g.EmployWorkerWithOutManager(testPersons[j], "MPJ", "DPJ"));
                }

                // Begin timing
                stopwatch.Start();

                service.InsertEmployeesEF(listWorkersToEmploy);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed);

                stopwatch = null;
                testPersons = null;
                listWorkersToEmploy = null;
            }

            object[] series2 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series2[i] = listOfGeneratedTimes[i].TotalSeconds;
            }

            listOfGeneratedTimes = new List<TimeSpan>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();
                testPersons = g.GeneratePersons(300);
                listWorkersToEmploy = new List<Employment>();

                for (int j = 0; j < testPersons.Count; j = j + 1)
                {
                    listWorkersToEmploy.Add(g.EmployWorkerWithOutManager(testPersons[j], "MPJ", "DPJ"));
                }

                // Begin timing
                stopwatch.Start();

                service.InsertEmployeesEF(listWorkersToEmploy);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed);

                stopwatch = null;
                testPersons = null;
                listWorkersToEmploy = null;
            }

            object[] series3 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series3[i] = listOfGeneratedTimes[i].TotalSeconds;
            }

            // dodac charta

            Series[] series = new Series[3];
            series[0] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series1),
                Name = "Dla 100 pracowników"
            };
            series[1] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series2),
                Name = "Dla 200 pracowników"
            };
            series[2] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series3),
                Name = "Dla 300 pracowników"
            };

            var chart = CreateChart(series, "Wstawianie zatrudnionych pracowników do bazy danych. EF.");

            return View(chart);
        }


        public ActionResult EFGetingDataTest()
        {
            Stopwatch stopwatch = null;
            List<double> listOfGeneratedTimes= null;

            listOfGeneratedTimes = new List<double>();

            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();

                stopwatch.Start();

                var x = service.GetAllWorkersEF().Take(2000);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series1 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series1[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();
                

                stopwatch.Start();

                var x = service.GetAllWorkersEF().Take(5000);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series2 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series2[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllWorkersEF().Take(10000);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series3 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series3[i] = listOfGeneratedTimes[i];
            }

            Series[] series = new Series[3];
            series[0] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series1),
                Name = "Pobieranie 2000 osób"
            };
            series[1] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series2),
                Name = "Pobieranie 5000 osób"
            };
            series[2] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series3),
                Name = "Pobieranie 10000 osób"
            };

            var chart = CreateChart(series, "Pobieranie danych pracowników. EF.");

            return View(chart);
        }


        public ActionResult EFTestOrderByEmailData()
        {
            Stopwatch stopwatch = null;
            List<double> listOfGeneratedTimes = null;

            listOfGeneratedTimes = new List<double>();

            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();

                stopwatch.Start();

                var x = service.GetAllWorkersEF().Take(2000).OrderBy(c => c.Email);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series1 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series1[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllWorkersEF().Take(5000).OrderBy(c => c.Email);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series2 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series2[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllWorkersEF().Take(10000).OrderBy(c => c.Email);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series3 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series3[i] = listOfGeneratedTimes[i];
            }

            Series[] series = new Series[3];
            series[0] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series1),
                Name = "Dla 2000 osób"
            };
            series[1] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series2),
                Name = "Dla 5000 osób"
            };
            series[2] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series3),
                Name = "Dla 10000 osób"
            };

            var chart = CreateChart(series, "Sortowanie pracowników po adresie email. EF.");

            return View(chart);
        }

        public ActionResult EFTestSearchALetherInEmailData()
        {
            Stopwatch stopwatch = null;
            List<double> listOfGeneratedTimes = null;

            listOfGeneratedTimes = new List<double>();

            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();

                stopwatch.Start();

                var x = service.GetAllWorkersEF().Take(2000).Where(c => c.Email.Contains("a")).ToList();

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series1 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series1[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllWorkersEF().Take(5000).Where(c => c.Email.Contains("a")).ToList();

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series2 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series2[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllWorkersEF().Take(10000).Where(c => c.Email.Contains("a")).ToList();

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series3 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series3[i] = listOfGeneratedTimes[i];
            }

            Series[] series = new Series[3];
            series[0] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series1),
                Name = "Dla 2000 wierszy"
            };
            series[1] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series2),
                Name = "Dla 5000 wierszy"
            };
            series[2] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series3),
                Name = "Dla 10000 wierszy"
            };

            var chart = CreateChart(series, "Znalezienie litery a w emailu. EF.");

            return View(chart);
        }

        public ActionResult UpdatePersonsEF(List<Employment> employees)
        {
            Stopwatch stopwatch = null;
            List<double> listOfGeneratedTimes = null;

            listOfGeneratedTimes = new List<double>();

            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();

                stopwatch.Start();

                var x = service.GetAllEmployeesEF().Take(2000).ToList();

                foreach (var item in x)
                {
                    item.EmploymentType = Core.Enums.EmploymentType.Zwolniony;
                    item.EditDate = DateTime.Now;
                    item.EndDate = DateTime.Now;
                }

                service.UpdateEmploymentEF(x);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series1 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series1[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllEmployeesEF().Take(5000).ToList();

                foreach (var item in x)
                {
                    item.EmploymentType = Core.Enums.EmploymentType.Zwolniony;
                    item.EditDate = DateTime.Now;
                    item.EndDate = DateTime.Now;
                }

                service.UpdateEmploymentEF(x);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series2 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series2[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllEmployeesEF().Take(10000).ToList();

                foreach (var item in x)
                {
                    item.EmploymentType = Core.Enums.EmploymentType.Zwolniony;
                    item.EditDate = DateTime.Now;
                    item.EndDate = DateTime.Now;
                }

                service.UpdateEmploymentEF(x);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series3 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series3[i] = listOfGeneratedTimes[i];
            }

            Series[] series = new Series[3];
            series[0] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series1),
                Name = "Dla 2000 wierszy"
            };
            series[1] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series2),
                Name = "Dla 5000 wierszy"
            };
            series[2] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series3),
                Name = "Dla 10000 wierszy"
            };

            var chart = CreateChart(series, "Modyfikacja danych zatrudnienia. EF.");

            return View(chart);
        }

        public ActionResult DeletePersonsEF(List<Employment> employees)
        {
            Stopwatch stopwatch = null;
            List<double> listOfGeneratedTimes = null;

            listOfGeneratedTimes = new List<double>();

            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();

                stopwatch.Start();

                var x = service.GetAllEmployeesEF().Take(2000).ToList();
                service.DeleteEmploymentEF(x);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series1 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series1[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllEmployeesEF().Take(5000).ToList();
                service.DeleteEmploymentEF(x);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series2 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series2[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllEmployeesEF().Take(10000).ToList();
                service.DeleteEmploymentEF(x);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series3 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series3[i] = listOfGeneratedTimes[i];
            }

            Series[] series = new Series[3];
            series[0] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series1),
                Name = "Dla 2000 wierszy"
            };
            series[1] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series2),
                Name = "Dla 5000 wierszy"
            };
            series[2] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series3),
                Name = "Dla 10000 wierszy"
            };

            var chart = CreateChart(series, "Usunięcie pracowników. EF.");

            return View(chart);
        }
        


        #endregion


        #region NHibernate

        public ActionResult  NHInsertDataTestUsingForLoop()
        {
            Stopwatch stopwatch = null;

            List<Person> testPersons = null;
            List<TimeSpan> listOfGeneratedTimes = new List<TimeSpan>();

            for (int i = 0; i < 9; i++)
            {
                //dla 10 prob zrobic petle i pobrac wyniki
                testPersons = g.GeneratePersons(100);

                // Begin timing
                stopwatch = new Stopwatch();
                stopwatch.Start();

                service.InsertPersonsNH(testPersons);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed);
                testPersons = null;
                stopwatch = null;
            }

            object[] series1 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series1[i] = listOfGeneratedTimes[i].TotalSeconds;
            }

            listOfGeneratedTimes = new List<TimeSpan>();

            for (int i = 0; i < 9; i++)
            {
                //dla 10 prob zrobic petle i pobrac wyniki
                testPersons = g.GeneratePersons(200);

                // Begin timing
                stopwatch = new Stopwatch();
                stopwatch.Start();

                /*for (int i = 0; i < testPersons.Count; i++)
                {*/
                service.InsertPersonsNH(testPersons);
                /*}*/

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed);
                testPersons = null;
                stopwatch = null;
            }

            object[] series2 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series2[i] = listOfGeneratedTimes[i].TotalSeconds;
            }

            listOfGeneratedTimes = new List<TimeSpan>();
            for (int i = 0; i < 9; i++)
            {
                //dla 10 prob zrobic petle i pobrac wyniki
                testPersons = g.GeneratePersons(300);

                // Begin timing
                stopwatch = new Stopwatch();
                stopwatch.Start();

                /*for (int i = 0; i < testPersons.Count; i++)
                {*/
                service.InsertPersonsNH(testPersons);
                /*}*/

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed);
                testPersons = null;
                stopwatch = null;
            }

            object[] series3 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series3[i] = listOfGeneratedTimes[i].TotalSeconds;
            }

            Series[] series = new Series[3];
            series[0] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series1),
                Name = "Dla 100 osób"
            };
            series[1] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series2),
                Name = "Dla 200 osób"
            };
            series[2] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series3),
                Name = "Dla 300 osób"
            };

            var chart = CreateChart(series, "Wstawianie pracowników do bazy danych. NH.");

            return View(chart);
        }

        public ActionResult NHInsertDataRelatedTestUsingForLoop()
        {
            Stopwatch stopwatch = null;

            List<Person> testPersons = null;

            List<Employment> listWorkersToEmploy = null;

            List<TimeSpan> listOfGeneratedTimes = new List<TimeSpan>();

            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();
                testPersons = g.GeneratePersons(100);
                listWorkersToEmploy = new List<Employment>();

                for (int j = 0; j < testPersons.Count; j = j + 1)
                {
                    listWorkersToEmploy.Add(g.EmployWorkerWithOutManager(testPersons[j], "MPJ", "DPJ"));
                }

                // Begin timing
                stopwatch.Start();

                service.InsertEmployeesNH(listWorkersToEmploy);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed);

                stopwatch = null;
                testPersons = null;
                listWorkersToEmploy = null;
            }

            object[] series1 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series1[i] = listOfGeneratedTimes[i].TotalSeconds;
            }

            listOfGeneratedTimes = new List<TimeSpan>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();
                testPersons = g.GeneratePersons(300);
                listWorkersToEmploy = new List<Employment>();

                for (int j = 0; j < testPersons.Count; j = j + 1)
                {
                    listWorkersToEmploy.Add(g.EmployWorkerWithOutManager(testPersons[j], "MPJ", "DPJ"));
                }

                // Begin timing
                stopwatch.Start();

                service.InsertEmployeesNH(listWorkersToEmploy);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed);

                stopwatch = null;
                testPersons = null;
                listWorkersToEmploy = null;
            }

            object[] series2 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series2[i] = listOfGeneratedTimes[i].TotalSeconds;
            }

            listOfGeneratedTimes = new List<TimeSpan>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();
                testPersons = g.GeneratePersons(1000);
                listWorkersToEmploy = new List<Employment>();

                for (int j = 0; j < testPersons.Count; j = j + 1)
                {
                    listWorkersToEmploy.Add(g.EmployWorkerWithOutManager(testPersons[j], "MPJ", "DPJ"));
                }

                // Begin timing
                stopwatch.Start();

                service.InsertEmployeesNH(listWorkersToEmploy);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed);

                stopwatch = null;
                testPersons = null;
                listWorkersToEmploy = null;
            }

            object[] series3 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series3[i] = listOfGeneratedTimes[i].TotalSeconds;
            }

            // dodac charta

            Series[] series = new Series[3];
            series[0] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series1),
                Name = "Dla 100 pracowników"
            };
            series[1] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series2),
                Name = "Dla 300 pracowników"
            };
            series[2] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series3),
                Name = "Dla 1000 pracowników"
            };

            var chart = CreateChart(series, "Wstawianie zatrudnionych pracowników do bazy danych. NH.");

            return View(chart);
        }


        public ActionResult NHGetingDataTest()
        {
            Stopwatch stopwatch = null;
            List<double> listOfGeneratedTimes = null;

            listOfGeneratedTimes = new List<double>();

            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();

                stopwatch.Start();

                var x = service.GetAllWorkersNH().Take(2000);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series1 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series1[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllWorkersNH().Take(5000);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series2 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series2[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllWorkersNH().Take(10000);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series3 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series3[i] = listOfGeneratedTimes[i];
            }

            Series[] series = new Series[3];
            series[0] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series1),
                Name = "Pobieranie 2000 osób"
            };
            series[1] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series2),
                Name = "Pobieranie 5000 osób"
            };
            series[2] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series3),
                Name = "Pobieranie 10000 osób"
            };

            var chart = CreateChart(series, "Pobieranie danych pracowników. NH.");

            return View(chart);
        }


        public ActionResult NHTestOrderByEmailData()
        {
            Stopwatch stopwatch = null;
            List<double> listOfGeneratedTimes = null;

            listOfGeneratedTimes = new List<double>();

            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();

                stopwatch.Start();

                var x = service.GetAllWorkersNH().Take(2000).OrderBy(c => c.Email);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series1 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series1[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllWorkersNH().Take(5000).OrderBy(c => c.Email);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series2 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series2[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllWorkersNH().Take(10000).OrderBy(c => c.Email);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series3 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series3[i] = listOfGeneratedTimes[i];
            }

            Series[] series = new Series[3];
            series[0] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series1),
                Name = "Dla 2000 osób"
            };
            series[1] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series2),
                Name = "Dla 5000 osób"
            };
            series[2] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series3),
                Name = "Dla 10000 osób"
            };

            var chart = CreateChart(series, "Sortowanie pracowników po adresie email. NH.");

            return View(chart);
        }

        public ActionResult NHTestSearchALetherInEmailData()
        {
            Stopwatch stopwatch = null;
            List<double> listOfGeneratedTimes = null;

            listOfGeneratedTimes = new List<double>();

            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();

                stopwatch.Start();

                var x = service.GetAllWorkersNH().Take(2000).Where(c => c.Email.Contains("a")).ToList();

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series1 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series1[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllWorkersNH().Take(5000).Where(c => c.Email.Contains("a")).ToList();

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series2 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series2[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllWorkersNH().Take(10000).Where(c => c.Email.Contains("a")).ToList();

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series3 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series3[i] = listOfGeneratedTimes[i];
            }

            Series[] series = new Series[3];
            series[0] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series1),
                Name = "Dla 2000 wierszy"
            };
            series[1] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series2),
                Name = "Dla 5000 wierszy"
            };
            series[2] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series3),
                Name = "Dla 10000 wierszy"
            };

            var chart = CreateChart(series, "Znalezienie litery a w emailu. NH.");

            return View(chart);
        }


        public ActionResult UpdatePersonsNH()
        {
            Stopwatch stopwatch = null;
            List<double> listOfGeneratedTimes = null;

            listOfGeneratedTimes = new List<double>();

            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();

                stopwatch.Start();

                var x = service.GetAllEmployeesNH().Take(2000).ToList();

                foreach (var item in x)
                {
                    item.EmploymentType = Core.Enums.EmploymentType.Zwolniony;
                    item.EditDate = DateTime.Now;
                    item.EndDate = DateTime.Now;
                }

                service.UpdateEmploymentNH(x);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series1 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series1[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllEmployeesNH().Take(5000).ToList();

                foreach (var item in x)
                {
                    item.EmploymentType = Core.Enums.EmploymentType.Zwolniony;
                    item.EditDate = DateTime.Now;
                    item.EndDate = DateTime.Now;
                }

                service.UpdateEmploymentNH(x);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series2 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series2[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllEmployeesNH().Take(10000).ToList();

                foreach (var item in x)
                {
                    item.EmploymentType = Core.Enums.EmploymentType.Zwolniony;
                    item.EditDate = DateTime.Now;
                    item.EndDate = DateTime.Now;
                }

                service.UpdateEmploymentNH(x);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series3 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series3[i] = listOfGeneratedTimes[i];
            }

            Series[] series = new Series[3];
            series[0] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series1),
                Name = "Dla 2000 wierszy"
            };
            series[1] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series2),
                Name = "Dla 5000 wierszy"
            };
            series[2] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series3),
                Name = "Dla 10000 wierszy"
            };

            var chart = CreateChart(series, "Modyfikacja danych zatrudnienia. NH.");

            return View(chart);
        }

        public ActionResult DeletePersonsNH()
        {
            Stopwatch stopwatch = null;
            List<double> listOfGeneratedTimes = null;

            listOfGeneratedTimes = new List<double>();

            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();

                stopwatch.Start();

                var x = service.GetAllEmployeesNH().Take(100).ToList();
                service.DeleteEmploymentNH(x);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series1 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series1[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllEmployeesNH().Take(200).ToList();
                service.DeleteEmploymentNH(x);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series2 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series2[i] = listOfGeneratedTimes[i];
            }

            listOfGeneratedTimes = new List<double>();
            for (int i = 0; i < 9; i++)
            {
                stopwatch = new Stopwatch();


                stopwatch.Start();

                var x = service.GetAllEmployeesNH().Take(300).ToList();
                service.DeleteEmploymentNH(x);

                stopwatch.Stop();

                listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

            }

            object[] series3 = new object[9];
            for (int i = 0; i < 9; i++)
            {
                series3[i] = listOfGeneratedTimes[i];
            }

            Series[] series = new Series[3];
            series[0] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series1),
                Name = "Dla 100 wierszy"
            };
            series[1] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series2),
                Name = "Dla 200 wierszy"
            };
            series[2] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(series3),
                Name = "Dla 300 wierszy"
            };

            var chart = CreateChart(series, "Usunięcie pracowników. NH.");

            return View(chart);
        }




        public ActionResult ChartTest()
        {
            HR.DataAccess.Dapper.TemporarySolution.Repository rep = new DataAccess.Dapper.TemporarySolution.Repository();

            List<Person> per = g.GeneratePersons(2);

            rep.InsertPersons(per);

            Series[] series = new Series[3];
            series[0] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(new object[] { 0.012, 0.012, 0.012, 0.012, 0.012, 0.012, 0.012, 0.012, 0.012, 0.012 }),
                Name = "Wstawienie 100 osób"
            };
            series[1] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(new object[] { 0.012, 0.012, 0.012, 0.012, 0.012, 0.012, 0.012, 0.012, 0.012, 0.012 }),
                Name = "Wstawienie 300 osób"
            };
            series[2] = new Series
            {
                Data = new DotNet.Highcharts.Helpers.Data(new object[] { 0.012, 0.012, 0.012, 0.012, 0.012, 0.012, 0.012, 0.012, 0.012, 0.012 }),
                Name = "Wstawienie 1000 osób"
            };

            var chart = CreateChart(series,"Wstawianie osób do bazy danych");

            return View(chart);
        }

        #endregion

        #region Dapper
        /*public ActionResult DapperTestIns()
        {

            List<Person> testPersons = g.GeneratePersons(1);
            using (con = new SqlConnection(connString))
            {
            
                con.Open();
                service.InsertEmployeesDAP(testPersons,con);
            }
            
            

            return View();
        }*/

        public ActionResult DAPInsertDataTestUsingForLoop()
        {
            Stopwatch stopwatch = null;
            Series[] series = new Series[3];
            List<Person> testPersons = null;
            List<TimeSpan> listOfGeneratedTimes = new List<TimeSpan>();

            using (con =new SqlConnection(connString))
            {
                for (int i = 0; i < 9; i++)
                {
                    //dla 10 prob zrobic petle i pobrac wyniki
                    testPersons = g.GeneratePersons(100);

                    // Begin timing
                    stopwatch = new Stopwatch();
                    stopwatch.Start();

                    service.InsertPersonsDAP(testPersons,con);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed);
                    testPersons = null;
                    stopwatch = null;
                }

                object[] series1 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series1[i] = listOfGeneratedTimes[i].TotalSeconds;
                }

                listOfGeneratedTimes = new List<TimeSpan>();

                for (int i = 0; i < 9; i++)
                {
                    //dla 10 prob zrobic petle i pobrac wyniki
                    testPersons = g.GeneratePersons(200);

                    // Begin timing
                    stopwatch = new Stopwatch();
                    stopwatch.Start();

                    /*for (int i = 0; i < testPersons.Count; i++)
                    {*/
                    service.InsertPersonsDAP(testPersons, con);
                    /*}*/

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed);
                    testPersons = null;
                    stopwatch = null;
                }

                object[] series2 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series2[i] = listOfGeneratedTimes[i].TotalSeconds;
                }

                listOfGeneratedTimes = new List<TimeSpan>();
                for (int i = 0; i < 9; i++)
                {
                    //dla 10 prob zrobic petle i pobrac wyniki
                    testPersons = g.GeneratePersons(300);

                    // Begin timing
                    stopwatch = new Stopwatch();
                    stopwatch.Start();

                    /*for (int i = 0; i < testPersons.Count; i++)
                    {*/
                    service.InsertPersonsDAP(testPersons, con);
                    /*}*/

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed);
                    testPersons = null;
                    stopwatch = null;
                }
            

                object[] series3 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series3[i] = listOfGeneratedTimes[i].TotalSeconds;
                }

                
                series[0] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series1),
                    Name = "Dla 100 osób"
                };
                series[1] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series2),
                    Name = "Dla 200 osób"
                };
                series[2] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series3),
                    Name = "Dla 300 osób"
                };
            }

            var chart = CreateChart(series, "Wstawianie pracowników do bazy danych. Dapper.");

            return View(chart);
        }
        public ActionResult DapperInsertDataRelatedTestUsingForLoop()
        {
            Stopwatch stopwatch = null;

            List<Person> testPersons = null;

            List<Employment> listWorkersToEmploy = null;

            List<TimeSpan> listOfGeneratedTimes = new List<TimeSpan>();

            Series[] series = new Series[3];

            using (con = new SqlConnection(connString))
            {
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();
                    testPersons = g.GeneratePersons(100);
                    listWorkersToEmploy = new List<Employment>();

                    for (int j = 0; j < testPersons.Count; j = j + 1)
                    {
                        listWorkersToEmploy.Add(g.EmployWorkerWithOutManager(testPersons[j], "MPJ", "DPJ"));
                    }

                    // Begin timing
                    stopwatch.Start();

                    service.InsertEmployeesDAP(listWorkersToEmploy, con);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed);

                    stopwatch = null;
                    testPersons = null;
                    listWorkersToEmploy = null;
                }

                object[] series1 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series1[i] = listOfGeneratedTimes[i].TotalSeconds;
                }

                listOfGeneratedTimes = new List<TimeSpan>();
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();
                    testPersons = g.GeneratePersons(200);
                    listWorkersToEmploy = new List<Employment>();

                    for (int j = 0; j < testPersons.Count; j = j + 1)
                    {
                        listWorkersToEmploy.Add(g.EmployWorkerWithOutManager(testPersons[j], "MPJ", "DPJ"));
                    }

                    // Begin timing
                    stopwatch.Start();

                    service.InsertEmployeesDAP(listWorkersToEmploy, con);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed);

                    stopwatch = null;
                    testPersons = null;
                    listWorkersToEmploy = null;
                }

                object[] series2 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series2[i] = listOfGeneratedTimes[i].TotalSeconds;
                }

                listOfGeneratedTimes = new List<TimeSpan>();
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();
                    testPersons = g.GeneratePersons(300);
                    listWorkersToEmploy = new List<Employment>();

                    for (int j = 0; j < testPersons.Count; j = j + 1)
                    {
                        listWorkersToEmploy.Add(g.EmployWorkerWithOutManager(testPersons[j], "MPJ", "DPJ"));
                    }

                    // Begin timing
                    stopwatch.Start();

                    service.InsertEmployeesDAP(listWorkersToEmploy, con);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed);

                    stopwatch = null;
                    testPersons = null;
                    listWorkersToEmploy = null;
                }

                object[] series3 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series3[i] = listOfGeneratedTimes[i].TotalSeconds;
                }

                // dodac charta

                
                series[0] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series1),
                    Name = "Dla 100 pracowników"
                };
                series[1] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series2),
                    Name = "Dla 200 pracowników"
                };
                series[2] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series3),
                    Name = "Dla 300 pracowników"
                };
            }

            var chart = CreateChart(series, "Wstawianie zatrudnionych pracowników do bazy danych. Dapper.");

            return View(chart);
        }

        public ActionResult DAPGetingDataTest()
        {
            Stopwatch stopwatch = null;
            List<double> listOfGeneratedTimes = null;
            Series[] series = new Series[3];

            listOfGeneratedTimes = new List<double>();

            using (con = new SqlConnection(connString))
            {
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();

                    stopwatch.Start();

                    var x = service.GetAllWorkersDAP(con, 2000);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

                }

                object[] series1 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series1[i] = listOfGeneratedTimes[i];
                }

                listOfGeneratedTimes = new List<double>();
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();


                    stopwatch.Start();

                    var x = service.GetAllWorkersDAP(con, 5000);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

                }

                object[] series2 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series2[i] = listOfGeneratedTimes[i];
                }

                listOfGeneratedTimes = new List<double>();
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();


                    stopwatch.Start();

                    var x = service.GetAllWorkersDAP(con, 5000);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

                }

                object[] series3 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series3[i] = listOfGeneratedTimes[i];
                }

                
                series[0] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series1),
                    Name = "Pobieranie 2000 osób"
                };
                series[1] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series2),
                    Name = "Pobieranie 5000 osób"
                };
                series[2] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series3),
                    Name = "Pobieranie 10000 osób"
                };
            }
            var chart = CreateChart(series, "Pobieranie danych pracowników. Dapper.");

            return View(chart);
        }


        public ActionResult DAPTestOrderByEmailData()
        {
            Stopwatch stopwatch = null;
            List<double> listOfGeneratedTimes = null;
            Series[] series = new Series[3];

            listOfGeneratedTimes = new List<double>();

            using (con = new SqlConnection(connString))
            {
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();

                    stopwatch.Start();

                    var x = service.GetAllWorkersDAPOrder(con, "Emapil",2000);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

                }

                object[] series1 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series1[i] = listOfGeneratedTimes[i];
                }

                listOfGeneratedTimes = new List<double>();
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();


                    stopwatch.Start();

                    var x = service.GetAllWorkersDAPOrder(con, "Emapil", 5000);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

                }

                object[] series2 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series2[i] = listOfGeneratedTimes[i];
                }

                listOfGeneratedTimes = new List<double>();
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();


                    stopwatch.Start();

                    var x = service.GetAllWorkersDAPOrder(con, "Emapil", 10000);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

                }

                object[] series3 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series3[i] = listOfGeneratedTimes[i];
                }

                
                series[0] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series1),
                    Name = "Dla 2000 osób"
                };
                series[1] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series2),
                    Name = "Dla 5000 osób"
                };
                series[2] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series3),
                    Name = "Dla 10000 osób"
                };
            }

            var chart = CreateChart(series, "Sortowanie pracowników po adresie email. Dapper.");

            return View(chart);
        }

        //problem z dzialaniem
        public ActionResult DAPTestSearchALetherInEmailData()
        {
            Stopwatch stopwatch = null;
            List<double> listOfGeneratedTimes = null;
            Series[] series = new Series[3];

            listOfGeneratedTimes = new List<double>();

            using (con = new SqlConnection(connString))
            {
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();

                    stopwatch.Start();

                    var x = service.GetAllWorkersDAPWhere(con, "", 2000);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

                }

                object[] series1 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series1[i] = listOfGeneratedTimes[i];
                }

                listOfGeneratedTimes = new List<double>();
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();


                    stopwatch.Start();

                    var x = service.GetAllWorkersDAPWhere(con, "", 5000);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

                }

                object[] series2 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series2[i] = listOfGeneratedTimes[i];
                }

                listOfGeneratedTimes = new List<double>();
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();


                    stopwatch.Start();

                    var x = service.GetAllWorkersDAPWhere(con, "", 10000);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

                }

                object[] series3 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series3[i] = listOfGeneratedTimes[i];
                }


                series[0] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series1),
                    Name = "Dla 2000 wierszy"
                };
                series[1] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series2),
                    Name = "Dla 5000 wierszy"
                };
                series[2] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series3),
                    Name = "Dla 10000 wierszy"
                };
            }

            var chart = CreateChart(series, "Znalezienie litery a w emailu. Dapper.");

            return View(chart);
        }


        public ActionResult UpdatePersonsDAP(List<Employment> employees)
        {
            Stopwatch stopwatch = null;
            List<double> listOfGeneratedTimes = null;

            Series[] series = new Series[3];

            listOfGeneratedTimes = new List<double>();

            using (con = new SqlConnection(connString))
            {
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();



                    var x = service.GetAllEmployeesEF().Take(2000).ToList();

                    foreach (var item in x)
                    {
                        item.EmploymentType = Core.Enums.EmploymentType.Zwolniony;
                        item.EditDate = DateTime.Now;
                        item.EndDate = DateTime.Now;
                    }
                    stopwatch.Start();

                    service.UpdateEmploymentDAP(x, con);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

                }

                object[] series1 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series1[i] = listOfGeneratedTimes[i];
                }

                listOfGeneratedTimes = new List<double>();
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();




                    var x = service.GetAllEmployeesEF().Take(5000).ToList();

                    foreach (var item in x)
                    {
                        item.EmploymentType = Core.Enums.EmploymentType.Zwolniony;
                        item.EditDate = DateTime.Now;
                        item.EndDate = DateTime.Now;
                    }

                    stopwatch.Start();

                    service.UpdateEmploymentDAP(x, con);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

                }

                object[] series2 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series2[i] = listOfGeneratedTimes[i];
                }

                listOfGeneratedTimes = new List<double>();
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();




                    var x = service.GetAllEmployeesEF().Take(10000).ToList();

                    foreach (var item in x)
                    {
                        item.EmploymentType = Core.Enums.EmploymentType.Zwolniony;
                        item.EditDate = DateTime.Now;
                        item.EndDate = DateTime.Now;
                    }

                    stopwatch.Start();

                    service.UpdateEmploymentDAP(x, con);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

                }

                object[] series3 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series3[i] = listOfGeneratedTimes[i];
                }

                
                series[0] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series1),
                    Name = "Dla 2000 wierszy"
                };
                series[1] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series2),
                    Name = "Dla 5000 wierszy"
                };
                series[2] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series3),
                    Name = "Dla 10000 wierszy"
                };

            }
            var chart = CreateChart(series, "Modyfikacja danych zatrudnienia. Dapper.");

            return View(chart);
        }


        //trzeba najperw dane wsadzic rzeby przetestowac bo usniete wszystie
        public ActionResult DeletePersonsDAP()
        {
            Stopwatch stopwatch = null;
            List<double> listOfGeneratedTimes = null;
            Series[] series = new Series[3];

            listOfGeneratedTimes = new List<double>();

            using (con = new SqlConnection(connString))
            {
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();

                    stopwatch.Start();

                    var x = service.GetAllEmployeesDAP(con, 2000);
                    service.DeleteEmploymentDAP(x.ToList(), con);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

                }

                object[] series1 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series1[i] = listOfGeneratedTimes[i];
                }

                listOfGeneratedTimes = new List<double>();
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();


                    stopwatch.Start();

                    var x = service.GetAllEmployeesDAP(con, 5000);
                    service.DeleteEmploymentDAP(x.ToList(), con);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

                }

                object[] series2 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series2[i] = listOfGeneratedTimes[i];
                }

                listOfGeneratedTimes = new List<double>();
                for (int i = 0; i < 9; i++)
                {
                    stopwatch = new Stopwatch();


                    stopwatch.Start();

                    var x = service.GetAllEmployeesDAP(con, 10000);
                    service.DeleteEmploymentDAP(x.ToList(), con);

                    stopwatch.Stop();

                    listOfGeneratedTimes.Add(stopwatch.Elapsed.TotalSeconds);

                }

                object[] series3 = new object[9];
                for (int i = 0; i < 9; i++)
                {
                    series3[i] = listOfGeneratedTimes[i];
                }

                
                series[0] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series1),
                    Name = "Dla 2000 wierszy"
                };
                series[1] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series2),
                    Name = "Dla 5000 wierszy"
                };
                series[2] = new Series
                {
                    Data = new DotNet.Highcharts.Helpers.Data(series3),
                    Name = "Dla 10000 wierszy"
                };
            }
            var chart = CreateChart(series, "Usunięcie pracowników. Dapper.");

            return View(chart);
        }
        


        #endregion


        private Highcharts CreateChart(Series[] series,string chartTitle)
        {
            Highcharts chart = new Highcharts("chart")
                           .SetXAxis(new XAxis
                           {
                               Categories = new[] { "1 pomiar", "2 pomiar", "3 pomiar", "4 pomiar", "5 pomiar", "6 pomiar", "7 pomiar", "8 pomiar", "9 pomiar", "10 pomiar", "11 pomiar" }
                           })
                           .SetSeries(series)
                           .SetTitle(new Title { Text = chartTitle })
                           .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Czas" } });

            return chart;
        }


    }
}