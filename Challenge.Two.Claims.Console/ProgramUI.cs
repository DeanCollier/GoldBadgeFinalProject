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
        private string GetMenuSelection()
        {
            Console.WriteLine("Welcome to Komodo's Claim Menu.\n" +
                              "Select a menu option:\n" +
                              "1. See all claims\n" +
                              "2. Take care of next claim\n" +
                              "3. Enter a new claim\n" +
                              "4. Exit");
            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            switch (userInput)
            {
                case "1":
                    //DisplayAllClaims();
                    break;
                case "2":
                    //TakeCareOfNextClaim();
                    break;
                case "3":
                    //AddNewClaim();
                    break;
                case "4":
                    isRunning = false;
                    return;
                default:
                    Console.WriteLine("Invalid Selection.");
                    PressKeyToReturnMainMenu();
                    return;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        private void PressKeyToReturnMainMenu()
        {
            Console.WriteLine("Press any key to return to the main menu: ");
            Console.ReadKey();
            Console.Clear();
            RunMenu();
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
