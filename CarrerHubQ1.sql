use  CarrerHub


CREATE TABLE Company (
    CompanyID INT PRIMARY KEY,
    CompanyName VARCHAR(255),
    Location VARCHAR(255)
);


CREATE TABLE Applicant (
    ApplicantID INT PRIMARY KEY,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    Email VARCHAR(255),
    Phone VARCHAR(20),
    Resume VARCHAR(255)
);


CREATE TABLE JobListing (
    JobID INT PRIMARY KEY,
    CompanyID INT,
    JobTitle VARCHAR(255),
    JobDescription TEXT,
    JobLocation VARCHAR(255),
    Salary DECIMAL(18, 2),
    JobType VARCHAR(50),
    PostedDate DATETIME,
    FOREIGN KEY (CompanyID) REFERENCES Company(CompanyID)
);

CREATE TABLE JobApplication (
    ApplicationID INT PRIMARY KEY,
    JobID INT,
    ApplicantID INT,
    ApplicationDate DATETIME,
    CoverLetter TEXT,
    FOREIGN KEY (JobID) REFERENCES JobListing(JobID),  
    FOREIGN KEY (ApplicantID) REFERENCES Applicant(ApplicantID)
	);


INSERT INTO Company (CompanyID, CompanyName, Location)
VALUES 
(1, 'Tech Innovators', 'San Francisco'),
(2, 'Creative Solutions', 'New York'),
(3, 'HealthTech Corp', 'Los Angeles');


INSERT INTO Applicant (ApplicantID, FirstName, LastName, Email, Phone, Resume)
VALUES 
(1, 'John', 'Doe', 'john.doe@example.com', '123-456-7890', 'path/to/resume1.pdf'),
(2, 'Jane', 'Smith', 'jane.smith@example.com', '987-654-3210', 'path/to/resume2.pdf'),
(3, 'Alice', 'Johnson', 'alice.johnson@example.com', '456-789-0123', 'path/to/resume3.pdf');

INSERT INTO JobApplication (ApplicationID, JobID, ApplicantID, ApplicationDate, CoverLetter)
VALUES 
(1, 1, 1, GETDATE(), 'I am excited about the opportunity to work with Tech Innovators.'),
(2, 2, 2, GETDATE(), 'I have a passion for design and would love to contribute to Creative Solutions.'),
(3, 3, 3, GETDATE(), 'My skills in data analysis are perfect for the position at HealthTech Corp.');

INSERT INTO JobListing (JobID, CompanyID, JobTitle, JobDescription, JobLocation, Salary, JobType, PostedDate)
VALUES 
(1, 1, 'Software Engineer', 'Develop and maintain software applications.', 'Remote', 120000, 'Full-Time', GETDATE()),
(2, 2, 'Graphic Designer', 'Design marketing materials and graphics.', 'In-house', 60000, 'Part-Time', GETDATE()),
(3, 3, 'Data Analyst', 'Analyze and interpret complex data sets.', 'Hybrid', 90000, 'Full-Time', GETDATE());
