using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMVDashboard.Data.Entities
{
    public class MUser
    {
        public string ID_User { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Active { get; set; }
    }
}
