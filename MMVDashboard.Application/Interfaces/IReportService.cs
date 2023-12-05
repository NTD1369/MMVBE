
using MMVDashboard.Application.Helpers;
using MMVDashboard.Data.Entities;
using MMVDashboard.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMVDashboard.Application.Interfaces
{
    public interface IReportService
    {
        Task<GenericResult> GetDealerByRegion(string region); 
        Task<GenericResult> GETFullYear(string CompanyCode ); 
        Task<GenericResult> GetKeySalesPerformance(string Region, string Dealer, string Month, string Year, string rptType);
        Task<GenericResult> GetPartsSalesPerformance(string Region, string Dealer, string Month, string Year, string rptType);
        Task<GenericResult> GetDealerStockWSValue(string Region, string Dealer, string Month, string Year, string rptType); 

        Task<GenericResult> Get_FullYr_KeySalesPerformance_RS(string Region, string Dealer, string Year);
        Task<GenericResult> Get_FullYr_KeySalesPerformance_WS(string Region, string Dealer, string Year);

        Task<GenericResult> Get_FullYr_PartsSalesPerformance_RS(string Region, string Dealer, string Year);

        Task<GenericResult> Get_FullYr_PartsSalesPerformance_WS(string Region, string Dealer, string Year);

        Task<GenericResult> Get_FullYr_DealerStock_Amount(string Region, string Dealer, string Year);

        Task<GenericResult> Get_FullYr_DealerStock_Qty(string Region, string Dealer, string Year);

        Task<GenericResult> Get_ByProduct_RS(string Region, string Dealer, string Year, string PartNBR);

        Task<GenericResult> Get_ByProduct_WS(string Region, string Dealer, string Year, string PartNBR);

        Task<GenericResult> Get_ByProduct_DLRSTK(string Region, string Dealer, string Year, string PartNBR);
        Task<GenericResult> Get_ByProductDetails_Sales_QtyRO(string Region, string Year, string PartNBR, string ROType);
        Task<GenericResult> Get_ByProductDetails_Sales_Qty(string Region, string Year, string PartNBR, string ROType);
        Task<GenericResult> Get_ByProductDetails_Sales_Amount(string Region, string Year, string PartNBR, string ROType);
        Task<GenericResult> Get_StockAnalysis_MOS(string Region, string Year, string PartNBR, string PNCCategory);
        Task<GenericResult> Get_StockAnalysis_Amount(string Region, string Year, string PartNBR, string PNCCategory);
        Task<GenericResult> Get_StockAnalysis_Qty(string Region, string Year, string PartNBR, string PNCCategory);

    }
}
