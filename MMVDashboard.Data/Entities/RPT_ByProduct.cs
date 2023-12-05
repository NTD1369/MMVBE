using System;
using System.Collections.Generic;
using System.Text;

namespace MMVDashboard.Data.Entities
{
    public class RPTByProduct
    {
        public List<ByProductDetails> Details { get; set; } = new List<ByProductDetails>();
    }

    public class ByProductDetails
    {
        public string Dscription { get; set; }
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
