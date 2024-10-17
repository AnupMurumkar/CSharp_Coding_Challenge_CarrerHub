using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerHub.Model;
using CareerHub.util;

namespace CareerHub.dao
{
    public interface IDatabaseInitializer
    {
        void InitializeDatabase();
    }
    public interface IJobListing
    {
        void InsertJobListing(JobListing job);
        List<JobListing> GetJobListings();
    }
    public interface ICompany
    {
        void InsertCompany(Company company);
        List<Company> GetCompanies();
    }
    public interface IApplicant
    {
        void InsertApplicant(Applicant applicant);
        List<Applicant> GetApplicants();
    }
    public interface IJobApplication
    {
        void InsertJobApplication(JobApplication application);
        List<JobApplication> GetApplicationsForJob(int jobID);
    }
    public interface JobListingRetrieval
    {
        List<JobListing> GetJobListings();
    }
    public interface ICompanyRetrieval
    {
        List<Company> GetCompanies();
    }
    public interface IApplicantRetrieval
    {
        List<Applicant> GetApplicants();
    }
    public interface IJobApplicationRetrieval
    {
        List<JobApplication> GetApplicationsForJob(int jobID);
    }
    public interface GetNextJobId
    {
        int GetNextJobId();
        int GetNextApplicationId();
    }
    public interface GetNextApplicationId
    {
        int GetNextApplicationId();
    }

}