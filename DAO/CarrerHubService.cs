using CareerHub.Model;
using System;
using System.Collections.Generic;
using System.Linq;

public class CareerHubService
{
    private List<JobListing> jobListings = new List<JobListing>();
    private List<Company> companies = new List<Company>();
    private List<Applicant> applicants = new List<Applicant>();
    private List<JobApplication> jobApplications = new List<JobApplication>();


    public void InitializeDatabase()
    {
        
        jobListings.Clear();
        companies.Clear();
        applicants.Clear();
        jobApplications.Clear();
        Console.WriteLine("Database initialized successfully.");
    }


    public void InsertJobListing(JobListing job)
    {
        jobListings.Add(job);
        Console.WriteLine("Job listing inserted successfully.");
    }

    
    public void InsertCompany(Company company)
    {
        companies.Add(company);
        Console.WriteLine("Company inserted successfully.");
    }

    
    public void InsertApplicant(Applicant applicant)
    {
        applicants.Add(applicant);
        Console.WriteLine("Applicant inserted successfully.");
    }


    public void InsertJobApplication(JobApplication application)
    {
        jobApplications.Add(application);
        Console.WriteLine("Job application submitted successfully.");
    }

    
    public List<JobListing> GetJobListings()
    {
        return jobListings;
    }

    
    public List<Company> GetCompanies()
    {
        return companies;
    }


    public List<Applicant> GetApplicants()
    {
        return applicants;
    }

    public List<JobApplication> GetApplicationsForJob(int jobID)
    {
        return jobApplications.Where(app => app.JobID == jobID).ToList();
    }
}
