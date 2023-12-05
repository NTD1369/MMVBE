using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMVDashboard.Application.Interfaces;
using MMVDashboard.Data.Entities;
using MMVDashboard.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMVDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeySalesPerformanceController : ControllerBase
    {
        IKeySalesPerformanceService _keySalesPerformanceService;

        public KeySalesPerformanceController(IKeySalesPerformanceService keySalesPerformanceService)
        {
            _keySalesPerformanceService = keySalesPerformanceService;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<GenericResult> GetAll()
        {
            return await _keySalesPerformanceService.GetAll();

        }
    }

   
}
