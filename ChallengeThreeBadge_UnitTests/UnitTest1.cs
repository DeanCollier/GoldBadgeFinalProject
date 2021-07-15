using ChallengeThreeBadge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThreeBadge_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private IBadgeRepo _repo = new BadgeRepo();
        [TestInitialize]
        private void Seed()
        {
            var badgeID = 111;
            var employeeName = "Mr. Test Guy";
            var accessDoors = new List<string> { "A1", "A2" };
            

        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
