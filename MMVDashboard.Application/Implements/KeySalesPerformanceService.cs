using Dapper;
using MMVDashboard.Application.Interfaces;
using MMVDashboard.Data.Entities;
using MMVDashboard.Data.Repositories;
using MMVDashboard.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMVDashboard.Application.Implements
{
    public class KeySalesPerformanceService: IKeySalesPerformanceService
    {
        private readonly IGenericRepository<KeySalesPerformance> _keySalesPerformanceService;

        public KeySalesPerformanceService(IGenericRepository<KeySalesPerformance> keySalesPerformanceService)
        {
            _keySalesPerformanceService = keySalesPerformanceService;
        }
        public async Task<GenericResult> GetAll()
        {
            GenericResult result = new GenericResult();
            try
            {
                //var parameters = new DynamicParameters();
                //parameters.Add("RTMTD",model.RTMTD);
                //parameters.Add("RTvsBP", model.RTvsBP);
                //parameters.Add("RTvsFY20", model.RTvsFY20);
                //parameters.Add("RTvsPM", model.RTvsPM);
                //parameters.Add("RTvsPY", model.RTvsPY);
                //parameters.Add("RTYTD", model.RTYTD);
                //parameters.Add("WSMTD", model.WSMTD);
                //parameters.Add("WSvsBP", model.WSvsBP);
                //parameters.Add("WSvsFY20", model.WSvsFY20);
                //parameters.Add("WSvsPM", model.WSvsPM);
                //parameters.Add("WSvsPY", model.WSvsPY);
                //parameters.Add("WSYTD", model.WSYTD);

                var data = await _keySalesPerformanceService.GetAllAsync($"USP_S_MKeySalesPerformance", null, commandType: CommandType.StoredProcedure);
                result.Data = data;

                result.Success = true;

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        
    }
}
