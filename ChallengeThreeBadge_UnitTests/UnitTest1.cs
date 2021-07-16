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
        public void Seed()
        {
            var badgeID = 111;
            var employeeName = "Mr. Test Guy";
            var accessDoors = new List<string> { "A1", "A2" };
            Badge firstBadge = new Badge(badgeID, accessDoors, employeeName);

            badgeID = 222;
            employeeName = "Ms. Tester";
            accessDoors = new List<string> { "B3", "B4" };
            Badge secondBadge = new Badge(badgeID, accessDoors, employeeName);

            _repo.AddNewBadge(firstBadge);
            _repo.AddNewBadge(secondBadge);
        }
        [TestMethod]
        public void AddNewBadge_ShouldReturnTrueAndAddBadgeToDictionary()
        {
            var badgeID = 333;
            var employeeName = "Mrs. Test Badge Person";
            var accessDoors = new List<string> { "G56", "F12" };
            Badge testBadge = new Badge(badgeID, accessDoors, employeeName);

            bool addedBadge = _repo.AddNewBadge(testBadge);

            Assert.IsTrue(addedBadge);

        }
        [TestMethod]
        public void GetAllBadges_ShouldReturnsDictionaryOfAllBadges()
        {
            var expectedCountFromSeeding = 2;
            Dictionary<int, Badge> testBadgeDictionary = new Dictionary<int, Badge>();

            testBadgeDictionary = _repo.GetAllBadges();
            var countOfTestDictionary = testBadgeDictionary.Count;

            Assert.AreEqual(expectedCountFromSeeding, countOfTestDictionary);
        }
        [TestMethod]
        public void GetBadgeByID_ShouldReturnBadgeOfGivenID()
        {
            var badgeIDToGet = 222;
            var expectedBadgeID = 222;
            var expectedEmployeeName = "Ms. Tester";
            var expectedAccessDoors = new List<string> { "B3", "B4" };
            Badge testBadge = new Badge(expectedBadgeID, expectedAccessDoors, expectedEmployeeName);
            var badgeFromGet = new Badge();
            badgeFromGet = _repo.GetBadgeByID(badgeIDToGet);
            var actualID = badgeFromGet.BadgeID;
            var actualDoors = badgeFromGet.AccessDoors;
            var actualName = badgeFromGet.EmployeeName;

            Assert.AreEqual(testBadge.BadgeID, badgeFromGet.BadgeID);
            Assert.AreEqual(string.Join(",", testBadge.AccessDoors), string.Join(",", badgeFromGet.AccessDoors));
            Assert.AreEqual(testBadge.EmployeeName, badgeFromGet.EmployeeName);

        }
        [TestMethod]
        public void UpdateBadgeDoorAccess_ShouldReplaceCurrentAccessListWithNewList()
        {
            var badgeID = 222;
            var accessDoors = new List<string> { "G6", "F11" };
            var testDoors = new List<string>();

            bool doorsUpdated = _repo.UpdateBadgeDoorAccess(badgeID, accessDoors);
            testDoors = _repo.GetBadgeByID(badgeID).AccessDoors;

            Assert.IsTrue(doorsUpdated);
            Assert.AreEqual(string.Join(",", accessDoors), string.Join(",", testDoors));
        }
        [TestMethod]
        public void DeleteBadgeByID_ShouldRemoveKeyAndBadgeFromDictionary()
        {
            bool isDeleted = _repo.DeleteBadgeByID(222);

            Assert.IsTrue(isDeleted);
        }
    }
}
