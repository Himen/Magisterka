using HR.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.Web_UI.Models.ViewModels.HR
{
    public class TraningsViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public TrainingType Type { get; set; }
        public DateTime DateOfPass { get; set; }
        public string Description { get; set; }

    }
}