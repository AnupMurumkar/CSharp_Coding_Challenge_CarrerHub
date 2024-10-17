// File: dao/JobApplicationInsertDAOImpl.cs
using CareerHub.Model;
using CareerHub.util;
using System;
using System.Data.SqlClient;

namespace CareerHub.dao
{
    public class JobApplicationInsertDAOImpl : IJobApplicationInsertDAO
    {
        public void InsertJobApplication(JobApplication application)
        {
            string cnString = DBConnUtil.ReturnCn("CarrerHubCn");

            using (SqlConnection conn = new SqlConnection(cnString))
            {
                string query = "INSERT INTO JobApplication (ApplicationID, JobID, ApplicantID, ApplicationDate, CoverLetter) " +
                               "VALUES (@ApplicationID, @JobID, @ApplicantID, @ApplicationDate, @CoverLetter)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ApplicationID", application.ApplicationID);
                cmd.Parameters.AddWithValue("@JobID", application.JobID);
                cmd.Parameters.AddWithValue("@ApplicantID", application.ApplicantID);
                cmd.Parameters.AddWithValue("@ApplicationDate", application.ApplicationDate);
                cmd.Parameters.AddWithValue("@CoverLetter", application.CoverLetter);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Job application inserted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting job application: " + ex.Message);
                }
            }
        }
        public List<JobApplication> GetApplicationsForJob(int jobID)
        {
            List<JobApplication> applications = new List<JobApplication>();
            string cnString = DBConnUtil.ReturnCn("CarrerHubCn");

            using (SqlConnection conn = new SqlConnection(cnString))
            {
                string query = "SELECT * FROM JobApplication WHERE JobID = @JobID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@JobID", jobID);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        JobApplication application = new JobApplication
                        {
                            ApplicationID = reader.GetInt32(0),
                            JobID = reader.GetInt32(1),
                            ApplicantID = reader.GetInt32(2),
                            ApplicationDate = reader.GetDateTime(3),
                            CoverLetter = reader.GetString(4)
                        };
                        applications.Add(application);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving job applications: " + ex.Message);
                }
            }

            return applications;
        }
    }
}
