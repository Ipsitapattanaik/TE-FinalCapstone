using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyAnswers
    {
        public string userEmail { get; set; }
        public string business { get; set; }
        public string state { get; set; }
        public string experience { get; set; }
        public string netWorth { get; set; }
        public string staff { get; set; }
        public string hasOwnedBusiness { get; set; }
        public string workStyle { get; set; }
        public string industry { get; set; }
        public string challenge { get; set; }
        public string timeFrame { get; set; }

        public SurveyAnswers(string userEmail, string business, string state, string experience, string netWorth, string staff, string hasOwnedBusiness, string workStyle, string industry, string challenge, string timeFrame)
        {
            this.userEmail = userEmail;
            this.business = business;
            this.state = state;
            this.experience = experience;
            this.netWorth = netWorth;
            this.staff = staff;
            this.hasOwnedBusiness = hasOwnedBusiness;
            this.workStyle = workStyle;
            this.industry = industry;
            this.challenge = challenge;
            this.timeFrame = timeFrame;
        }
    }
}