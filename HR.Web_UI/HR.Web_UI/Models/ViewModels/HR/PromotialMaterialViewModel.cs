using HR.Core.Models.RepoModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.Web_UI.Models.ViewModels.HR
{
    public class PromotialMaterialViewModel
    {
        public IPagedList<PromotialMaterial> Materials { get; set; }
        public string Sorting_Order { get; set; }
        public string OrderType { get; set; }
        public string Search_Data { get; set; }
        public string Filter_Value { get; set; }
        public int? Page_No { get; set; }

        public int PageCount { get; set; }
        public int PageNumber { get; set; }
    }
}