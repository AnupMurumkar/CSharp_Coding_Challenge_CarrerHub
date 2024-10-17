using CareerHub.exception;
using CareerHub.Model;
using CareerHub.util;
using System;
using System.Data.SqlClient;

namespace CareerHub.dao
{
    public class JobListingInsertDAOImpl : IJobListingInsertDAO
    {
        public void InsertJobListing(JobListing job)
        {
            try
            {
                if (job.Salary < 0)
                {
                    throw new NegativeSalaryException("Salary cannot be negative.");
                }

                string cnString = DBConnUtil.ReturnCn("CarrerHubCn");

                using (SqlConnection conn = new SqlConnection(cnString))
                {
                    string query = "INSERT INTO JobListing (JobID, CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate) " +
                                   "VALUES (@JobID, @CompanyID, @JobTitle, @JobDescription, @JobLocation, @Salary, @JobType, @PostedDate)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@JobID", job.JobID);
                    cmd.Parameters.AddWithValue("@CompanyID", job.CompanyID);
                    cmd.Parameters.AddWithValue("@JobTitle", job.JobTitle);
                    cmd.Parameters.AddWithValue("@JobDescription", job.JobDescription);
                    cmd.Parameters.AddWithValue("@JobLocation", job.JobLocation);
                    cmd.Parameters.AddWithValue("@Salary", job.Salary);
                    cmd.Parameters.AddWithValue("@JobType", job.JobType);
                    cmd.Parameters.AddWithValue("@PostedDate", job.PostedDate);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Job listing inserted successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error inserting job listing: " + ex.Message);
                    }
                }
            }
            catch (NegativeSalaryException ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }
        }

        public List<JobListing> GetJobListings()
        {
            List<JobListing> jobListings = new List<JobListing>();


            try
            {

                string cnString = DBConnUtil.ReturnCn("CarrerHubCn");

                using (SqlConnection conn = new SqlConnection(cnString))
                {
                    string query = "SELECT * FROM JobListing";
                    SqlCommand cmd = new SqlCommand(query, conn);

                   
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            JobListing job = new JobListing
                            {
                                JobID = reader.GetInt32(0),
                                CompanyID = reader.GetInt32(1),
                                JobTitle = reader.GetString(2),
                                JobDescription = reader.GetString(3),
                                JobLocation = reader.GetString(4),
                                Salary = reader.GetDecimal(5),
                                JobType = reader.GetString(6),
                                PostedDate = reader.GetDateTime(7)
                            };
                            jobListings.Add(job);
                        }
                   
                    
                }
            }
            catch (NegativeSalaryException ex)
            {
                Console.WriteLine("Error: " + ex.Message); 
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Database error: " + sqlEx.Message); 
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message); 
            }

            return jobListings;
        }
        public double CalculateAverageSalary()
        {
            List<JobListing> jobListings = GetJobListings();
            double totalSalary = 0;
            int validSalaryCount = 0;
            List<JobListing> invalidJobs = new List<JobListing>();

            foreach (var job in jobListings)
            {
                if (job.Salary < 0)
                {
                    invalidJobs.Add(job);
                }
                else
                {
                    totalSalary += (double)job.Salary;
                    validSalaryCount++;
                }
            }

            if (invalidJobs.Count > 0)
            {
                throw new InvalidOperationException("Some job listings have negative salaries.");
            }

            return validSalaryCount > 0 ? totalSalary / validSalaryCount : 0;
        }
    }
}
