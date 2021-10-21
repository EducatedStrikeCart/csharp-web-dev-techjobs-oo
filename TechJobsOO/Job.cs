using System;
using System.Collections.Generic;
using System.Reflection;

namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency):this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        public override string ToString()
        {
            if (Name == null || EmployerName == null || EmployerLocation == null || JobType == null || JobCoreCompetency == null)
            {
                return "OOPS! This job does not seem to exist.";
            }

            string output = "";
            output += $"ID: {Id}\n";
            output += Name == "" ? "Name: Data not available\n" : $"Name: {Name}\n";
            output += EmployerName.Value == "" ? "Employer: Data not available\n" : $"Employer: {EmployerName}\n";
            output += EmployerLocation.Value == "" ? "Location: Data not available\n" : $"Location: {EmployerLocation}\n";
            output += JobType.Value == "" ? "Position Type: Data not available\n" : $"Position Type: {JobType}\n";
            output += JobCoreCompetency.Value == "" ? "Core Competency: Data not available" : $"Core Competency: {JobCoreCompetency}";

            return output;
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id &&
                   Name == job.Name &&
                   EqualityComparer<Employer>.Default.Equals(EmployerName, job.EmployerName) &&
                   EqualityComparer<Location>.Default.Equals(EmployerLocation, job.EmployerLocation) &&
                   EqualityComparer<PositionType>.Default.Equals(JobType, job.JobType) &&
                   EqualityComparer<CoreCompetency>.Default.Equals(JobCoreCompetency, job.JobCoreCompetency);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, EmployerName, EmployerLocation, JobType, JobCoreCompetency);
        }
    }
}
