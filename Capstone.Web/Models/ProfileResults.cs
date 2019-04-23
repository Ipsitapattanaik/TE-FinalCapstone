using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ProfileResults
    {
      public SurveyAnswers surveyAnswer { get; set; }
      public List<Franchise> franchiseList { get; set; }

    }
}
