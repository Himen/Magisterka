using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR.Core.Models;
using PagedList;

namespace HR.Web_UI.Models.ViewModels
{
    public class WorkersListViewModel
    {
        public IPagedList<Person> Workers { get; set; }
        public string Sorting_Order { get; set; }
        public string OrderType { get; set; }
        public string Search_Data { get; set; }
        public string Filter_Value { get; set; }
        public int? Page_No { get; set; }

        public int PageCount { get; set; }
        public int PageNumber { get; set; }
    }
}