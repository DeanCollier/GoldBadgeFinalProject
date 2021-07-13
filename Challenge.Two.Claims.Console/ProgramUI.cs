using ChallengeTwoClaims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoClaims_Console
{
    class ProgramUI
    {
        bool isRunning = true;
        private readonly IClaimRepo _repo;
        public ProgramUI(IClaimRepo repoType)
        {
            _repo = repoType;
        }
        

        public void Start()
        {
            Seed();
            RunMenu();
        }
        private void RunMenu()
        {
            while (isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

        private void OpenMenuItem(string userInput)
        {
            throw new NotImplementedException();
        }

        private string GetMenuSelection()
        {
            return Console.ReadLine();
        }

        private void Seed()
        {
            var claimID = 1;
            var claimType = TypeOfClaim.Car;
            var description = "Car melted in lava";
            var claimAmount = 5000m;
            var dateOfIncident = new DateTime(6 / 13 / 2021);
            var dateOfClaim = new DateTime(8 / 10 / 2021);

            var firstClaim = new Claim(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim);
            _repo.AddNewClaim(firstClaim);

            claimID = 2;
            claimType = TypeOfClaim.Home;
            description = "Home exploded randomly";
            claimAmount = 350000m;
            dateOfIncident = new DateTime(4 / 20 / 2020);
            dateOfClaim = new DateTime(4 / 22 / 2020);

            var secondClaim = new Claim(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim);
            _repo.AddNewClaim(secondClaim);
        }
    }
}
