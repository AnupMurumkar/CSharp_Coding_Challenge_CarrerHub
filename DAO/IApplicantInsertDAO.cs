
using CareerHub.Model;

namespace CareerHub.dao
{
    public interface IApplicantInsertDAO
    {
        void InsertApplicant(Applicant applicant);
        List<Applicant> GetApplicants();
    }
}
