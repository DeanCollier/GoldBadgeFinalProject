using ChallengeThreeBadge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeBadge_Console
{
    class ProgramUI
    {
        private bool isRunning = true;
        private readonly IBadgeRepo _repo;
        public ProgramUI(IBadgeRepo repoType)
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
            Console.WriteLine("Komodo Insurance Badge System\n" +
                              "Select an option:\n" +
                              "1. Show all badges with door access\n" +
                              "2. Update door access on an existing badge\n" +
                              "3. Delete all doors from an existing badge\n" +
                              "4. Create a new badge\n" +
                              "5. Exit");
            return Console.ReadLine();
        }
        private void OpenMenuItem(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    DisplayAllBadges();
                    return;
                case "2":
                    return;
                case "3":
                    return;
                case "4":
                    return;
                case "5":
                    isRunning = false;
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input...");
                    PressKeyToReturnMainMenu();
                    return;
            }
        }
        private void DisplayAllBadges()
        {
            foreach (var dictItem in _repo.GetAllBadges())
            {
                DisplayBadgeByID(dictItem.Value.BadgeID);
            }
        }
        private void DisplayBadgeByID(int badgeID)
        {
            Console.WriteLine($"BadgeID: {_repo.GetBadgeByID(badgeID).BadgeID}\n" +
                              $"DoorAcces: {string.Join(",",_repo.GetBadgeByID(badgeID).AccessDoors)}");
            Console.WriteLine("");  
        }
        //---------------------------------------------------------------------------------------------
        private void PressKeyToReturnMainMenu()
        {
            Console.WriteLine("Press any key to return to the main menu... ");
            Console.ReadKey();
            Console.Clear();
            RunMenu();
        }
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
    }
}
