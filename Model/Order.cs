using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBApi.Model
{
    public class Order
    {
        public int ORD_NUM { get; set; }
        public double ORD_AMOUNT { get; set; }
        public double ADVANCE_AMOUNT { get; set; }
        public DateTime ORD_DATE { get; set; }
        public string CUST_CODE { get; set; }
        public string AGENT_CODE { get; set; }
        public string ORD_DESCRIPTION { get; set; }
    }
}
