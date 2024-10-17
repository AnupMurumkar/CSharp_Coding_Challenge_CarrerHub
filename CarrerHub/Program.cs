
using CareerHub.Model;
using System;
using CareerHub.dao;
using CareerHub.exception;
using System.IO;
using System.Data.SqlClient;
using DAO;

namespace CareerHub.main
{
    class MainModule
    {
        static void Main(string[] args)

        {
            Console.WriteLine("Welcome to CareerHub!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. databaseMangerTask2");
            Console.WriteLine("2. Insert Company");
            Console.WriteLine("3. Insert Job");
            Console.WriteLine("4. Insert Applicant");
            Console.WriteLine("5. Insert Job Application");
            Console.WriteLine("6. GetJobListings");
            Console.WriteLine("7. GetCompanies");
            Console.WriteLine("8. GetApplicants");
            Console.WriteLine("9. GetApplicationsForJob");
            Console.WriteLine("10. Calculate Average Salary  Exception");
            Console.WriteLine("11. file Upload Exception");
            Console.WriteLine("12. Application Deadline Exception");
            Console.WriteLine("13. database Connection   Exception");
            Console.WriteLine("14. database Connectivity Task 4");

            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DatabaseMangerTask2();   //inserting data without the database connections
                    break;
                case 2:                      //  the case  2 to 8 inserts the data with the  help of database connection directly on the CarrerHub Database
                    CompanyInsert();
                    break;

                case 3:
                    InsertJobListing();
                    break;
                case 4:
                    ApplicantInsert();
                    break;
                case 5:
                    JobApplicationInsert();
                    break;
                case 6:
                    GetJobListings();
                    break;
                case 7:
                    GetCompanies();
                    break;
                case 8:
                    GetApplicants();
                    break;
                case 9:
                    GetApplicationsForJob();
                    break;
                case 10:
                    CalculateAverageSalary();
                    break;
                case 11:
                    UploadResume();
                    break;
                case 12:
                    ApplicationDeadline();
                    break;
                case 13:
                    TestDatabaseConnection();
                    break;

                case 14:
                    DatabaseConnectivity2();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }


        static void DatabaseMangerTask2()
        {
            CareerHubService service = new CareerHubService();

            service.InitializeDatabase();


            service.InsertCompany(new Company { CompanyID = 1, CompanyName = "Tech Innovators", Location = "San Francisco" });
            service.InsertCompany(new Company { CompanyID = 2, CompanyName = "Creative Solutions", Location = "New York" });


            service.InsertJobListing(new JobListing { JobID = 1, CompanyID = 1, JobTitle = "Software Engineer", JobDescription = "Develop software applications.", JobLocation = "Remote", Salary = 120000, JobType = "Full-time", PostedDate = DateTime.Now });
            service.InsertJobListing(new JobListing { JobID = 2, CompanyID = 2, JobTitle = "Graphic Designer", JobDescription = "Design marketing materials.", JobLocation = "In-house", Salary = 70000, JobType = "Part-time", PostedDate = DateTime.Now });


            service.InsertApplicant(new Applicant { ApplicantID = 1, FirstName = "Anup", LastName = "Murumkar", Email = "Anup@example.com", Phone = "123-456-7890", Resume = "resume.pdf" });


            service.InsertJobApplication(new JobApplication { ApplicationID = 1, JobID = 1, ApplicantID = 1, ApplicationDate = DateTime.Now, CoverLetter = "I am very interested in this position." });


            var jobListings = service.GetJobListings();
            Console.WriteLine("Job Listings:");
            foreach (var job in jobListings)
            {
                Console.WriteLine($"ID: {job.JobID}, Title: {job.JobTitle}, Company ID: {job.CompanyID}, Salary: {job.Salary:C}");
            }
        }

        static void InsertJobListing()
        {

            JobListing newJob = new JobListing
            {
                JobID = 5,
                CompanyID = 101,
                JobTitle = "Software Engineer",
                JobDescription = "Develop and maintain software solutions.",
                JobLocation = "New York",
                Salary = 80000.00m,
                JobType = "Full-time",
                PostedDate = DateTime.Now
            };


            IJobListingInsertDAO jobListingDAO = new JobListingInsertDAOImpl();
            jobListingDAO.InsertJobListing(newJob);

            Console.WriteLine("Job insertion initiated from Main Module.");
        }

        static void CompanyInsert()
        {
            // Create a Company object
            Company newCompany = new Company
            {
                CompanyID = 101,
                CompanyName = "Tech Innovators",
                Location = "San Francisco"
            };


            ICompanyInsertDAO companyDAO = new CompanyInsertDAOImpl();
            companyDAO.InsertCompany(newCompany);

            Console.WriteLine("Company inserted successfully from CompanyInsert method.");
        }

        static void ApplicantInsert()
        {
            try
            {

                Applicant newApplicant = new Applicant
                {
                    ApplicantID = 2,
                    FirstName = "Anup",
                    LastName = "Murumkar",
                    Email = "johndoe@example/com",
                    Phone = "123-456-7890",
                    Resume = "ResumeFile.pdf"
                };


                IApplicantInsertDAO applicantDAO = new ApplicantInsertDAOImpl();
                applicantDAO.InsertApplicant(newApplicant);

                Console.WriteLine("Applicant inserted successfully from ApplicantInsert method.");
            }
            catch (InvalidEmailException ex)
            {
                Console.WriteLine(ex.Message); // Handle invalid email format
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message); // Handle any other errors
            }
        }


        static void JobApplicationInsert()
        {
            // Create a JobApplication object
            JobApplication newApplication = new JobApplication
            {
                ApplicationID = 1,
                JobID = 101,
                ApplicantID = 1,
                ApplicationDate = DateTime.Now,
                CoverLetter = "I am very interested in this job position."
            };

            // DAO interface to insert the job application
            IJobApplicationInsertDAO jobApplicationDAO = new JobApplicationInsertDAOImpl();
            jobApplicationDAO.InsertJobApplication(newApplication);

            Console.WriteLine("Job application inserted successfully from JobApplicationInsert method.");
        }

        static void GetJobListings()
        {
            IJobListingInsertDAO jobListingDAO = new JobListingInsertDAOImpl();
            var jobListings = jobListingDAO.GetJobListings();

            Console.WriteLine("Job Listings:");
            foreach (var job in jobListings)
            {
                Console.WriteLine($"ID: {job.JobID}, Title: {job.JobTitle}, CompanyID: {job.CompanyID}, Salary: {job.Salary}");
            }
        }


        static void GetCompanies()
        {
            ICompanyInsertDAO companyDAO = new CompanyInsertDAOImpl();
            var companies = companyDAO.GetCompanies();

            Console.WriteLine("Companies:");
            foreach (var company in companies)
            {
                Console.WriteLine($"ID: {company.CompanyID}, Name: {company.CompanyName}, Location: {company.Location}");
            }
        }


        static void GetApplicants()
        {
            IApplicantInsertDAO applicantDAO = new ApplicantInsertDAOImpl();
            var applicants = applicantDAO.GetApplicants();

            Console.WriteLine("Applicants:");
            foreach (var applicant in applicants)
            {
                Console.WriteLine($"ID: {applicant.ApplicantID}, Name: {applicant.FirstName} {applicant.LastName}, Email: {applicant.Email}");
            }
        }

        static void GetApplicationsForJob()
        {
            Console.Write("Enter Job ID to retrieve applications: ");
            int jobID = int.Parse(Console.ReadLine());

            IJobApplicationInsertDAO jobApplicationDAO = new JobApplicationInsertDAOImpl();
            var applications = jobApplicationDAO.GetApplicationsForJob(jobID);

            Console.WriteLine($"Job Applications for Job ID {jobID}:");
            foreach (var application in applications)
            {
                Console.WriteLine($"Application ID: {application.ApplicationID}, Applicant ID: {application.ApplicantID}, Date: {application.ApplicationDate}");
            }
        }

        // Method to calculate and display the average salary
        static void CalculateAverageSalary()
        {
            try
            {
                IJobListingInsertDAO jobListingDAO = new JobListingInsertDAOImpl();
                double averageSalary = jobListingDAO.CalculateAverageSalary();
                Console.WriteLine($"The average salary offered by companies for job listings is: {averageSalary:C}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Method to handle file upload
        static void UploadResume()
        {
            try
            {
                Console.Write("Enter the file path for the resume: ");
                string filePath = Console.ReadLine();

                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    throw new FileUploadException("File not found. Please check the file path.");
                }

                //2mb limit
                FileInfo fileInfo = new FileInfo(filePath);
                if (fileInfo.Length > 2 * 1024 * 1024)
                {
                    throw new FileUploadException("File size exceeded the maximum limit of 2MB.");
                }

                // allow only .pdf and .docx
                string fileExtension = Path.GetExtension(filePath).ToLower();
                if (fileExtension != ".pdf" && fileExtension != ".docx")
                {
                    throw new FileUploadException("Unsupported file format. Only .pdf and .docx files are allowed.");
                }


                Console.WriteLine("Resume uploaded successfully.");
            }
            catch (FileUploadException ex)
            {
                Console.WriteLine("File Upload Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        static void ApplicationDeadline()
        {
            try
            {
                Console.Write("Enter the application deadline (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime deadline))
                {
                    // check deadline
                    if (DateTime.Now > deadline)
                    {
                        throw new InvalidOperationException("Application deadline has passed. No further applications can be submitted.");
                    }

                    Console.WriteLine($"Application deadline set to: {deadline.ToShortDateString()}");
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter a valid date.");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message); // Handle application deadline error
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        static void TestDatabaseConnection()
        {
            try
            {
                IJobListingInsertDAO jobListingDAO = new JobListingInsertDAOImpl();
                var jobListings = jobListingDAO.GetJobListings();

                Console.WriteLine("Job Listings:");
                foreach (var job in jobListings)
                {
                    Console.WriteLine($"ID: {job.JobID}, Title: {job.JobTitle}, Salary: {job.Salary:C}");
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Database error: " + sqlEx.Message); // Handle SQL errors
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message); // Handle other errors
            }
        }

       
       public static void DatabaseConnectivity2()

        {
            DatabaseManagerImpl dbManager = new DatabaseManagerImpl();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nWelcome to CarrerHub, The Job Board!:");
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Retrieve Job Listings");
                Console.WriteLine("2. Create Applicant Profile");
                Console.WriteLine("3. Submit Job Application");
                Console.WriteLine("4. Post Job Listing");
                Console.WriteLine("5. Search Jobs by Salary Range");
                Console.WriteLine("6. Exit");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                  
                        try
                        {
                            List<JobListing> jobs = dbManager.GetJobListings();
                            if (jobs.Count == 0)
                            {
                                Console.WriteLine("No job listings found.");
                            }
                            else
                            {
                                foreach (var job in jobs)
                                {
                                    Console.WriteLine($"Job Title: {job.JobTitle}, Company ID: {job.CompanyID}, Salary: {job.Salary}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error retrieving job listings: {ex.Message}");
                        }
                        break;

                    case "2":
                      
                        try
                        {
                            Console.WriteLine("Enter Applicant ID:");
                            int applicantId = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter First Name:");
                            string firstName = Console.ReadLine();

                            Console.WriteLine("Enter Last Name:");
                            string lastName = Console.ReadLine();

                            Console.WriteLine("Enter Email:");
                            string email = Console.ReadLine();

                            EmailValidator.ValidateEmail(email);

                            Console.WriteLine("Enter Phone:");
                            string phone = Console.ReadLine();

                            Applicant newApplicant = new Applicant
                            {
                                ApplicantID = applicantId,
                                FirstName = firstName,
                                LastName = lastName,
                                Email = email,
                                Phone = phone,
                                Resume = "Resume data here"
                            };


                            
                            dbManager.InsertApplicant(newApplicant);

                            Console.WriteLine("Applicant profile created successfully!");
                        }
                        catch (InvalidEmailException ex)
                        {
                            Console.WriteLine($"Email validation error: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error creating applicant profile: {ex.Message}");
                        }
                        break;

                    case "3":
                        
                        try
                        {
                            Console.WriteLine("Enter Job ID:");
                            int jobId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Applicant ID:");
                            int applicantId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Application ID:");
                            int applicationId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Cover Letter:");
                            string coverLetter = Console.ReadLine();

                            JobApplication application = new JobApplication
                            {
                                ApplicationID = applicationId,
                                JobID = jobId,
                                ApplicantID = applicantId,
                                ApplicationDate = DateTime.Now,
                                CoverLetter = coverLetter
                            };

                            dbManager.InsertJobApplication(application);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error submitting job application: {ex.Message}");
                        }
                        break;

                    case "4":
                        
                        try
                        {
                            Console.WriteLine("Enter Company ID:");
                            int companyId = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Job ID:");
                            int jobID = int.Parse(Console.ReadLine());

                      
                            if (dbManager.CheckJobIDExists(jobID))
                            {
                                Console.WriteLine($"Job ID {jobID} already exists. Please enter a unique Job ID.");
                                break;
                            }

                            Console.WriteLine("Enter Job Title:");
                            string jobTitle = Console.ReadLine();

                            Console.WriteLine("Enter Job Description:");
                            string jobDescription = Console.ReadLine();

                            Console.WriteLine("Enter Job Location:");
                            string jobLocation = Console.ReadLine();

                            Console.WriteLine("Enter Salary:");
                            decimal salary = decimal.Parse(Console.ReadLine());

                            Console.WriteLine("Enter Job Type(e.g., Full - Time, Part - Time):");
                            string jobType = Console.ReadLine();

                           
                            JobListing newJob = new JobListing
                            {
                                JobID = jobID,
                                CompanyID = companyId,
                                JobTitle = jobTitle,
                                JobDescription = jobDescription,
                                JobLocation = jobLocation,
                                Salary = salary,
                                JobType = jobType,
                                PostedDate = DateTime.Now
                            };


                            
                            dbManager.InsertJobListing(newJob);

                            Console.WriteLine("Job posted successfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error posting job: {ex.Message}");
                        }
                        break;


                    case "5":
                   
                        try
                        {
                            Console.WriteLine("Enter Minimum Salary:");
                            decimal minSalary = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Maximum Salary:");
                            decimal maxSalary = decimal.Parse(Console.ReadLine());

                            var jobsInRange = dbManager.GetJobListings();
                            Console.WriteLine("Job Listings within Salary Range:");
                            foreach (var job in jobsInRange)
                            {
                                if (job.Salary >= minSalary && job.Salary <= maxSalary)
                                {
                                    Console.WriteLine($"Job Title: {job.JobTitle}, Salary: {job.Salary}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error retrieving jobs by salary: {ex.Message}");
                        }
                        break;

                    case "6":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}


