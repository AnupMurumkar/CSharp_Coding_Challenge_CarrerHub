using CareerHub.Model;

namespace CareerHub.dao
{
    public interface IJobListingInsertDAO
    {
        void InsertJobListing(JobListing job);
        List<JobListing> GetJobListings();
        double CalculateAverageSalary();
    }
}
