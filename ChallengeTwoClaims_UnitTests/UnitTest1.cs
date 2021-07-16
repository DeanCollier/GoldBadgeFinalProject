using ChallengeTwoClaims_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeTwoClaims_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private IClaimRepo _repo = new ClaimRepo();

        [TestInitialize]
        public void Seed()
        {
            var claimID = 1;
            var claimType = TypeOfClaim.Car;
            var description = "Car melted in lava";
            var claimAmount = 5000m;
            var dateOfIncident = new DateTime(2021,6,13);
            var dateOfClaim = new DateTime(2021,7,10);

            var firstClaim = new Claim(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim);
            _repo.AddNewClaim(firstClaim);

            claimID = 2;
            claimType = TypeOfClaim.Home;
            description = "Home exploded randomly";
            claimAmount = 350000m;
            dateOfIncident = new DateTime(2020,4,20);
            dateOfClaim = new DateTime(2020,4,22);

            var secondClaim = new Claim(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim);
            _repo.AddNewClaim(secondClaim);
        }
        [TestMethod]
        public void CreateClaimInRepo_ShouldAddToClaimList()
        {
            var claimID = 3;
            var claimType = TypeOfClaim.Theft;
            var description = "Someone stole my computer";
            var claimAmount = 1000m;
            var dateOfIncident = new DateTime(2021,5,13);
            var dateOfClaim = new DateTime(2021,7,10);
            var itemAdded = false;
            var testClaim = new Claim(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim);
            
            itemAdded = _repo.AddNewClaim(testClaim);

            Assert.IsTrue(itemAdded);
        }
        [TestMethod]
        public void GetAllClaimsInRepo_ShouldReturnEntireListOfClaims()
        {
            int count = _repo.GetAllClaims().Count;

            Assert.AreEqual(2, count);
        }
        [TestMethod]
        public void GetClaimByID_ShouldReturnSpecificClaim()
        {
            int claimID = 2;
            Claim testClaim = new Claim();

            testClaim = _repo.GetClaimByID(claimID); 

            Assert.AreEqual(claimID, testClaim.ClaimID);
        }
        [TestMethod]
        public void DeleteClaimByNumber_ShouldRemoveClaimFromRepoList()
        {
            int claimID = 1;
            bool isDeleted = false;

            isDeleted = _repo.DeleteClaimByID(claimID);

            Assert.IsTrue(isDeleted);
        }
        [TestMethod]
        public void DeleteClaim_ShouldDeleteClaimFromRepoList()
        {
            bool isDeletd = false;
            Claim testClaim = new Claim();
            _repo.AddNewClaim(testClaim); //already tested

            isDeletd = _repo.DeleteClaim(testClaim);

            Assert.IsTrue(isDeletd);
        }
    }
}
