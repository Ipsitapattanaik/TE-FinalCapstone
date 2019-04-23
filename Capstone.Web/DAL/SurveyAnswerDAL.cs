using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveyAnswerDAL
    {
        private string connectionString { get; set; }
        const string SQL_SaveNewSurveyResult = "INSERT INTO surveyResults (userEmail, business, state, experience, netWorth, staff, hasOwnedBusiness, workStyle, industry, challenge, timeFrame) VALUES (@userEmail, @business, @state, @experience, @netWorth, @staff, @hasOwnedBusiness, @workStyle, @industry, @challenge, @timeFrame);";
        const string SQL_UpdateSurveyResult = "UPDATE surveyResults SET business = @business, state = @state, experience = @experience, netWorth = @netWorth, staff = @staff, hasOwnedBusiness = @hasOwnedBusiness, workStyle = @workStyle, industry = @industry, challenge = @challenge, timeFrame = @timeFrame WHERE userEmail = @userEmail;";
        const string SQL_GetSurveyRresult = "SELECT userEmail, business, state, experience, netWorth, staff, hasOwnedBusiness, workStyle, industry, challenge, timeFrame FROM surveyResults WHERE userEmail = @userEmail;";

        public SurveyAnswerDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int SaveNewSurveyResult(SurveyAnswers survey)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(SQL_SaveNewSurveyResult);
                    command.Parameters.AddWithValue("@userEmail", survey.userEmail);
                    command.Parameters.AddWithValue("@business", survey.business);
                    command.Parameters.AddWithValue("@state", survey.state);
                    command.Parameters.AddWithValue("@experience", survey.experience);
                    command.Parameters.AddWithValue("@netWorth", survey.netWorth);
                    command.Parameters.AddWithValue("@staff", survey.staff);
                    command.Parameters.AddWithValue("@hasOwnedBusiness", survey.hasOwnedBusiness);
                    command.Parameters.AddWithValue("@workStyle", survey.workStyle);
                    command.Parameters.AddWithValue("@industry", survey.industry);
                    command.Parameters.AddWithValue("@challenge", survey.challenge);
                    command.Parameters.AddWithValue("@timeFrame", survey.timeFrame);
                    command.Connection = connection;
                    return command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int UpdateSurveyResult(SurveyAnswers survey)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(SQL_UpdateSurveyResult);
                    command.Parameters.AddWithValue("@userEmail", survey.userEmail);
                    command.Parameters.AddWithValue("@business", survey.business);
                    command.Parameters.AddWithValue("@state", survey.state);
                    command.Parameters.AddWithValue("@experience", survey.experience);
                    command.Parameters.AddWithValue("@netWorth", survey.netWorth);
                    command.Parameters.AddWithValue("@staff", survey.staff);
                    command.Parameters.AddWithValue("@hasOwnedBusiness", survey.hasOwnedBusiness);
                    command.Parameters.AddWithValue("@workStyle", survey.workStyle);
                    command.Parameters.AddWithValue("@industry", survey.industry);
                    command.Parameters.AddWithValue("@challenge", survey.challenge);
                    command.Parameters.AddWithValue("@timeFrame", survey.timeFrame);
                    command.Connection = connection;
                    return command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public SurveyAnswers GetSurveyResult(string email)
        {
            string userEmail = email;
            string business = null;
            string state = null;
            string experience = null;
            string netWorth = "0";
            string staff = null;
            string hasOwnedBusiness = "false";
            string workStyle = null;
            string industry = null;
            string challenge = null;
            string timeFrame = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(SQL_GetSurveyRresult);
                    command.Parameters.AddWithValue("@userEmail", userEmail);
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        userEmail = Convert.ToString(reader["userEmail"]);
                        business = Convert.ToString(reader["business"]);
                        state = Convert.ToString(reader["state"]);
                        experience = Convert.ToString(reader["experience"]);
                        netWorth = Convert.ToString(reader["netWorth"]);
                        staff = Convert.ToString(reader["staff"]);
                        hasOwnedBusiness = Convert.ToString(reader["hasOwnedBusiness"]);
                        workStyle = Convert.ToString(reader["workStyle"]);
                        industry = Convert.ToString(reader["industry"]);
                        challenge = Convert.ToString(reader["challenge"]);
                        timeFrame = Convert.ToString(reader["timeFrame"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            var tempAnswer = new SurveyAnswers(userEmail, business, state, experience, netWorth, staff, hasOwnedBusiness, workStyle, industry, challenge, timeFrame);
            return tempAnswer;

        }
    }

}
