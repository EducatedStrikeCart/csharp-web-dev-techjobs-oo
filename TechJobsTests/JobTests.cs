using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        Job defaultTestJob;
        [TestInitialize]
        public void InitDefaultTestJob()
        {
            defaultTestJob = new("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
        }

        [TestMethod]
        public void TestJobIdBeginsWithOne() //This test must be run first
        {
            Assert.AreEqual(2, defaultTestJob.Id); //This value is 2 because Id is static and defaultTestJob is initialized
        }

        [TestMethod]
        public void TestSettingJobId()
        {

            Job testJob1 = new();

            Assert.IsTrue(defaultTestJob.Id + 1 == testJob1.Id);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.AreEqual("Product Tester", defaultTestJob.Name);
            Assert.AreEqual("ACME", defaultTestJob.EmployerName.Value);
            Assert.AreEqual("Desert", defaultTestJob.EmployerLocation.Value);
            Assert.AreEqual("Quality control", defaultTestJob.JobType.Value);
            Assert.AreEqual("Persistence", defaultTestJob.JobCoreCompetency.Value);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job testJob1 = new("Product Tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

            Assert.IsFalse(defaultTestJob.Equals(testJob1));
        }

        [TestMethod]
        public void TestJobsToString()
        {
            string correctResult =
                "ID: 5\n" +
                "Name: Product Tester\n" +
                "Employer: ACME\n" +
                "Location: Desert\n" +
                "Position Type: Quality control\n" +
                "Core Competency: Persistence";

            string testResult = defaultTestJob.ToString();

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
            Job testJob = new("", new Employer(""), new Location(""), new PositionType(""), new CoreCompetency(""));
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
