using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMVDashboard.Application.Interfaces;
using MMVDashboard.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMVDashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        IRegionService _regiontService;

        public RegionController(IRegionService regiontService)
        {
            _regiontService = regiontService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<GenericResult> GetAll()
        {
            return await _regiontService.GetAll();

        }
    }
}
