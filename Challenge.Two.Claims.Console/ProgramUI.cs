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
                    DisplayAllClaims();
                    break;
                case "2":
                    TakeCareOfNextClaim();
                    break;
                case "3":
                    AddNewClaim();
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
        private void DisplayAllClaims()
        {
            int rows = _repo.GetAllClaims().Count;
            PrintLine();
            Console.WriteLine(string.Format("|{0,-10}|{1,-10}|{2,-30}|{3,-15}|{4,-14}|{5,-11}|{6,-7}|", "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid"));
            PrintLine();
            foreach (var claim in _repo.GetAllClaims())
            {
                Console.WriteLine(string.Format("|{0,-10}|{1,-10}|{2,-30}|{3,-15}|{4,-14}|{5,-11}|{6,-7}|", claim.ClaimID, claim.ClaimType, claim.Description, "$" + claim.ClaimAmount, claim.DateOfIncident.ToString("d"), claim.DateOfClaim.ToString("d"), claim.IsValid));
                PrintLine();
            }
            PressKeyToReturnMainMenu();
        }
        private void PrintLine()
        {
            Console.WriteLine(new string('-', 105));
        }
        private void TakeCareOfNextClaim()
        {
            Claim nextClaim = _repo.GetAllClaims()[0];
            int claimID = nextClaim.ClaimID;
            Console.WriteLine("This is the next claim in the queue:");
            DisplayClaim(nextClaim);
            PrintLine();
            Console.WriteLine("Would you like to deal with this claim now? (y/n)");
            DeleteClaimFromList(claimID);
            PressKeyToReturnMainMenu();
            
        }
        private void DeleteClaimFromList(int claimID)
        {
            string input = Console.ReadLine().ToLower();
            if ( input == "y")
            {
                _repo.DeleteClaimByID(claimID);
                Console.WriteLine("Claim has be delt with and removed from the queue.");
            }
            else if(input == "n")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid input.");
                return;
            }

        }
        private void DisplayClaim(Claim displayClaim)
        {
            Console.WriteLine($"ClaimID: {displayClaim.ClaimID}\n" +
                              $"Claim Type: {displayClaim.ClaimType}\n" +
                              $"Description: {displayClaim.Description}\n" +
                              $"Amount: {displayClaim.ClaimAmount}\n" +
                              $"DateOfAccident: {displayClaim.DateOfIncident.ToString("d")}\n" +
                              $"DateOfClaim: {displayClaim.DateOfClaim.ToString("d")}\n" +
                              $"IsValid: {displayClaim.IsValid}");
        }
        private void AddNewClaim()
        {
            Console.WriteLine("Add a new claim: ");
            int claimID = EnterNewClaimID();
            TypeOfClaim claimType = EnterNewClaimType(claimID);
            string desc = EnterNewClaimDescription(claimID);
            decimal amount = EnterNewClaimAmount(claimID);
            DateTime dateOfAccident = EnterNewAccidentDate(claimID);
            DateTime dateOfClaim = EnterNewClaimDate(claimID);

            bool claimAdded = false;
            Claim newClaim = new Claim(claimID, claimType, desc, amount, dateOfAccident, dateOfClaim);
            claimAdded = _repo.AddNewClaim(newClaim);
            if (claimAdded)
            {
                Console.WriteLine("This claim has been added:");
                DisplayClaim(newClaim);
                PressKeyToReturnMainMenu();
            }
            else
            {
                Console.WriteLine("An error occured...");
                PressKeyToReturnMainMenu();
            }
        }
        private int EnterNewClaimID()
        {
            Console.WriteLine("Enter an ID number for this claim: ");
            string claimID = IsThisCorrect(Console.ReadLine().ToLower());
            bool claimExists = false;
            foreach (var claim in _repo.GetAllClaims())
            {
                if (int.Parse(claimID) == claim.ClaimID)
                {
                    claimExists = true;
                }
            }
            if (claimExists)
            {
                Console.WriteLine("That claimID already exists\n" +
                                  "Enter a different claimID: ");
                claimID = Console.ReadLine();
            }
            return int.Parse(claimID);
        }
        private TypeOfClaim EnterNewClaimType(int claimID)
        {
            Console.WriteLine($"What type of claim is {claimID}?");
            Dictionary<int, string> days = Enum.GetValues(typeof(TypeOfClaim))
                                        .Cast<TypeOfClaim>()
                                        .ToDictionary(v => (int)v, k => k.ToString());

            Console.WriteLine(String.Join(Environment.NewLine, days));
            int claimType = int.Parse(IsThisCorrect(Console.ReadLine().ToLower()));
            return (TypeOfClaim)claimType;

        }
        private string EnterNewClaimDescription(int claimID)
        {
            Console.WriteLine($"Describe claim {claimID}?");
            string desc = IsThisCorrect(Console.ReadLine().ToLower());
            return desc;
        }
        private decimal EnterNewClaimAmount(int claimID)
        {
            Console.WriteLine($"How much is claim {claimID}?");
            string amount = IsThisCorrect(Console.ReadLine().ToLower());
            return decimal.Parse(amount);
        }
        private DateTime EnterNewAccidentDate(int claimID)
        {
            Console.WriteLine("Enter the date of the accident: (mm/dd/yyyy)");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);
            date = DateTime.ParseExact(IsThisCorrect(date.ToString("MM/dd/yyyy")), "MM/dd/yyyy", null);
            return date;
        }
        private DateTime EnterNewClaimDate(int claimID)
        {
            Console.WriteLine("Enter the date of the claim: (mm/dd/yyyy)");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", null);
            date = DateTime.ParseExact(IsThisCorrect(date.ToString("MM/dd/yyyy")), "MM/dd/yyyy", null);
            return date;
        }
        //------------------------------------------------------------------------------------------------------------------------
        private string IsThisCorrect(string thingToCheck)
        {
            Console.WriteLine($"Is this correct? (y/n)\n" +
                               thingToCheck);
            string answer = Console.ReadLine().ToLower();
            while (answer != "y")
            {
                Console.WriteLine("Let's try that again.");
                thingToCheck = Console.ReadLine().ToLower();
                Console.WriteLine($"Is this correct? (y/n)\n" +
                               thingToCheck);
                answer = Console.ReadLine().ToLower();
            }
            return thingToCheck;
        }
        private void PressKeyToReturnMainMenu()
        {
            Console.WriteLine("Press any key to return to the main menu... ");
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
            var dateOfIncident = new DateTime(2021, 6, 13);
            var dateOfClaim = new DateTime(2021, 8, 10);

            var firstClaim = new Claim(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim);
            _repo.AddNewClaim(firstClaim);

            claimID = 2;
            claimType = TypeOfClaim.Home;
            description = "Home exploded randomly";
            claimAmount = 350000m;
            dateOfIncident = new DateTime(2020, 4, 20);
            dateOfClaim = new DateTime(2020, 4, 22);

            var secondClaim = new Claim(claimID, claimType, description, claimAmount, dateOfIncident, dateOfClaim);
            _repo.AddNewClaim(secondClaim);
        }
    }
}
