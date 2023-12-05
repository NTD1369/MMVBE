using MMVDashboard.Data.Entities;
using MMVDashboard.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMVDashboard.Application.Interfaces
{
    public interface IKeySalesPerformanceService
    {
        Task<GenericResult> GetAll();

    }
}
