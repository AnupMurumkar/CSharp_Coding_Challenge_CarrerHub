using Microsoft.EntityFrameworkCore;
using CareerHub.Model;
using System.Collections.Generic;

namespace CareerHub.util
{
    public class CareerHubContext : DbContext
    {
        public DbSet<JobListing> JobListings { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-8JT18MT0;Initial Catalog=CarrerHub;Integrated Security=True;");
        }
    }
}