using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class FranchiseSqlDAL
    {
        private string connectionString;

        private string SQL_GetAllFranchises = "select * from franchises;";
        private string SQL_GetFranchiseById = "select * from franchises where franchiseId = @id;";
        private string SQL_GetFranchiseListFromSurveyResultsNewToBusiness = "SELECT * FROM franchises f JOIN franchiseStates fs ON f.franchiseId = fs.franchiseId WHERE f.netWorth <= @NetWorth AND f.category = @industry AND fs.stateAbbreviation = @state AND f.firstTimeFriendly = 'True';";
        private string SQL_GetFranchiseListFromSurveyResultsNewToBusinessNoIndustryPreference = "SELECT * FROM franchises f JOIN franchiseStates fs ON f.franchiseId = fs.franchiseId WHERE f.netWorth <= @NetWorth AND fs.stateAbbreviation = @state AND f.firstTimeFriendly = 'True';";
        private string SQL_GetFranchiseListFromSurveyResultsExperiencedInBusiness = "SELECT * FROM franchises f JOIN franchiseStates fs ON f.franchiseId = fs.franchiseId WHERE f.netWorth <= @NetWorth AND f.category = @industry AND fs.stateAbbreviation = @state;";
        private string SQL_GetFranchiseListFromSurveyResultsExperiencedInBusinessNoIndustryPreference = "SELECT * FROM franchises f JOIN franchiseStates fs ON f.franchiseId = fs.franchiseId WHERE f.netWorth <= @NetWorth AND fs.stateAbbreviation = @state;";

        public FranchiseSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// This method gets a list of franchises filtered by the user's survey results
        /// </summary>
        /// <param name="surveyAnswers"></param>
        /// <returns> List of franchises </returns>
        public List<Franchise> GetFranchiseListFromSurveyResults(SurveyAnswers surveyAnswers)
        {
            List<Franchise> returnList = new List<Franchise>();
            string queryText = "";

            if (surveyAnswers.hasOwnedBusiness == "True" && surveyAnswers.industry == "Any")
            {
                queryText = SQL_GetFranchiseListFromSurveyResultsExperiencedInBusinessNoIndustryPreference;
            } 
            else if (surveyAnswers.hasOwnedBusiness == "True")
            {
                queryText = SQL_GetFranchiseListFromSurveyResultsExperiencedInBusiness;
            }
            else if (surveyAnswers.hasOwnedBusiness == "False" && surveyAnswers.industry == "Any")
            {
                queryText = SQL_GetFranchiseListFromSurveyResultsNewToBusinessNoIndustryPreference;
            }
            else
            {
                queryText = SQL_GetFranchiseListFromSurveyResultsNewToBusiness;
            }

            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand(queryText);
                    command.Parameters.AddWithValue("@NetWorth", surveyAnswers.netWorth);
                    //command.Parameters.AddWithValue("@staff", surveyAnswers.staff);
                    command.Parameters.AddWithValue("@industry", surveyAnswers.industry);
                    command.Parameters.AddWithValue("@state", surveyAnswers.state);
                    command.Connection = connection;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Franchise franchise = new Franchise();

                        franchise.FranchiseId = Convert.ToInt32(reader["franchiseId"]);
                        franchise.FranchiseName = Convert.ToString(reader["franchiseName"]);
                        franchise.YelpTerm = Convert.ToString(reader["yelpTerm"]);
                        franchise.FirstTimeFriendly = Convert.ToBoolean(reader["firstTimeFriendly"]);
                        franchise.StaffSize = Convert.ToString(reader["staffSize"]);
                        franchise.Category = Convert.ToString(reader["category"]);
                        franchise.NetWorth = Convert.ToInt32(reader["netWorth"]);
                        franchise.FranchiseFee = Convert.ToInt32(reader["franchiseFee"]);
                        franchise.TotalInvestment = Convert.ToInt32(reader["totalInvestment"]);
                        franchise.RoyaltyFee = Convert.ToInt32(reader["royaltyFee"]);
                        franchise.AdvertisingFee = Convert.ToInt32(reader["advertisingFee"]);
                        franchise.Heading = Convert.ToString(reader["heading"]);
                        franchise.FranchiseDescription = Convert.ToString(reader["franchiseDescription"]);
                        franchise.LogoURL = Convert.ToString(reader["logoUrl"]);
                        franchise.PicURL = Convert.ToString(reader["picUrl"]);

                        returnList.Add(franchise);
                    }
                    

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return returnList;
        }

        public List<Franchise> GetThreeFranchises(List<int> randomFranchises)
        {

            List<Franchise> franchises = new List<Franchise>();

            try
            {
                foreach (int number in randomFranchises)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        connection.Open();

                        SqlCommand cmd = new SqlCommand(SQL_GetFranchiseById, connection);
                        cmd.Parameters.AddWithValue("id", number);

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            Franchise franchise = new Franchise();

                            franchise.FranchiseId = Convert.ToInt32(reader["franchiseId"]);
                            franchise.FranchiseName = Convert.ToString(reader["franchiseName"]);
                            franchise.YelpTerm = Convert.ToString(reader["yelpTerm"]);
                            franchise.FirstTimeFriendly = Convert.ToBoolean(reader["firstTimeFriendly"]);
                            franchise.StaffSize = Convert.ToString(reader["staffSize"]);
                            franchise.Category = Convert.ToString(reader["category"]);
                            franchise.NetWorth = Convert.ToInt32(reader["netWorth"]);
                            franchise.FranchiseFee = Convert.ToInt32(reader["franchiseFee"]);
                            franchise.TotalInvestment = Convert.ToInt32(reader["totalInvestment"]);
                            franchise.RoyaltyFee = Convert.ToInt32(reader["royaltyFee"]);
                            franchise.AdvertisingFee = Convert.ToInt32(reader["advertisingFee"]);
                            franchise.Heading = Convert.ToString(reader["heading"]);
                            franchise.FranchiseDescription = Convert.ToString(reader["franchiseDescription"]);
                            franchise.LogoURL = Convert.ToString(reader["logoUrl"]);
                            franchise.PicURL = Convert.ToString(reader["picUrl"]);

                            franchises.Add(franchise);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return franchises;
        }

        //TODO Can we consolidate GetThreeFranchises and GetAllFranchises by passing
        // an int or other variable?
        public List<Franchise> GetAllFranchises()
        {
            List<Franchise> franchises = new List<Franchise>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAllFranchises, connection);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Franchise franchise = new Franchise();

                        franchise.FranchiseId = Convert.ToInt32(reader["franchiseId"]);
                        franchise.FranchiseName = Convert.ToString(reader["franchiseName"]);
                        franchise.YelpTerm = Convert.ToString(reader["yelpTerm"]);
                        franchise.FirstTimeFriendly = Convert.ToBoolean(reader["firstTimeFriendly"]);
                        franchise.StaffSize = Convert.ToString(reader["staffSize"]);
                        franchise.Category = Convert.ToString(reader["category"]);
                        franchise.NetWorth = Convert.ToInt32(reader["netWorth"]);
                        franchise.FranchiseFee = Convert.ToInt32(reader["franchiseFee"]);
                        franchise.TotalInvestment = Convert.ToInt32(reader["totalInvestment"]);
                        franchise.RoyaltyFee = Convert.ToInt32(reader["royaltyFee"]);
                        franchise.AdvertisingFee = Convert.ToInt32(reader["advertisingFee"]);
                        franchise.Heading = Convert.ToString(reader["heading"]);
                        franchise.FranchiseDescription = Convert.ToString(reader["franchiseDescription"]);
                        franchise.LogoURL = Convert.ToString(reader["logoUrl"]);
                        franchise.PicURL = Convert.ToString(reader["picUrl"]);

                        franchises.Add(franchise);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return franchises;
        }

        public Franchise GetFranchiseById(int franchiseId)
        {
            Franchise franchise = new Franchise();
            franchise.FranchiseId = franchiseId;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetFranchiseById, connection);
                    cmd.Parameters.AddWithValue("@id", franchiseId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        franchise.FranchiseName = Convert.ToString(reader["franchiseName"]);
                        franchise.YelpTerm = Convert.ToString(reader["yelpTerm"]);
                        franchise.FirstTimeFriendly = Convert.ToBoolean(reader["firstTimeFriendly"]);
                        franchise.StaffSize = Convert.ToString(reader["staffSize"]);
                        franchise.Category = Convert.ToString(reader["category"]);
                        franchise.NetWorth = Convert.ToInt32(reader["netWorth"]);
                        franchise.FranchiseFee = Convert.ToInt32(reader["franchiseFee"]);
                        franchise.TotalInvestment = Convert.ToInt32(reader["totalInvestment"]);
                        franchise.RoyaltyFee = Convert.ToInt32(reader["royaltyFee"]);
                        franchise.AdvertisingFee = Convert.ToInt32(reader["advertisingFee"]);
                        franchise.Heading = Convert.ToString(reader["heading"]);
                        franchise.FranchiseDescription = Convert.ToString(reader["franchiseDescription"]);
                        franchise.LogoURL = Convert.ToString(reader["logoUrl"]);
                        franchise.PicURL = Convert.ToString(reader["picUrl"]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return franchise;
        }
    }
}
