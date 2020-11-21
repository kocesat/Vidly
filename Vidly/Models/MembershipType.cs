using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string Name { get; set; }

        public enum Type
        {
            Unknown = 0,
            PayAsYouGo = 1,
            Monthly = 2,
            Quarterly = 3,
            Yearly = 4
        }
    }
}