using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private FranchiseSqlDAL franchiseSqlDAL;
        private UserSqlDAL userProfileSqlDAL;
        private SurveyAnswerDAL surveyAnswerDAL;

        private int _TotalFranchises = 25;

        public HomeController(FranchiseSqlDAL franchiseSqlDAL, UserSqlDAL userProfileSqlDAL, SurveyAnswerDAL surveyAnswerDAL)
        {
            this.franchiseSqlDAL = franchiseSqlDAL;
            this.userProfileSqlDAL = userProfileSqlDAL;
            this.surveyAnswerDAL = surveyAnswerDAL;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<int> randomFranchises = GetThreeNumbers();

            List<Franchise> franchises = franchiseSqlDAL.GetThreeFranchises(randomFranchises);

            return View(franchises);
        }

        [HttpGet]
        public ActionResult Survey()
        {
            string userEmail = HttpContext.Session.GetString("user_email");

            if (userEmail == null)
            {
                return RedirectToAction("LogIn", "Profile");
            }

            Survey survey = new Survey();

            return View(survey);
        }

        [HttpPost]
        public ActionResult Survey(Survey survey)
        {
            //    // TODO Should we move RetrieveUserSession and SaveUserSession to a helper class?
            //    // Otherwise, code is redundant
            UserProfile userProfile = userProfileSqlDAL.GetUser(RetrieveUserSession());
            SurveyAnswers surveyAnswers = new SurveyAnswers(userProfile.UserEmail, survey.Business1, survey.State2, survey.Experience3, survey.NetWorth4, survey.Staff5, survey.HaveOwnedBusiness6, survey.WorkStyle7, survey.Industry8, survey.Challenges9, survey.Timeframe10);

            var testIfInDb = surveyAnswerDAL.GetSurveyResult(surveyAnswers.userEmail);
            
            if (testIfInDb.experience == null)
            {
                surveyAnswerDAL.SaveNewSurveyResult(surveyAnswers);
            }
            else
            {
                surveyAnswerDAL.UpdateSurveyResult(surveyAnswers);
            }

            return RedirectToAction("ViewProfile", "Profile", userProfile);
        }

        [HttpGet]
        public ActionResult BackToSurvey()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SearchFranchise()
        {
            List<Franchise> franchises = franchiseSqlDAL.GetAllFranchises();

            return View(franchises);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchFranchise(int franchiseId)
        {
            Franchise franchise = franchiseSqlDAL.GetFranchiseById(franchiseId);

            return View(franchise);
        }

        [HttpGet]
        public ActionResult Franchise(int id)
        {
            Franchise franchise = franchiseSqlDAL.GetFranchiseById(id);

            return View(franchise);
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }
        [HttpGet]
        public ActionResult BoringAbout()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        private void SaveUserSession(string userEmail)
        {
            HttpContext.Session.SetString("user_email", userEmail);
        }

        private string RetrieveUserSession()
        {
            return HttpContext.Session.GetString("user_email");
        }

        private List<int> GetThreeNumbers()
        {
            int counter = 1;
            List<int> result = new List<int>();

            Random random = new Random();

            do
            {
                int newNumber = random.Next(1, _TotalFranchises);

                if (!result.Contains(newNumber))
                {
                    result.Add(newNumber);
                    counter++;
                }
            } while (counter <= 3);

            return result;
        }
    }
}