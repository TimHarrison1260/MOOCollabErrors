using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Data.EntityModel;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//using Moq;

using MOOCollab.DataAccess;
using MOOCollab.DataAccess.Repositories;
using MOOCollab.DataAccess.TestContext;     //  The TestDb context
using MOOCollab.Contracts.RepositoryContracts;
using MOOCollab.Contracts;
using MOOCollab.Domain;

namespace MOOCollab.UnitTests.RepositoryIntegrationTests
{
    [TestClass]
    public class StudentFollowingTests
    {
        [TestMethod]
        public void GetStudentsForCourse_Returns_correctnumber()
        {
            //  Arrange
            //  -------
            TestDb testContext = new TestDb();

            //  instantiate the repository class
            UserRepository repository = new UserRepository(testContext);
            string username = "Tim";

            //  Action
            //  ------
            IQueryable<User> course1students = repository.GetUsersForCourse(1, username);
            var course2students = repository.GetUsersForCourse(2, username);
            var course3students = repository.GetUsersForCourse(3, username);
            var course4students = repository.GetUsersForCourse(4, username);
            var course5students = repository.GetUsersForCourse(5, username);

            //  Assert
            //  ------
            Assert.AreEqual(5 - 1, course1students.Count());  // 1 less as the method exclued the named user (logged on)
            Assert.AreEqual(5 - 1, course2students.Count());
            Assert.AreEqual(14 - 1, course3students.Count());
            Assert.AreEqual(8 - 1, course4students.Count());
            Assert.AreEqual(14 - 1, course5students.Count());

        }

        [TestMethod]
        public void GetStudentsForCourse1_Returns_Student_Names()
        {
            //  Arrange
            //  -------
            TestDb testContext = new TestDb();

            //  instantiate the repository class
            UserRepository repository = new UserRepository(testContext);
            string username = "Tim";

            //  Action
            //  ------
            List<User> course1students = repository.GetUsersForCourse(1, username).ToList<User>();

            //  Assert
            //  ------
            Assert.AreEqual("Robert", course1students[0].UserName);
            Assert.AreEqual("Andrew", course1students[1].UserName);
            Assert.AreEqual("Narelle", course1students[2].UserName);
            Assert.AreEqual("Bartoz", course1students[3].UserName);
            Assert.AreEqual(4, course1students.Count());    // Tim is not there, excluded from method as logged on user.
        }

        [TestMethod]
        public void GetStudentsForGroups_Returns_CorrectNumber()
        {
            //  Arrange
            //  -------
            TestDb testContext = new TestDb();

            //  instantiate the repository class
            UserRepository repository = new UserRepository(testContext);
            string username = "Tim";

            //  Action
            //  ------
            List<User> group1students = repository.GetUsersForGroup(1, username).ToList<User>();
            List<User> group2students = repository.GetUsersForGroup(2, username).ToList<User>();
            List<User> group3students = repository.GetUsersForGroup(3, username).ToList<User>();
            List<User> group4students = repository.GetUsersForGroup(4, username).ToList<User>();
            List<User> group5students = repository.GetUsersForGroup(5, username).ToList<User>();
            List<User> group6students = repository.GetUsersForGroup(6, username).ToList<User>();
            List<User> group7students = repository.GetUsersForGroup(7, username).ToList<User>();
            List<User> group8students = repository.GetUsersForGroup(8, username).ToList<User>();
            List<User> group9students = repository.GetUsersForGroup(9, username).ToList<User>();
            List<User> group10students = repository.GetUsersForGroup(10, username).ToList<User>();
            List<User> group11students = repository.GetUsersForGroup(11, username).ToList<User>();

            //  Assert
            //  ------
            Assert.AreEqual(5 - 1, group1students.Count()); //  minus 1 as the method excludes Tim: the logged on user.
            Assert.AreEqual(8, group2students.Count());     //  Tim NOT member
            Assert.AreEqual(4, group3students.Count());     //  Tim NOT member
            Assert.AreEqual(9, group4students.Count());     //  Tim NOT member
            Assert.AreEqual(7, group5students.Count());     //  Tim NOT member
            Assert.AreEqual(5 - 1, group6students.Count()); //  Tim IS member
            Assert.AreEqual(3, group7students.Count());     //  Tim NOT member
            Assert.AreEqual(7, group8students.Count());     //  Tim NOT member
            Assert.AreEqual(6 - 1, group9students.Count()); //  Tim IS member
            Assert.AreEqual(4 - 1, group10students.Count());//  Tim IS member
            Assert.AreEqual(9 - 1, group11students.Count());//  Tim IS member
        }

        [TestMethod]
        public void Student1_Follows_Student_2_OK()
        {
            //  Arrange
            //  -------
            TestDb testContext = new TestDb();

            //  instantiate the repository class
            UserRepository repository = new UserRepository(testContext);

            //  Tim is Student no 7, Robert is Student no 3.  Is already followin Jim, Brian and Bartosz
            //  Get Robert            
            User robert = testContext.Users.FirstOrDefault(s => s.Id == 3);
            int timsId = 7;

            //  Action
            //  ------
            //  Set Tim to Follow Robert, only setting the one side
            repository.FollowUser(timsId, robert);

            //  Retrieve who Tim is Following, and who is following Robert
            //  Get Tim
            User tim = testContext.Users.FirstOrDefault(s => s.Id == 7);
            //  Refresh Robert
            robert = testContext.Users.FirstOrDefault(s => s.Id == 3);

            //  Assert
            //  ------
            // Tim follows Jim, Brian and Bartosz and now Robert should be added
            Assert.AreEqual(4, tim.Following.Count());
            //  Robert should be in Tim's collection of students he's following.
            Assert.IsTrue(tim.Following.Contains(robert));
            //  Only Tim should be following Robert
            Assert.AreEqual(1, robert.Followers.Count());
            //  Tim should be in Roberts collection of students following him.
            Assert.IsTrue(robert.Followers.Contains(tim));

        }

        [TestMethod]
        public void Student1_Follows_Student_2_Int_Overload()
        {
            //  Arrange
            //  -------
            TestDb testContext = new TestDb();

            //  instantiate the repository class
            UserRepository repository = new UserRepository(testContext);

            //  Tim is Student no 7, Robert is Student no 3.
            int robertsId = 3;
            int timsId = 7;

            //  Action
            //  ------
            //  Set Tim to Follow Robert, only setting the one side
            repository.FollowUser(timsId, robertsId);

            //  Retrieve who Tim is Following, and who is following Robert
            //  Get Tim
            User tim = testContext.Users.FirstOrDefault(s => s.Id == 7);
            //  Get Robert
            User robert = testContext.Users.FirstOrDefault(s => s.Id == 3);

            //  Assert
            //  ------
            // Tim follows Jim, Brian and Bartosz and now Robert should be added
            Assert.AreEqual(4, tim.Following.Count());
            //  Robert should be in Tim's collection of students he's following.
            Assert.IsTrue(tim.Following.Contains(robert));
            //  Only Tim should be following Robert
            Assert.AreEqual(1, robert.Followers.Count());
            //  Tim should be in Roberts collection of students following him.
            Assert.IsTrue(robert.Followers.Contains(tim));

        }

    }
}
