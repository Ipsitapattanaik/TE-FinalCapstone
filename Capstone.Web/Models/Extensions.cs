using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Capstone.Web.Models
{
    public static class Extensions
    {
        public static void SendEmail(string userEmail, ProfileResults profileResults)
        {
            string results = "";

            foreach(Franchise franchise in profileResults.franchiseList)
            {
                results += franchise.FranchiseName + "\n";
            }

            MailMessage mail = new MailMessage("Marketing.FranchiseFinder@gmail.com", userEmail);
            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.Port = 25;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Host = "smtp.gmail.com";
                mail.Subject = "Your Franchise Finder results!";
                mail.Body = $"Here's what we can tell from your survey:\n\n" +
                    $"{profileResults.surveyAnswer.business}  {profileResults.surveyAnswer.workStyle}  " +
                    $"{profileResults.surveyAnswer.experience}  {profileResults.surveyAnswer.challenge}  " +
                    $"{profileResults.surveyAnswer.timeFrame}\n\n" +
                    $"Check out the businesses below:\n" + results + "\n\nSincerely,\nThe Team at " +
                    "Franchise Finder";
                client.Credentials = new NetworkCredential("Marketing.FranchiseFinder@gmail.com", "franchisefinder8");
                client.EnableSsl = true;
                client.Send(mail);
            }
        }
    }
}
