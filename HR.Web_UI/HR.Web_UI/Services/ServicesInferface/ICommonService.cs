using HR.Core.Models.RepoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Web_UI.Services.ServicesInferface
{
    public interface ICommonService
    {
        IQueryable<PromotialMaterial> GetAllMaterials();
    }
}
