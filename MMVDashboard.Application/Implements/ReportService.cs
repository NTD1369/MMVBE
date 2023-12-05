

using AutoMapper;
using Dapper;
using MMVDashboard.Application.Helpers;
using MMVDashboard.Application.Interfaces;
using MMVDashboard.Data.Entities;
using MMVDashboard.Data.Repositories;
using MMVDashboard.Utilities.Dtos;
using MMVDashboard.Utilities.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RMS.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MMVDashboard.Application.Implements
{
    public class ReportService : IReportService
    {
        private readonly IGenericRepository<MUser> _UserRepository;
        private readonly IGenericRepository<Dealer> _DealerRepository;

        private readonly IMapper _mapper;
        public ReportService(IMapper mapper, IGenericRepository<MUser> UserRepository, IGenericRepository<Dealer> DealerRepository ) //: base(hubContext)
        {
            _UserRepository = UserRepository;
            _DealerRepository = DealerRepository;

            _mapper = mapper;

        }

        public Task<GenericResult> Create(MUser model)
        {
            throw new NotImplementedException();
        }

        public async Task<GenericResult> GETFullYear(string CompanyCode)
        {
            GenericResult result = new GenericResult();
            try
            {
                //var parameters = new DynamicParameters();
                //parameters.Add("CompanyCode", companycode);
                //parameters.Add("storeId", storeId);
                //parameters.Add("Status", status);
                //parameters.Add("FrDate", fromdate);
                //parameters.Add("ToDate", todate);
                //parameters.Add("Keyword", key);
                ////parameters.Add("ViewBy", ViewBy); 

                //var data = await _DeliveryHeaderlRepository.GetAllAsync($"USP_GetDelivery", parameters, commandType: CommandType.StoredProcedure);
                if (CompanyCode == "dat")
                {
                    CompanyCode = "A";
                }
                result.Success = true;
                result.Message = CompanyCode;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<GenericResult> GetDealerByRegion(string region)
        {
            GenericResult result = new GenericResult();
            var parameters = new DynamicParameters();
            parameters.Add("region", region);
            try
            {
                var data = await _DealerRepository.GetAllAsync($"USP_S_DealerByRegion", parameters, commandType: CommandType.StoredProcedure);
                //var data = await _ReportRepository.GetAllAsync($"select P.U_Area, C.CardCode, C.CardName, * from OCRD C left join [@PROVINCECODE] P ON C.U_ProvinceCode = P.Code where GroupCode = 104", null, commandType: CommandType.Text);

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

        public async Task<GenericResult> GetKeySalesPerformance(string Region, string Dealer, string Month, string Year, string rptType)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_DealerCodes", Dealer);
                    parameters.Add("@IN_Month", Month);
                    parameters.Add("@IN_Year", Year);
                    parameters.Add("@IN_RptType", rptType);
                    var data = await db.QueryAsync($"sp_rpt_Dashboard_KeySalesPerFormance", parameters, commandType: CommandType.StoredProcedure);
                    //var data = await _ReportRepository.GetAllAsync($"select P.U_Area, C.CardCode, C.CardName, * from OCRD C left join [@PROVINCECODE] P ON C.U_ProvinceCode = P.Code where GroupCode = 104", null, commandType: CommandType.Text);

                    result.Data = data;
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }

        public async Task<GenericResult> GetPartsSalesPerformance(string Region, string Dealer, string Month, string Year, string rptType)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_DealerCodes", Dealer);
                    parameters.Add("@IN_Month", Month);
                    parameters.Add("@IN_Year", Year);
                    parameters.Add("@IN_RptType", rptType);
                    var data = await db.QueryAsync($"sp_rpt_Dashboard_PartsSalesPerFormance", parameters, commandType: CommandType.StoredProcedure);
                    //var data = await _ReportRepository.GetAllAsync($"select P.U_Area, C.CardCode, C.CardName, * from OCRD C left join [@PROVINCECODE] P ON C.U_ProvinceCode = P.Code where GroupCode = 104", null, commandType: CommandType.Text);

                    result.Data = data;
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }

        public async Task<GenericResult> GetDealerStockWSValue(string Region, string Dealer, string Month, string Year, string rptType)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_DealerCodes", Dealer);
                    parameters.Add("@IN_Month", Month);
                    parameters.Add("@IN_Year", Year);
                    parameters.Add("@IN_RptType", rptType);
                    var data = await db.QueryAsync($"sp_rpt_Dashboard_DLRStock_WSValue", parameters, commandType: CommandType.StoredProcedure);
                    //var data = await _ReportRepository.GetAllAsync($"select P.U_Area, C.CardCode, C.CardName, * from OCRD C left join [@PROVINCECODE] P ON C.U_ProvinceCode = P.Code where GroupCode = 104", null, commandType: CommandType.Text);

                    result.Data = data;
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }
        
        public async Task<GenericResult> Get_FullYr_KeySalesPerformance_RS(string Region, string Dealer, string Year)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_DealerCodes", Dealer);
                    parameters.Add("@IN_Year", Year);
                    var reader = await db.QueryMultipleAsync($"sp_rpt_FullYr_KeySalesPerformance_RS", parameters, commandType: CommandType.StoredProcedure);
                    var DetailsYear = reader.Read().ToList();
                    var Header = reader.Read().ToList();
                    var year1 = reader.Read<YearDescription>().ToList();
                    var year2 = reader.Read<YearDescription>().ToList(); 
                    var year3 = reader.Read<YearDescription>().ToList();
                    //var data = await _ReportRepository.GetAllAsync($"select P.U_Area, C.CardCode, C.CardName, * from OCRD C left join [@PROVINCECODE] P ON C.U_ProvinceCode = P.Code where GroupCode = 104", null, commandType: CommandType.Text);
                    RPTFullYear rPTFullYear = new RPTFullYear();
                    rPTFullYear.DetailsYear = DetailsYear;
                    rPTFullYear.Header = Header;
                    rPTFullYear.CurrentYear = year1;
                    rPTFullYear.CurrentYear_1 = year2;
                    rPTFullYear.CurrentYear_2 = year3;
                    result.Data = rPTFullYear;
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }

        public async Task<GenericResult> Get_FullYr_KeySalesPerformance_WS(string Region, string Dealer, string Year)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_DealerCodes", Dealer);
                    parameters.Add("@IN_Year", Year);
                    var reader = await db.QueryMultipleAsync($"sp_rpt_FullYr_KeySalesPerformance_WS", parameters, commandType: CommandType.StoredProcedure);
                    var DetailsYear = reader.Read().ToList();
                    var Header = reader.Read().ToList();
                    var year1 = reader.Read<YearDescription>().ToList();
                    var year2 = reader.Read<YearDescription>().ToList();
                    var year3 = reader.Read<YearDescription>().ToList();
                    RPTFullYear rPTFullYear = new RPTFullYear();
                    rPTFullYear.DetailsYear = DetailsYear;
                    rPTFullYear.Header = Header;
                    rPTFullYear.CurrentYear = year1;
                    rPTFullYear.CurrentYear_1 = year2;
                    rPTFullYear.CurrentYear_2 = year3;
                    result.Data = rPTFullYear;
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }

        public async Task<GenericResult> Get_FullYr_PartsSalesPerformance_RS(string Region, string Dealer, string Year)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_DealerCodes", Dealer);
                    parameters.Add("@IN_Year", Year);
                    var reader = await db.QueryMultipleAsync($"sp_rpt_FullYr_PartsPerformance_RS", parameters, commandType: CommandType.StoredProcedure);
                    var DetailsYear = reader.Read().ToList();
                    var Header = reader.Read().ToList();
                    var year1 = reader.Read<YearDescription>().ToList();
                    var year2 = reader.Read<YearDescription>().ToList();
                    var year3 = reader.Read<YearDescription>().ToList();
                    RPTFullYear rPTFullYear = new RPTFullYear();
                    rPTFullYear.DetailsYear = DetailsYear;
                    rPTFullYear.Header = Header;
                    rPTFullYear.CurrentYear = year1;
                    rPTFullYear.CurrentYear_1 = year2;
                    rPTFullYear.CurrentYear_2 = year3;
                    result.Data = rPTFullYear;
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }

        public async Task<GenericResult> Get_FullYr_PartsSalesPerformance_WS(string Region, string Dealer, string Year)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_DealerCodes", Dealer);
                    parameters.Add("@IN_Year", Year);
                    var reader = await db.QueryMultipleAsync($"sp_rpt_FullYr_PartsPerformance_WS", parameters, commandType: CommandType.StoredProcedure);
                    var DetailsYear = reader.Read().ToList();
                    var Header = reader.Read().ToList();
                    var year1 = reader.Read<YearDescription>().ToList();
                    var year2 = reader.Read<YearDescription>().ToList();
                    var year3 = reader.Read<YearDescription>().ToList();
                    RPTFullYear rPTFullYear = new RPTFullYear();
                    rPTFullYear.DetailsYear = DetailsYear;
                    rPTFullYear.Header = Header;
                    rPTFullYear.CurrentYear = year1;
                    rPTFullYear.CurrentYear_1 = year2;
                    rPTFullYear.CurrentYear_2 = year3;
                    result.Data = rPTFullYear;
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }

        public async Task<GenericResult> Get_FullYr_DealerStock_Amount(string Region, string Dealer, string Year)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_DealerCodes", Dealer);
                    parameters.Add("@IN_Year", Year);
                    var reader = await db.QueryMultipleAsync($"sp_rpt_FullYr_DealerStock_Amount", parameters, commandType: CommandType.StoredProcedure);
                    var DetailsYear = reader.Read().ToList();
                    var Header = reader.Read().ToList();
                    var year1 = reader.Read<YearDescription>().ToList();
                    var year2 = reader.Read<YearDescription>().ToList();
                    var year3 = reader.Read<YearDescription>().ToList();
                    RPTFullYear rPTFullYear = new RPTFullYear();
                    rPTFullYear.DetailsYear = DetailsYear;
                    rPTFullYear.Header = Header;
                    rPTFullYear.CurrentYear = year1;
                    rPTFullYear.CurrentYear_1 = year2;
                    rPTFullYear.CurrentYear_2 = year3;
                    result.Data = rPTFullYear;
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }

        public async Task<GenericResult> Get_FullYr_DealerStock_Qty(string Region, string Dealer, string Year)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_DealerCodes", Dealer);
                    parameters.Add("@IN_Year", Year);
                    var reader = await db.QueryMultipleAsync($"sp_rpt_FullYr_DealerStock_Qty", parameters, commandType: CommandType.StoredProcedure);
                    var DetailsYear = reader.Read().ToList();
                    var Header = reader.Read().ToList();
                    var year1 = reader.Read<YearDescription>().ToList();
                    var year2 = reader.Read<YearDescription>().ToList();
                    var year3 = reader.Read<YearDescription>().ToList();
                    RPTFullYear rPTFullYear = new RPTFullYear();
                    rPTFullYear.DetailsYear = DetailsYear;
                    rPTFullYear.Header = Header;
                    rPTFullYear.CurrentYear = year1;
                    rPTFullYear.CurrentYear_1 = year2;
                    rPTFullYear.CurrentYear_2 = year3;
                    result.Data = rPTFullYear;
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }

        public async Task<GenericResult> Get_ByProduct_RS(string Region, string Dealer, string Year, string PartNBR)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_DealerCodes", Dealer);
                    parameters.Add("@IN_Year", Year);
                    parameters.Add("@IN_PartNBR", PartNBR);
                    var reader = await db.QueryMultipleAsync($"sp_rpt_ByProduct_RS", parameters, commandType: CommandType.StoredProcedure);                   
                    var details = reader.Read<ByProductDetails>().ToList();
                    RPTByProduct rPTByProduct = new RPTByProduct();
                    rPTByProduct.Details = details;                    
                    result.Data = rPTByProduct;
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open) { db.Close(); }
                }
            }
            return result;
        }

        public async Task<GenericResult> Get_ByProduct_WS(string Region, string Dealer, string Year, string PartNBR)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_DealerCodes", Dealer);
                    parameters.Add("@IN_Year", Year);
                    parameters.Add("@IN_PartNBR", PartNBR);
                    var reader = await db.QueryMultipleAsync($"sp_rpt_ByProduct_WS", parameters, commandType: CommandType.StoredProcedure);
                    var details = reader.Read<ByProductDetails>().ToList();
                    RPTByProduct rPTByProduct = new RPTByProduct();
                    rPTByProduct.Details = details;
                    result.Data = rPTByProduct;
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open) { db.Close(); }
                }
            }
            return result;
        }

        public async Task<GenericResult> Get_ByProduct_DLRSTK(string Region, string Dealer, string Year, string PartNBR)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_DealerCodes", Dealer);
                    parameters.Add("@IN_Year", Year);
                    parameters.Add("@IN_PartNBR", PartNBR);
                    var reader = await db.QueryMultipleAsync($"sp_rpt_ByProduct_DLRSTK", parameters, commandType: CommandType.StoredProcedure);
                    var details = reader.Read<ByProductDetails>().ToList();
                    RPTByProduct rPTByProduct = new RPTByProduct();
                    rPTByProduct.Details = details;
                    result.Data = rPTByProduct;
                    result.Success = true;
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open) { db.Close(); }
                }
            }
            return result;
        }

        public async Task<GenericResult> Get_ByProductDetails_Sales_QtyRO(string Region, string Year, string PartNBR, string ROType)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    //Region = "NOR"; Year = "2020"; PartNBR = "MZ100721EX"; ROType = "SIU";
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_Year", Year);
                    parameters.Add("@PartNBR", PartNBR);
                    parameters.Add("@NBRofROType", ROType);
                    // 
                    var reader = await db.QueryMultipleAsync($"sp_rpt_ByProductDetails_SaleQtyRO", parameters, commandType: CommandType.StoredProcedure);
                    // Data for chart
                    var DetailsChart = reader.Read().ToDataTable();
                    var DetailsChart1 = reader.Read().ToDataTable();
                    var dtDtlChart = MergeTable(DetailsChart, DetailsChart1, Year); // Merge two tables
                    //
                    // Convert datatable to list models
                    List<dynamic> models = new List<dynamic>();
                    foreach(DataRow row in dtDtlChart.Rows)
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        foreach(DataColumn col in dtDtlChart.Columns) {
                            if(col.ColumnName=="Monthly")
                            {
                                dic.Add(col.ColumnName, row[col.ColumnName]);
                            }   
                            else
                            {
                                dic.Add(col.ColumnName, decimal.Parse(row[col.ColumnName].ToString()));
                            }    
                        }
                        models.Add(dic);
                    }
                    // 
                    // Data for table Header & Details
                    var currentHDR = reader.Read<SaleByProduct_HDR>().ToList();
                    var PreviousHDR = reader.Read<SaleByProduct_HDR>().ToList();
                    var currentDTL = reader.Read<SaleByProduct_DTL>().ToList();
                    var PreviousDTL = reader.Read<SaleByProduct_DTL>().ToList();
                    //
                    // var resultDB = JsonConvert.DeserializeObject(dtDtlChart.ToString());
                    // var json = JsonConvert.SerializeObject(dtDtlChart);
                    //
                    RPT_ByProductDetails rPTByProdDtl = new RPT_ByProductDetails();
                    rPTByProdDtl.DetailsChart = models;
                    rPTByProdDtl.CurrentYear_HDR = currentHDR;
                    rPTByProdDtl.PreviousYear_HDR = PreviousHDR;
                    rPTByProdDtl.CurrentYear_DTL = currentDTL;
                    rPTByProdDtl.PreviousYear_DTL = PreviousDTL;
                    result.Data = rPTByProdDtl;
                    result.Success = true;

                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }

        public async Task<GenericResult> Get_ByProductDetails_Sales_Qty(string Region, string Year, string PartNBR, string ROType)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_Year", Year);
                    parameters.Add("@PartNBR", PartNBR);
                    parameters.Add("@NBRofROType", ROType);
                    // 
                    var reader = await db.QueryMultipleAsync($"sp_rpt_ByProductDetails_SaleQty", parameters, commandType: CommandType.StoredProcedure);
                    // Data for chart
                    var DetailsChart = reader.Read().ToDataTable();
                    var DetailsChart1 = reader.Read().ToDataTable();
                    DataTable dtDtlChart = MergeTable(DetailsChart, DetailsChart1, Year);
                    //
                    // Convert datatable to list models
                    List<dynamic> models = new List<dynamic>();
                    foreach (DataRow row in dtDtlChart.Rows)
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        foreach (DataColumn col in dtDtlChart.Columns)
                        {
                            if (col.ColumnName == "Monthly")
                            {
                                dic.Add(col.ColumnName, row[col.ColumnName]);
                            }
                            else
                            {
                                dic.Add(col.ColumnName, decimal.Parse(row[col.ColumnName].ToString()));
                            }
                        }
                        models.Add(dic);
                    }
                    //
                    // Data for table Header & Details
                    var currentHDR = reader.Read<SaleByProduct_HDR>().ToList();
                    var PreviousHDR = reader.Read<SaleByProduct_HDR>().ToList();
                    var currentDTL = reader.Read<SaleByProduct_DTL>().ToList();
                    var PreviousDTL = reader.Read<SaleByProduct_DTL>().ToList();

                    RPT_ByProductDetails rPTByProdDtl = new RPT_ByProductDetails();
                    rPTByProdDtl.DetailsChart = models;
                    rPTByProdDtl.CurrentYear_HDR = currentHDR;
                    rPTByProdDtl.PreviousYear_HDR = PreviousHDR;
                    rPTByProdDtl.CurrentYear_DTL = currentDTL;
                    rPTByProdDtl.PreviousYear_DTL = PreviousDTL;
                    result.Data = rPTByProdDtl;
                    result.Success = true;

                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }

        public async Task<GenericResult> Get_ByProductDetails_Sales_Amount(string Region, string Year, string PartNBR, string ROType)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_Year", Year);
                    parameters.Add("@PartNBR", PartNBR);
                    parameters.Add("@NBRofROType", ROType);
                    // 
                    var reader = await db.QueryMultipleAsync($"sp_rpt_ByProductDetails_SaleAmnt", parameters, commandType: CommandType.StoredProcedure);
                    // Data for chart
                    var DetailsChart = reader.Read().ToDataTable();
                    var DetailsChart1 = reader.Read().ToDataTable();
                    DataTable dtDtlChart = MergeTable(DetailsChart, DetailsChart1, Year);
                    //
                    // Convert datatable to list models
                    List<dynamic> models = new List<dynamic>();
                    foreach (DataRow row in dtDtlChart.Rows)
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        foreach (DataColumn col in dtDtlChart.Columns)
                        {
                            if (col.ColumnName == "Monthly")
                            {
                                dic.Add(col.ColumnName, row[col.ColumnName]);
                            }
                            else
                            {
                                dic.Add(col.ColumnName, decimal.Parse(row[col.ColumnName].ToString()));
                            }
                        }
                        models.Add(dic);
                    }
                    //

                    // Data for table Header & Details
                    var currentHDR = reader.Read<SaleByProduct_HDR>().ToList();
                    var PreviousHDR = reader.Read<SaleByProduct_HDR>().ToList();
                    var currentDTL = reader.Read<SaleByProduct_DTL>().ToList();
                    var PreviousDTL = reader.Read<SaleByProduct_DTL>().ToList();

                    RPT_ByProductDetails rPTByProdDtl = new RPT_ByProductDetails();
                    rPTByProdDtl.DetailsChart = models;
                    rPTByProdDtl.CurrentYear_HDR = currentHDR;
                    rPTByProdDtl.PreviousYear_HDR = PreviousHDR;
                    rPTByProdDtl.CurrentYear_DTL = currentDTL;
                    rPTByProdDtl.PreviousYear_DTL = PreviousDTL;
                    result.Data = rPTByProdDtl;
                    result.Success = true;

                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }

        public async Task<GenericResult> Get_StockAnalysis_MOS(string Region, string Year, string PartNBR, string PNCCategory)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_Year", Year);
                    parameters.Add("@PartNBR", PartNBR);
                    parameters.Add("@PNCCategory", PNCCategory);
                    // 
                    var reader = await db.QueryMultipleAsync($"sp_rpt_StockAnalysis_MOS", parameters, commandType: CommandType.StoredProcedure);
                    // Data for chart
                    var DetailsChart = reader.Read().ToDataTable();
                    var DetailsChart1 = reader.Read().ToDataTable();
                    DataTable dtDtlChart = MergeTable(DetailsChart, DetailsChart1, Year);
                    //
                    // Convert datatable to list models
                    List<dynamic> models = new List<dynamic>();
                    foreach (DataRow row in dtDtlChart.Rows)
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        foreach (DataColumn col in dtDtlChart.Columns)
                        {
                            if (col.ColumnName == "Monthly")
                            {
                                dic.Add(col.ColumnName, row[col.ColumnName]);
                            }
                            else
                            {
                                dic.Add(col.ColumnName, decimal.Parse(row[col.ColumnName].ToString()));
                            }
                        }
                        models.Add(dic);
                    }
                    //

                    // Data for table Header & Details
                    var currentHDR = reader.Read<SaleByProduct_HDR>().ToList();
                    var PreviousHDR = reader.Read<SaleByProduct_HDR>().ToList();
                    var currentDTL = reader.Read<SaleByProduct_DTL>().ToList();
                    var PreviousDTL = reader.Read<SaleByProduct_DTL>().ToList();

                    RPT_ByProductDetails rPTByProdDtl = new RPT_ByProductDetails();
                    rPTByProdDtl.DetailsChart = models;
                    rPTByProdDtl.CurrentYear_HDR = currentHDR;
                    rPTByProdDtl.PreviousYear_HDR = PreviousHDR;
                    rPTByProdDtl.CurrentYear_DTL = currentDTL;
                    rPTByProdDtl.PreviousYear_DTL = PreviousDTL;
                    result.Data = rPTByProdDtl;
                    result.Success = true;

                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }

        public async Task<GenericResult> Get_StockAnalysis_Amount(string Region, string Year, string PartNBR, string PNCCategory)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_Year", Year);
                    parameters.Add("@PartNBR", PartNBR);
                    parameters.Add("@PNCCategory", PNCCategory);
                    // 
                    var reader = await db.QueryMultipleAsync($"sp_rpt_StockAnalysis_Amount", parameters, commandType: CommandType.StoredProcedure);
                    // Data for chart
                    var DetailsChart = reader.Read().ToDataTable();
                    var DetailsChart1 = reader.Read().ToDataTable();
                    DataTable dtDtlChart = MergeTable(DetailsChart, DetailsChart1, Year);
                    //
                    // Convert datatable to list models
                    List<dynamic> models = new List<dynamic>();
                    foreach (DataRow row in dtDtlChart.Rows)
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        foreach (DataColumn col in dtDtlChart.Columns)
                        {
                            if (col.ColumnName == "Monthly")
                            {
                                dic.Add(col.ColumnName, row[col.ColumnName]);
                            }
                            else
                            {
                                dic.Add(col.ColumnName, decimal.Parse(row[col.ColumnName].ToString()));
                            }
                        }
                        models.Add(dic);
                    }
                    //

                    // Data for table Header & Details
                    var currentHDR = reader.Read<SaleByProduct_HDR>().ToList();
                    var PreviousHDR = reader.Read<SaleByProduct_HDR>().ToList();
                    var currentDTL = reader.Read<SaleByProduct_DTL>().ToList();
                    var PreviousDTL = reader.Read<SaleByProduct_DTL>().ToList();

                    RPT_ByProductDetails rPTByProdDtl = new RPT_ByProductDetails();
                    rPTByProdDtl.DetailsChart = models;
                    rPTByProdDtl.CurrentYear_HDR = currentHDR;
                    rPTByProdDtl.PreviousYear_HDR = PreviousHDR;
                    rPTByProdDtl.CurrentYear_DTL = currentDTL;
                    rPTByProdDtl.PreviousYear_DTL = PreviousDTL;
                    result.Data = rPTByProdDtl;
                    result.Success = true;

                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }

        public async Task<GenericResult> Get_StockAnalysis_Qty(string Region, string Year, string PartNBR, string PNCCategory)
        {
            GenericResult result = new GenericResult();
            using (IDbConnection db = _DealerRepository.GetConnection())
            {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@IN_Region", Region);
                    parameters.Add("@IN_Year", Year);
                    parameters.Add("@PartNBR", PartNBR);
                    parameters.Add("@PNCCategory", PNCCategory);
                    // 
                    var reader = await db.QueryMultipleAsync($"sp_rpt_StockAnalysis_Quantity", parameters, commandType: CommandType.StoredProcedure);
                    // Data for chart
                    var DetailsChart = reader.Read().ToDataTable();
                    var DetailsChart1 = reader.Read().ToDataTable();
                    DataTable dtDtlChart = MergeTable(DetailsChart, DetailsChart1, Year);
                    //
                    // Convert datatable to list models
                    List<dynamic> models = new List<dynamic>();
                    foreach (DataRow row in dtDtlChart.Rows)
                    {
                        Dictionary<string, object> dic = new Dictionary<string, object>();
                        foreach (DataColumn col in dtDtlChart.Columns)
                        {
                            if (col.ColumnName == "Monthly")
                            {
                                dic.Add(col.ColumnName, row[col.ColumnName]);
                            }
                            else
                            {
                                dic.Add(col.ColumnName, decimal.Parse(row[col.ColumnName].ToString()));
                            }
                        }
                        models.Add(dic);
                    }
                    //
                    // Data for table Header & Details
                    var currentHDR = reader.Read<SaleByProduct_HDR>().ToList();
                    var PreviousHDR = reader.Read<SaleByProduct_HDR>().ToList();
                    var currentDTL = reader.Read<SaleByProduct_DTL>().ToList();
                    var PreviousDTL = reader.Read<SaleByProduct_DTL>().ToList();

                    RPT_ByProductDetails rPTByProdDtl = new RPT_ByProductDetails();
                    rPTByProdDtl.DetailsChart = models;
                    rPTByProdDtl.CurrentYear_HDR = currentHDR;
                    rPTByProdDtl.PreviousYear_HDR = PreviousHDR;
                    rPTByProdDtl.CurrentYear_DTL = currentDTL;
                    rPTByProdDtl.PreviousYear_DTL = PreviousDTL;
                    result.Data = rPTByProdDtl;
                    result.Success = true;

                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = ex.Message;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }
            }
            return result;
        }

        private DataTable MergeTable(DataTable dt1, DataTable dt2, string Year)
        {
            // Edit column names
            foreach (DataColumn col in dt1.Columns)
            {
                if (!col.ColumnName.Equals("Monthly"))
                {
                    col.ColumnName = col.ColumnName + " " + Year;
                }
            }

            foreach (DataColumn col in dt2.Columns)
            {
                if (!col.ColumnName.Equals("Monthly"))
                {
                    col.ColumnName = col.ColumnName + " " + (int.Parse(Year) - 1).ToString();
                }
            }

            // Merge data two tables
            for (int m = 0; m < dt2.Rows.Count; m++)
            {
                foreach (DataColumn c in dt2.Columns)
                {
                    if (!dt1.Columns.Contains(c.ColumnName))
                        dt1.Columns.Add(c.ColumnName);

                    dt1.Rows[m][c.ColumnName] = dt2.Rows[m][c.ColumnName].ToString();
                }
            }

            // Sort by fiscal year
            dt1.Columns.Add("Sort", typeof(int));
            foreach(DataRow r in dt1.Rows)
            {
                switch (r["Monthly"].ToString())
                {
                    case "Apr":
                        r["Sort"] = 1;
                        break;
                    case "May":
                        r["Sort"] = 2;
                        break;
                    case "Jun":
                        r["Sort"] = 3;
                        break;
                    case "Jul":
                        r["Sort"] = 4;
                        break;
                    case "Aug":
                        r["Sort"] = 5;
                        break;
                    case "Sep":
                        r["Sort"] = 6;
                        break;
                    case "Oct":
                        r["Sort"] = 7;
                        break;
                    case "Nov":
                        r["Sort"] = 8;
                        break;
                    case "Dec":
                        r["Sort"] = 9;
                        break;
                    case "Jan":
                        r["Sort"] = 10;
                        break;
                    case "Feb":
                        r["Sort"] = 11;
                        break;
                    case "Mar":
                        r["Sort"] = 12;
                        break;
                    case "TTL":
                        r["Sort"] = 13;
                        break;
                }
            }

            DataView dv = dt1.DefaultView;
            dv.Sort = "Sort ASC";
            DataTable dtReturn = dv.ToTable();
            dtReturn.Columns.Remove("Sort");

            DataTable dtResult = new DataTable();
            foreach(DataColumn col in dtReturn.Columns)
            {
                if (col.ColumnName.Equals("Monthly"))
                {
                    dtResult.Columns.Add(col.ColumnName);
                }
                else
                {
                    dtResult.Columns.Add(col.ColumnName, typeof(string));
                }
            }

            foreach(DataRow row in dtReturn.Rows)
            {
                dtResult.Rows.Add(row.ItemArray);
            }

            return dtResult;
        }

        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

    }
}
