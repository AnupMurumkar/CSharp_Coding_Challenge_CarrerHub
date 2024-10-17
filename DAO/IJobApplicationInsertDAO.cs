
using CareerHub.Model;

namespace CareerHub.dao
{
    public interface IJobApplicationInsertDAO
    {
        void InsertJobApplication(JobApplication application);
        List<JobApplication> GetApplicationsForJob(int jobID);
    }
}
