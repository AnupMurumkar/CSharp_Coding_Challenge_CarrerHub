
using CareerHub.Model;
using CareerHub.util;
using System;
using System.Data.SqlClient;

namespace CareerHub.dao
{
    public class CompanyInsertDAOImpl : ICompanyInsertDAO
    {
        public void InsertCompany(Company company)
        {
            string cnString = DBConnUtil.ReturnCn("CarrerHubCn");

            using (SqlConnection conn = new SqlConnection(cnString))
            {
                string query = "INSERT INTO Company (CompanyID, CompanyName, Location) " +
                               "VALUES (@CompanyID, @CompanyName, @Location)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CompanyID", company.CompanyID);
                cmd.Parameters.AddWithValue("@CompanyName", company.CompanyName);
                cmd.Parameters.AddWithValue("@Location", company.Location);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Company inserted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting company: " + ex.Message);
                }
            }
        }
        public List<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();

            string cnString = DBConnUtil.ReturnCn("CarrerHubCn");

            using (SqlConnection conn = new SqlConnection(cnString))
            {
                string query = "SELECT * FROM Company";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Company company = new Company
                        {
                            CompanyID = reader.GetInt32(0),
                            CompanyName = reader.GetString(1),
                            Location = reader.GetString(2)
                        };
                        companies.Add(company);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving companies: " + ex.Message);
                }
            }

            return companies;
        }
    }
}
