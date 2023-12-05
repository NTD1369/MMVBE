
using MMVDashboard.Application.Helpers;
using MMVDashboard.Data.Entities;
using MMVDashboard.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMVDashboard.Application.Interfaces
{
    public interface IUserService
    {
        Task<GenericResult> GetAll(string CompanyCode, string StoreId, string DailyId ); 
        Task<GenericResult> GetByCode(string CompanyCode, string StoreId, string DailyId, string Id); 
        Task<GenericResult> Login(string userName, string passWord);
        Task<GenericResult> Update(MUser model);
        Task<GenericResult> Delete(MUser model); 
    }
}
