using CareerHub.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CareerHub.exception;
using CareerHub.util; 

namespace CareerHub.dao
{
    public class ApplicantInsertDAOImpl : IApplicantInsertDAO
    {
        public void InsertApplicant(Applicant applicant)
        {
           
            EmailValidator.ValidateEmail(applicant.Email);
            string cnString = DBConnUtil.ReturnCn("CarrerHubCn");

            using (SqlConnection conn = new SqlConnection(cnString))
            {
                string query = "INSERT INTO Applicant (ApplicantID, FirstName, LastName, Email, Phone, Resume) " +
                               "VALUES (@ApplicantID, @FirstName, @LastName, @Email, @Phone, @Resume)"; 

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ApplicantID", applicant.ApplicantID);
                cmd.Parameters.AddWithValue("@FirstName", applicant.FirstName);
                cmd.Parameters.AddWithValue("@LastName", applicant.LastName);
                cmd.Parameters.AddWithValue("@Email", applicant.Email);
                cmd.Parameters.AddWithValue("@Phone", applicant.Phone);
                cmd.Parameters.AddWithValue("@Resume", applicant.Resume);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Applicant inserted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting applicant: " + ex.Message);
                }
            }
        }

        public List<Applicant> GetApplicants()
        {
            List<Applicant> applicants = new List<Applicant>();

            string cnString = DBConnUtil.ReturnCn("CarrerHubCn");

            using (SqlConnection conn = new SqlConnection(cnString))
            {
                string query = "SELECT * FROM Applicant";
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Applicant applicant = new Applicant
                        {
                            ApplicantID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3),
                            Phone = reader.GetString(4),
                            Resume = reader.GetString(5)
                        };
                        applicants.Add(applicant);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error retrieving applicants: " + ex.Message);
                }
            }

            return applicants;
        }
    }
}
