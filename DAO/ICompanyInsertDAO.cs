
using CareerHub.Model;

namespace CareerHub.dao
{
    public interface ICompanyInsertDAO
    {
        void InsertCompany(Company company);
        List<Company> GetCompanies();
    }
}
