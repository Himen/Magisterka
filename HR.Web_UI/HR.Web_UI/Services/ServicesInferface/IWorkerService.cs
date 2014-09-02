using HR.Core.Models;
using HR.Core.Models.RepoModels;
using HR.Web_UI.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Web_UI.Services.ServicesInferface
{
    public interface IWorkerService
    {
        AccountViewModel GetAccount(long id);
        IQueryable<AccountLog> GetUserLogs(long id);
        IEnumerable<BenefitsProfit> GetAllWorkerBenefits(long Id);
        string GetPositionName(string key);
        string GetOrganizationName(string key);
    }
}
