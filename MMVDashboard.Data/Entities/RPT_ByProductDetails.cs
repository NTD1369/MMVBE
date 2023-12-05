using System;
using System.Collections.Generic;
using System.Text;

namespace MMVDashboard.Data.Entities
{
    public class RPT_ByProductDetails
    {
        public List<dynamic> DetailsChart { get; set; } = new List<dynamic>();
        public List<SaleByProduct_HDR> CurrentYear_HDR { get; set; } = new List<SaleByProduct_HDR>();
        public List<SaleByProduct_HDR> PreviousYear_HDR { get; set; } = new List<SaleByProduct_HDR>();
        public List<SaleByProduct_DTL> CurrentYear_DTL { get; set; } = new List<SaleByProduct_DTL>();
        public List<SaleByProduct_DTL> PreviousYear_DTL { get; set; } = new List<SaleByProduct_DTL>();
    }

    public class SaleByProduct_HDR
    {
        public string Region { get; set; }
        public decimal? Apr { get; set; }
        public decimal? May { get; set; }
        public decimal? Jun { get; set; }
        public decimal? Jul { get; set; }
        public decimal? Aug { get; set; }
        public decimal? Sep { get; set; }
        public decimal? Oct { get; set; }
        public decimal? Nov { get; set; }
        public decimal? Dec { get; set; }
        public decimal? Jan { get; set; }
        public decimal? Feb { get; set; }
        public decimal? Mar { get; set; }
        public decimal? TTL { get; set; }

    }

    public class SaleByProduct_DTL
    {
        public int? No { get; set; }
        public string DealerCode { get; set; }
        public string DealerName { get; set; }
        public decimal? Apr { get; set; }
        public decimal? May { get; set; }
        public decimal? Jun { get; set; }
        public decimal? Jul { get; set; }
        public decimal? Aug { get; set; }
        public decimal? Sep { get; set; }
        public decimal? Oct { get; set; }
        public decimal? Nov { get; set; }
        public decimal? Dec { get; set; }
        public decimal? Jan { get; set; }
        public decimal? Feb { get; set; }
        public decimal? Mar { get; set; }
        public decimal? TTL { get; set; }
    }

}
