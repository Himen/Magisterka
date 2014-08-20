using HR.Web_UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Web_UI.Services.ServicesInferface
{
    public interface IHRServices
    {
        bool CreateWorker(PersonViewModel pVM);
    }
}
