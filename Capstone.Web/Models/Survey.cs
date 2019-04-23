using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public string Question1 { get; set; } = "Why do you want to own a business?";
        public string Question2 { get; set; } = "Select a state that you want to operate in:";
        public string Question3 { get; set; } = "In which industry do you have experience?";
        public string Question4 { get; set; } = "What is your Net Worth?";
        public string Question5 { get; set; } = "What size of staff do you want?";
        public string Question6 { get; set; } = "Have you ever owned a business?";
        public string Question7 { get; set; } = "What is your work style?";
        public string Question8 { get; set; } = "What industry are you interested in?";
        public string Question9 { get; set; } = "How do you deal with challenges?";
        public string Question10 { get; set; } = "What is your timeframe for purchasing a franchise?";

        public string Business1 { get; set; }
        public string State2 { get; set; }
        public string Experience3 { get; set; }
        public string NetWorth4 { get; set; }
        public string Staff5 { get; set; }
        public string HaveOwnedBusiness6 { get; set; }
        public string WorkStyle7 { get; set; }
        public string Industry8 { get; set; }
        public string Challenges9 { get; set; }
        public string Timeframe10 { get; set; }

        public List<SelectListItem> Business = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Money", Value="You're looking to make a wise investment and you expect a good return." },
            new SelectListItem() { Text = "Freedom", Value= "You're concerned with work-life balance. You want to manage your business while living the life you want." },
            new SelectListItem() { Text = "To be your own boss", Value= "You're confident in your own ideas and are a born leader." },
            new SelectListItem() { Text = "Satisfaction", Value= "You yearn for the sense of accomplishment that owning your own business will provide." },

        };

        public List<SelectListItem> State = new List<SelectListItem>()
        {
        new SelectListItem() {Text="Alabama", Value="AL"},
        new SelectListItem() { Text="Alaska", Value="AK"},
        new SelectListItem() { Text="Arizona", Value="AZ"},
        new SelectListItem() { Text="Arkansas", Value="AR"},
        new SelectListItem() { Text="California", Value="CA"},
        new SelectListItem() { Text="Colorado", Value="CO"},
        new SelectListItem() { Text="Connecticut", Value="CT"},
        new SelectListItem() { Text="District of Columbia", Value="DC"},
        new SelectListItem() { Text="Delaware", Value="DE"},
        new SelectListItem() { Text="Florida", Value="FL"},
        new SelectListItem() { Text="Georgia", Value="GA"},
        new SelectListItem() { Text="Hawaii", Value="HI"},
        new SelectListItem() { Text="Idaho", Value="ID"},
        new SelectListItem() { Text="Illinois", Value="IL"},
        new SelectListItem() { Text="Indiana", Value="IN"},
        new SelectListItem() { Text="Iowa", Value="IA"},
        new SelectListItem() { Text="Kansas", Value="KS"},
        new SelectListItem() { Text="Kentucky", Value="KY"},
        new SelectListItem() { Text="Louisiana", Value="LA"},
        new SelectListItem() { Text="Maine", Value="ME"},
        new SelectListItem() { Text="Maryland", Value="MD"},
        new SelectListItem() { Text="Massachusetts", Value="MA"},
        new SelectListItem() { Text="Michigan", Value="MI"},
        new SelectListItem() { Text="Minnesota", Value="MN"},
        new SelectListItem() { Text="Mississippi", Value="MS"},
        new SelectListItem() { Text="Missouri", Value="MO"},
        new SelectListItem() { Text="Montana", Value="MT"},
        new SelectListItem() { Text="Nebraska", Value="NE"},
        new SelectListItem() { Text="Nevada", Value="NV"},
        new SelectListItem() { Text="New Hampshire", Value="NH"},
        new SelectListItem() { Text="New Jersey", Value="NJ"},
        new SelectListItem() { Text="New Mexico", Value="NM"},
        new SelectListItem() { Text="New York", Value="NY"},
        new SelectListItem() { Text="North Carolina", Value="NC"},
        new SelectListItem() { Text="North Dakota", Value="ND"},
        new SelectListItem() { Text="Ohio", Value="OH"},
        new SelectListItem() { Text="Oklahoma", Value="OK"},
        new SelectListItem() { Text="Oregon", Value="OR"},
        new SelectListItem() { Text="Pennsylvania", Value="PA"},
        new SelectListItem() { Text="Rhode Island", Value="RI"},
        new SelectListItem() { Text="South Carolina", Value="SC"},
        new SelectListItem() { Text="South Dakota", Value="SD"},
        new SelectListItem() { Text="Tennessee", Value="TN"},
        new SelectListItem() { Text="Texas", Value="TX"},
        new SelectListItem() { Text="Utah", Value="UT"},
        new SelectListItem() { Text="Vermont", Value="VT"},
        new SelectListItem() { Text="Virginia", Value="VA"},
        new SelectListItem() { Text="Washington", Value="WA"},
        new SelectListItem() { Text="West Virginia", Value="WV"},
        new SelectListItem() { Text="Wisconsin", Value="WI"},
        new SelectListItem() { Text="Wyoming", Value="WY"}
        };

        public List<SelectListItem> Experience = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Bar", Value= "You have experience in the high-paced service industry with difficult clientele."  },
            new SelectListItem() { Text = "Pizza", Value= "You've spent time making classic food and you know how to meet expectations." },
            new SelectListItem() { Text = "Coffee", Value= "You know how to make an atmosphere where your customers feel comfortable." },
            new SelectListItem() { Text = "Fast Food", Value= "You have experience in a high-paced service industry." },
            new SelectListItem() { Text = "Dine-In", Value= "You have experience running full-service restaurants." },
            new SelectListItem() { Text = "Dessert", Value="You know about working in specialty areas of food service and understand the importance of details." },

        };

        public List<SelectListItem> NetWorth = new List<SelectListItem>()
        {
            //new SelectListItem() { Text = "Under $100,000", Value="100000" },
            ////new SelectListItem() { Text = "Between $100,000 and $200,000", Value="200000" },
            ////new SelectListItem() { Text = "Between $200,000 and $400,000", Value="400000" },
            ////new SelectListItem() { Text = "Between $400,000 and $800,000", Value="800000" },
            new SelectListItem() { Text = "Between $800,000 and $1,000,000", Value="1000000" },
            new SelectListItem() { Text = "Between $1,000,000 and $1,500,000", Value="1500000" },
            new SelectListItem() { Text = "Between $2,000,000 and $3,000,000", Value="3000000" },
            new SelectListItem() { Text = "Over $3,000,000", Value="200000000" },

        };

        public List<SelectListItem> Staff = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Small (1-5)", Value="Small" },
            new SelectListItem() { Text = "Medium (10-30)", Value="Medium" },
            new SelectListItem() { Text = "Large  (Over 30)", Value="Large" },

        };

        public List<SelectListItem> HaveOwnedBusiness = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Yes", Value="True" },
            new SelectListItem() { Text = "No", Value="False" },
        };

        public List<SelectListItem> WorkStyle = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Logical, analytical, linear, and data-oriented", Value= "You like to make sure you're informed before you make a decsion." },
            new SelectListItem() { Text = "Organized, sequential, planned, and detailed-oriented", Value= "You're not afraid to get in the weeds and really understand and organize your business." },
            new SelectListItem() { Text = "Supportive, expressive, and emotionally oriented", Value= "You lead by intuition and trust your gut." },
            new SelectListItem() { Text = "Big-picture, integrative, and ideation-oriented", Value= "You have the ability to think big and enjoy the creative aspect of owning a business." },

        };

        public List<SelectListItem> Industry = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Bar"},
            new SelectListItem() { Text = "Pizza" },
            new SelectListItem() { Text = "Coffee" },
            new SelectListItem() { Text = "Fast Food"},
            new SelectListItem() { Text = "Dine-In" },
            new SelectListItem() { Text = "Dessert"},
            new SelectListItem() { Text = "Any" },

        };

        public List<SelectListItem> Challenges = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "I face them head-on", Value= "You like to tackle challenges immediately." },
            new SelectListItem() { Text = "I plan before acting", Value= "You like to have all the details before you problem-solve." },
            new SelectListItem() { Text = "I work harder", Value= "You can push and push to get the job done." },
            new SelectListItem() { Text = "I elicit the help of others", Value= "You know that it takes a village and are willing to ask for help." },

        };

        public List<SelectListItem> TimeFrame = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Immediately", Value= "You are prepared and ready to get started on your new career." },
            new SelectListItem() { Text = "One to Three Months", Value= "You will soon be ready to make the plunge and need to start laying the groundwork for a purchase." },
            new SelectListItem() { Text = "Three to Six Months", Value= "You still have some thinking to do, but you are open to new opportunities." },
            new SelectListItem() { Text = "Six Months to a Year", Value= "You're not ready to act now, but you're thinking about the future." },
            new SelectListItem() { Text = "Just looking for now", Value= "You're just looking for now, and that's fine." },

        };






    }
}
