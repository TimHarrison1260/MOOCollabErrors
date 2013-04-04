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
    public class StudentUnFollowingTests
    {
        [TestMethod]
        public void Student1_UnFollows_Student2()
        {
            //  Arrange
            //  -------
            TestDb testContext = new TestDb();

            //  instantiate the repository class
            UserRepository repository = new UserRepository(testContext);

            //  Bartosz is Student no 6, Andrew is Student no 4.  Is already followin Jim, Brian and Bartosz
            //  Get Andrew
            User Andrew = new User();
            Andrew = testContext.Users.FirstOrDefault(s => s.Id == 4) as User;
            User Bartosz = new User();
            Bartosz = testContext.Users.FirstOrDefault(s => s.Id == 6) as User;
            //int BartoszsId = 7;
            string BartoszsName = "Bartoz";

            List<User> BartoszFollowingBefore = Bartosz.Following.ToList<User>();
            List<User> AndrewFollowersBefore = Andrew.Followers.ToList<User>();

            //  Action
            //  ------
            //  Set Bartosz to Follow Andrew, only setting the one side
            repository.FollowUser(BartoszsName, Andrew);

            //  Retrieve who Bartosz is Following, and who is following Andrew
            //  Get Bartosz
            Bartosz = testContext.Users.FirstOrDefault(s => s.Id == 6);
            //  Refresh Andrew
            Andrew = testContext.Users.FirstOrDefault(s => s.Id == 4);

            List<User> BartoszFollowingAndrew = Bartosz.Following.ToList<User>();
            List<User> AndrewFollowedByBartosz = Andrew.Followers.ToList<User>();

            //  Set Bartosz to unfollow Andrew
            repository.UnFollowUser(BartoszsName, Andrew);

            Bartosz = testContext.Users.FirstOrDefault(s => s.Id == 6);
            Andrew = testContext.Users.FirstOrDefault(s => s.Id == 4);

            List<User> BartoszStoppedFollowingAndrew = Bartosz.Following.ToList<User>();
            List<User> AndrewNoLongerFollowedByBartosz = Andrew.Followers.ToList<User>();

            //  Assert: before
            //  ------
            // Bartosz follows Jim, Brian and Bartosz and now Andrew should be added
            Assert.AreEqual(2, BartoszFollowingBefore.Count());
            //  Andrew should be in Bartosz's collection of students he's following.
            Assert.IsFalse(BartoszFollowingBefore.Contains(Andrew));
            //  Only Bartosz should be following Andrew
            Assert.AreEqual(0, AndrewFollowersBefore.Count());
            //  Bartosz should be in Andrews collection of students following him.
            Assert.IsFalse(AndrewFollowersBefore.Contains(Bartosz));

            //  Assert: following
            //  -------
            // Bartosz follows Jim, Brian and Bartosz and now Andrew should be added
            Assert.AreEqual(3, BartoszFollowingAndrew.Count());
            //  Andrew should be in Bartosz's collection of students he's following.
            Assert.IsTrue(BartoszFollowingAndrew.Contains(Andrew));
            //  Only Bartosz should be following Andrew
            Assert.AreEqual(1, AndrewFollowedByBartosz.Count());
            //  Bartosz should be in Andrews collection of students following him.
            Assert.IsTrue(AndrewFollowedByBartosz.Contains(Bartosz));

            //  Assert: unfollowing
            //  ------
            // Bartosz follows Jim, Brian and Bartosz and now Andrew should be added
            Assert.AreEqual(2, BartoszStoppedFollowingAndrew.Count());
            //  Andrew should be in Bartosz's collection of students he's following.
            Assert.IsFalse(BartoszStoppedFollowingAndrew.Contains(Andrew));
            //  Only Bartosz should be following Andrew
            Assert.AreEqual(0, AndrewNoLongerFollowedByBartosz.Count());
            //  Bartosz should be in Andrews collection of students following him.
            Assert.IsFalse(AndrewNoLongerFollowedByBartosz.Contains(Bartosz));

        }
    }
}
