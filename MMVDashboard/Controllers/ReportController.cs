using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class ReportController : ControllerBase
    {
        IReportService _reportService;
        private readonly ILogger<UserController> _logger;

        public ReportController(ILogger<UserController> logger, IReportService userService)
        {
            _logger = logger;
            _reportService = userService;
        }

        [HttpGet]
        [Route("GetDealerByRegion")]
        public async Task<GenericResult> GetDealerByRegion(string region)
        {
            return await _reportService.GetDealerByRegion(region);

        } 
        
        [HttpGet]
        [Route("GetFullYear")]

        public async Task<GenericResult> GetFullYear(string CompanyCode)
        {
            return await _reportService.GETFullYear(CompanyCode);

        }
        [HttpGet]
        [Route("GetKeySalesPerformance")]

        public async Task<GenericResult> GetKeySalesPerformance(string Region, string Dealer, string Month, string Year, string rptType)
        {
            return await _reportService.GetKeySalesPerformance(Region,  Dealer,  Month,  Year, rptType);

        }

        [HttpGet]
        [Route("GetPartsSalesPerformance")]

        public async Task<GenericResult> GetPartsSalesPerformance(string Region, string Dealer, string Month, string Year, string rptType)
        {
            return await _reportService.GetPartsSalesPerformance(Region, Dealer, Month, Year, rptType);

        }

        [HttpGet]
        [Route("GetDealerStockWSValue")]

        public async Task<GenericResult> GetDealerStockWSValue(string Region, string Dealer, string Month, string Year, string rptType)
        {
            return await _reportService.GetDealerStockWSValue(Region, Dealer, Month, Year, rptType);

        }

        [HttpGet]
        [Route("Get_FullYr_KeySalesPerformance_RS")]

        public async Task<GenericResult> Get_FullYr_KeySalesPerformance_RS(string Region, string Dealer, string Year)
        {
            return await _reportService.Get_FullYr_KeySalesPerformance_RS(Region, Dealer, Year);
        }

        [HttpGet]
        [Route("Get_FullYr_KeySalesPerformance_WS")]

        public async Task<GenericResult> Get_FullYr_KeySalesPerformance_WS(string Region, string Dealer, string Year)
        {
            return await _reportService.Get_FullYr_KeySalesPerformance_WS(Region, Dealer, Year);
        }

        [HttpGet]
        [Route("Get_FullYr_PartsSalesPerformance_RS")]

        public async Task<GenericResult> Get_FullYr_PartsSalesPerformance_RS(string Region, string Dealer, string Year)
        {
            return await _reportService.Get_FullYr_PartsSalesPerformance_RS(Region, Dealer, Year);
        }

        [HttpGet]
        [Route("Get_FullYr_PartsSalesPerformance_WS")]

        public async Task<GenericResult> Get_FullYr_PartsSalesPerformance_WS(string Region, string Dealer, string Year)
        {
            return await _reportService.Get_FullYr_PartsSalesPerformance_WS(Region, Dealer, Year);
        }

        [HttpGet]
        [Route("Get_FullYr_DealerStock_Amount")]

        public async Task<GenericResult> Get_FullYr_DealerStock_Amount(string Region, string Dealer, string Year)
        {
            return await _reportService.Get_FullYr_DealerStock_Amount(Region, Dealer, Year);
        }

        [HttpGet]
        [Route("Get_FullYr_DealerStock_Qty")]

        public async Task<GenericResult> Get_FullYr_DealerStock_Qty(string Region, string Dealer, string Year)
        {
            return await _reportService.Get_FullYr_DealerStock_Qty(Region, Dealer, Year);
        }

        [HttpGet]
        [Route("Get_ByProduct_RS")]

        public async Task<GenericResult> Get_ByProduct_RS(string Region, string Dealer, string Year, string PartNBR)
        {
            return await _reportService.Get_ByProduct_RS(Region, Dealer, Year, PartNBR);
        }

        [HttpGet]
        [Route("Get_ByProduct_WS")]

        public async Task<GenericResult> Get_ByProduct_WS(string Region, string Dealer, string Year, string PartNBR)
        {
            return await _reportService.Get_ByProduct_WS(Region, Dealer, Year, PartNBR);
        }

        [HttpGet]
        [Route("Get_ByProduct_DLRSTK")]

        public async Task<GenericResult> Get_ByProduct_DLRSTK(string Region, string Dealer, string Year, string PartNBR)
        {
            return await _reportService.Get_ByProduct_DLRSTK(Region, Dealer, Year, PartNBR);
        }

        [HttpGet]
        [Route("Get_ByProductDetails_Sales_QtyRO")]

        public async Task<GenericResult> Get_ByProductDetails_Sales_QtyRO(string Region, string Year, string PartNBR, string ROType)
        {
            return await _reportService.Get_ByProductDetails_Sales_QtyRO(Region, Year, PartNBR, ROType);
        }

        [HttpGet]
        [Route("Get_ByProductDetails_Sales_Qty")]

        public async Task<GenericResult> Get_ByProductDetails_Sales_Qty(string Region, string Year, string PartNBR, string ROType)
        {
            return await _reportService.Get_ByProductDetails_Sales_Qty(Region, Year, PartNBR, ROType);
        }

        [HttpGet]
        [Route("Get_ByProductDetails_Sales_Amount")]

        public async Task<GenericResult> Get_ByProductDetails_Sales_Amount(string Region, string Year, string PartNBR, string ROType)
        {
            return await _reportService.Get_ByProductDetails_Sales_Amount(Region, Year, PartNBR, ROType);
        }

        [HttpGet]
        [Route("Get_StockAnalysis_MOS")]

        public async Task<GenericResult> Get_StockAnalysis_MOS(string Region, string Year, string PartNBR, string PNCCategory)
        {
            return await _reportService.Get_StockAnalysis_MOS(Region, Year, PartNBR, PNCCategory);
        }

        [HttpGet]
        [Route("Get_StockAnalysis_Amount")]

        public async Task<GenericResult> Get_StockAnalysis_Amount(string Region, string Year, string PartNBR, string PNCCategory)
        {
            return await _reportService.Get_StockAnalysis_Amount(Region, Year, PartNBR, PNCCategory);
        }

        [HttpGet]
        [Route("Get_StockAnalysis_Qty")]

        public async Task<GenericResult> Get_StockAnalysis_Qty(string Region, string Year, string PartNBR, string PNCCategory)
        {
            return await _reportService.Get_StockAnalysis_Qty(Region, Year, PartNBR, PNCCategory);
        }

    }
}
