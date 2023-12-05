using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMVDashboard.Data.Entities
{
    public class RPTFullYear
    {
        public object DetailsYear { get; set; } = new object();
        public object Header { get; set; } = new object();
        public List<YearDescription> CurrentYear { get; set; } = new List<YearDescription>();
        public List<YearDescription> CurrentYear_1 { get; set; } = new List<YearDescription>();
        public List<YearDescription> CurrentYear_2 { get; set; } = new List<YearDescription>();
    }
    public class YearDescription
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
    public class FllYrDetails
    {
        public string Dscription { get; set; }
        public int? Monthly { get; set; }
        public decimal? Values { get; set; }
    }
}
