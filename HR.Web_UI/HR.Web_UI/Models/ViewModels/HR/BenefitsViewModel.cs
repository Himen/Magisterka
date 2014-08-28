using HR.Core.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace HR.Web_UI.Models.ViewModels.HR
{
    public class BenefitsViewModel
    {
        public IPagedList<BenefitsProfit> Benefits { get; set; }
        public string Sorting_Order { get; set; }
        public string OrderType { get; set; }
        public string Search_Data { get; set; }
        public string Filter_Value { get; set; }
        public int? Page_No { get; set; }

        public int PageCount { get; set; }
        public int PageNumber { get; set; }

        public long PersonId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public string Organization { get; set; }
    }
}