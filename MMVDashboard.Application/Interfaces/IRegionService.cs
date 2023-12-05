using MMVDashboard.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMVDashboard.Application.Interfaces
{
    public interface IRegionService
    {
        Task<GenericResult> GetAll();

    }
}
