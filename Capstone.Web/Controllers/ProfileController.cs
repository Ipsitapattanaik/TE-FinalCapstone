using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Capstone.Web.Providers;

namespace Capstone.Web.Controllers
{
    public class ProfileController : Controller
    {
        private UserSqlDAL userSqlDAL;
        private SurveyAnswerDAL surveyAnswerDAL;
        private FranchiseSqlDAL franchiseSqlDAL;
        private HashProvider hashProvider = new HashProvider();

        public ProfileController(UserSqlDAL userSqlDAL, SurveyAnswerDAL surveyAnswerDAL, FranchiseSqlDAL franchiseSqlDAL)
        {
            this.userSqlDAL = userSqlDAL;
            this.surveyAnswerDAL = surveyAnswerDAL;
            this.franchiseSqlDAL = franchiseSqlDAL;
        }

        [HttpGet]
        public ActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProfile(UserProfile userProfile)
        {
            var checkExists = userSqlDAL.GetUser(userProfile.UserEmail);
            if (checkExists != null)
            {
                return View("CreateProfileUserNameTaken");
            }

            var hashedPasswordAndSalt = hashProvider.HashPassword(userProfile.UserPassword);
            userProfile.UserPassword = hashedPasswordAndSalt.Password;
            userProfile.Salt = hashedPasswordAndSalt.Salt;
            userSqlDAL.CreateUser(userProfile);
            SaveUserSession(userProfile.UserEmail);


            return RedirectToAction("Survey", "Home"); //Jarrod: changed this to redirect to the survey, before it was going to profile and crashing because they hadnt made a profile yet
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult IncorrectLogin()
        {
            //TODO Need to determine how we want to pass information to this view.
            //Temp data?  Session?

            return View();
        }

        /// <summary>
        /// Assigns user email and password from HttpGet to a UserLogin object,
        /// checks the password vs the password returned from the DAL.  selectedButton
        /// represents 1 for the Login button and 2 for the Survey button.
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="selectedButton"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin userLogin, int selectedButton)
        {
            try
            {
                UserProfile userProfile = userSqlDAL.GetUser(userLogin.UserEmail);
                bool passwordMatches = hashProvider.VerifyPasswordMatch(userProfile.UserPassword, userLogin.UserPassword, userProfile.Salt);
                //
                //    // TODO : Add a variable to the parameters to represent whether the user
                //    // is logging in from the TakeSurvey page or from the general login in button.
                //    // RedirectToAction will change depending on the starting point.

                // Jarrod: Right now I've set it so that  once you've loggin in the program checksto see if you have a survey result in th DB
                // If you do, the you are taken to your custom franchise list
                // If you haven't take a survey yet, you are taken to the survey page

                if (passwordMatches)
                {
                    SaveUserSession(userLogin.UserEmail);
                    SurveyAnswers existingSurvey = surveyAnswerDAL.GetSurveyResult(userProfile.UserEmail);

                    if (existingSurvey.business != null)
                    {
                        return RedirectToAction("ViewProfile");
                    }
                    else
                    {
                        return RedirectToAction("Survey", "Home");
                    }
                }
            }
            catch
            {
                return RedirectToAction("IncorrectLogin");
            }
            return RedirectToAction("IncorrectLogin");
        }

        [HttpGet]
     //   [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            EndSession();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ViewProfile() //should this be sending people to a list of their franchises?
        {
            string userEmail = RetrieveUserSession();
            ProfileResults profileResults = new ProfileResults();

            profileResults.surveyAnswer = surveyAnswerDAL.GetSurveyResult(userEmail);

            if(profileResults.surveyAnswer.staff != null)
            {
                profileResults.franchiseList = franchiseSqlDAL.GetFranchiseListFromSurveyResults(profileResults.surveyAnswer);
                return View(profileResults);
            }

            return RedirectToAction("BackToSurvey", "Home");
        }

        public ActionResult EmailConfirmation()
        {
            string userEmail = RetrieveUserSession();
            ProfileResults profileResults = new ProfileResults();

            profileResults.surveyAnswer = surveyAnswerDAL.GetSurveyResult(userEmail);

            if(profileResults.surveyAnswer.staff != null)
            {
                profileResults.franchiseList = franchiseSqlDAL.GetFranchiseListFromSurveyResults(profileResults.surveyAnswer);
                Extensions.SendEmail(userEmail, profileResults);
            }

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

        private void EndSession()
        {

            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //HttpContext.Current.Response.Cache.SetNoServerCaching();
            //HttpContext.Current.Response.Cache.SetNoStore();

            HttpContext.Session.Clear();
            //HttpContext.Session.Remove("user_email");
        }
    }
}
