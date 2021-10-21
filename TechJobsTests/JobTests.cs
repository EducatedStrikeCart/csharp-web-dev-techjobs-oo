using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void A0_TestSettingJobId() //This test must be run first
        {

            Job testJob1 = new();
            Job testJob2 = new();

            Assert.AreEqual(1, testJob1.Id);
            Assert.AreEqual(2, testJob2.Id);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job testJob = new("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

            Assert.AreEqual("Product Tester", testJob.Name);
            Assert.AreEqual("ACME", testJob.EmployerName.Value);
            Assert.AreEqual("Desert", testJob.EmployerLocation.Value);
            Assert.AreEqual("Quality control", testJob.JobType.Value);
            Assert.AreEqual("Persistence", testJob.JobCoreCompetency.Value);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job testJob = new("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Job testJob1 = new("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

            Assert.AreEqual(4, testJob.Id);
            Assert.AreEqual(5, testJob1.Id);
        }

        [TestMethod]
        public void TestJobsToString()
        {
            Job testJob = new("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            string correctResult =
                "ID: 6\n" +
                "Name: Product Tester\n" +
                "Employer: ACME\n" +
                "Location: Desert\n" +
                "Position Type: Quality control\n" +
                "Core Competency: Persistence";

            string testResult = testJob.ToString();

            Assert.AreEqual(correctResult, testResult);
        }

        [TestMethod]
        public void TestJobsToString_Uninitiated()
        {
            Job testJob = new();

            string testResult = testJob.ToString();

            Assert.AreEqual("OOPS! This job does not seem to exist.", testResult);
        }


        [TestMethod]
        public void TestJobsToString_Blank()
        {
            Job testJob = new("", new Employer(""), new Location(""), new PositionType(""), new CoreCompetency("")); ;
            string correctResult =
                "ID: 7\n" +
                "Name: Data not available\n" +
                "Employer: Data not available\n" +
                "Location: Data not available\n" +
                "Position Type: Data not available\n" +
                "Core Competency: Data not available";

            string testResult = testJob.ToString();

            Assert.AreEqual(correctResult, testResult);
        }
    }
}
