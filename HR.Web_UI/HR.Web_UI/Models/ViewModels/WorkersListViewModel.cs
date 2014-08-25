using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR.Core.Models;

namespace HR.Web_UI.Models.ViewModels
{
    public class WorkersListViewModel
    {
        public IEnumerable<Person> Workers { get; set; }
        public string Sorting_Order { get; set; }
        public string Search_Data { get; set; }
        public string Filter_Value { get; set; }
        public int? Page_No { get; set; }
    }
}