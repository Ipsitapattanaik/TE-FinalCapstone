using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Franchise
    {
        public int FranchiseId { get; set; }
        public string FranchiseName { get; set; }
        public string YelpTerm { get; set; }
        public bool FirstTimeFriendly { get; set; }
        public string StaffSize { get; set; }
        public string Category { get; set; }
        public int NetWorth { get; set; }
        public int FranchiseFee { get; set; }
        public int TotalInvestment { get; set; }
        public int RoyaltyFee { get; set; }
        public int AdvertisingFee { get; set; }
        public string Heading { get; set; }
        public string FranchiseDescription {get; set;}
        public string LogoURL { get; set; }
        public string PicURL { get; set; }

      public SurveyAnswers surveyAnswers { get; set; }
    }
}
