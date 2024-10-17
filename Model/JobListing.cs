
using CareerHub.exception;

namespace CareerHub.Model
{
    public class JobListing
    {
        private decimal _salary;

        public int JobID { get; set; }
        public int CompanyID { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string JobLocation { get; set; }
        public decimal Salary
        {
            get => _salary; // Return  salary
            set
            {
                // Validate the salary
                if (value < 0)
                {
                    throw new NegativeSalaryException("Salary cannot be negative.");
                }
                _salary = value; // Set the salary 
            }
        }
        public string JobType { get; set; }
        public DateTime PostedDate { get; set; }

         


    }
}
