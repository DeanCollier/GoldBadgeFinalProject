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
                    Console.Clear();
                    DisplayAllBadges();
                    PressKeyToReturnMainMenu();
                    return;
                case "2":
                    Console.Clear();
                    UpdateDoorAccess();
                    PressKeyToReturnMainMenu();
                    return;
                case "3":
                    Console.Clear();
                    DeleteBadgeDoorAccess();
                    PressKeyToReturnMainMenu();
                    return;
                case "4":
                    Console.Clear();
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
            Console.WriteLine("Current badges in system: ");
            foreach (var dictItem in _repo.GetAllBadges())
            {
                DisplayBadgeByID(dictItem.Value.BadgeID);
            }
            
        }
        private void DisplayBadgeByID(int badgeID)
        {
            bool exists = false;
            foreach (var badge in _repo.GetAllBadges())
            {
                if (badge.Key == badgeID)
                {
                    exists = true;
                }
            }
            if (exists)
            {
                Console.WriteLine($"BadgeID: {_repo.GetBadgeByID(badgeID).BadgeID}\n" +
                              $"DoorAcces: {string.Join(",", _repo.GetBadgeByID(badgeID).AccessDoors)}");
                Console.WriteLine("");
                return;
            }
            else
            {
                Console.WriteLine($"Badge {badgeID} does not exist.");
                PressKeyToReturnMainMenu();
            }

            
        }
        private void UpdateDoorAccess()
        {
            Console.WriteLine("*UPDATE BADGE DOOR ACCESS*");
            Console.WriteLine("Do you want to: \n" +
                              "1. Delete door/s access from a badge?\n" +
                              "2. Add door/s access to a badge?");
            string updateChoice = Console.ReadLine();
            switch (updateChoice)
            {
                case "1":
                    Console.Clear();
                    DeleteSpecificDoors();
                    return;
                case "2":
                    Console.Clear();
                    AddSpecificDoors();
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input...");
                    return;
            }
        }
        private void DeleteSpecificDoors()
        {
            Console.WriteLine("*DELETE DOOR ACCESS*");
            DisplayAllBadges();
            Console.WriteLine("Which badge would you like to delete door/s from? (Enter Badge ID#)");
            string badgeIDString = Console.ReadLine();
            badgeIDString = IsThisCorrect(badgeIDString);
            int badgeID = int.Parse(badgeIDString);
            Console.Clear();

            DisplayBadgeByID(badgeID);
            Console.WriteLine("What doors would you like to delete from this badge?");
            List<string> doorsToDelete = GetDoorList(badgeID);
            if (DeleteSpecificDoorsByBadgeID(badgeID, doorsToDelete))
            {
                Console.Clear();
                Console.WriteLine($"Doors removed from {badgeID}.");
                DisplayBadgeByID(badgeID);
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input...");
                return;
            }


        }
        private void AddSpecificDoors()
        {
            Console.WriteLine("*ADD DOOR ACCESS*");
            DisplayAllBadges();
            Console.WriteLine("Which badge would you like to add door/s to? (Enter Badge ID#)");
            string badgeIDString = Console.ReadLine();
            badgeIDString = IsThisCorrect(badgeIDString);
            int badgeID = int.Parse(badgeIDString);
            Console.Clear();

            DisplayBadgeByID(badgeID);
            Console.WriteLine("What doors would you like to add to this badge?");
            List<string> doorsToAdd = GetDoorList(badgeID);
            if (AddSpecificDoorsByBadgeID(badgeID, doorsToAdd))
            {
                Console.Clear();
                Console.WriteLine($"Doors added to {badgeID}.");
                DisplayBadgeByID(badgeID);
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid input...");
                return;
            }
        }
        private List<string> GetDoorList(int badgeID)
        {
            bool moreDoors = true;
            List<string> doorList = new List<string>();
            string doorChoice;
            while (moreDoors)
            {
                Console.WriteLine("Enter door name: ");
                doorChoice = Console.ReadLine();
                doorList.Add(doorChoice.ToUpper());
                Console.WriteLine("Any other doors? (y/n)");
                if (Console.ReadLine() == "n")
                {
                    moreDoors = false;
                }
            }
            return doorList;

        }
        private bool DeleteSpecificDoorsByBadgeID(int badgeID, List<string> doorDeleteList)
        {
            List<string> updateDoorList = new List<string>();
            foreach (var door in _repo.GetBadgeByID(badgeID).AccessDoors)
            {
                if (!doorDeleteList.Contains(door))
                {
                    updateDoorList.Add(door);
                }
            }
            return _repo.UpdateBadgeDoorAccess(badgeID, updateDoorList);
        }
        private bool AddSpecificDoorsByBadgeID(int badgeID, List<string> doorAddList)
        {
            List<string> updateDoorList = _repo.GetBadgeByID(badgeID).AccessDoors;
            foreach (var door in doorAddList)
            {
                if (!_repo.GetBadgeByID(badgeID).AccessDoors.Contains(door))
                {
                    updateDoorList.Add(door);
                }
            }
            return _repo.UpdateBadgeDoorAccess(badgeID, updateDoorList);
        }
        private void DeleteBadgeDoorAccess()
        {
            Console.WriteLine("*DELETE ALL DOOR ACCESS FROM BADGE*");
            DisplayAllBadges();
            Console.WriteLine("Which badge ID would you like to delete? (Enter Badge ID#): ");
            string badgeIDString = Console.ReadLine();
            badgeIDString = IsThisCorrect(badgeIDString);
            int badgeID = int.Parse(badgeIDString);
            if (DeleteAllDoorsByBadgeID(badgeID))
            {
                Console.Clear();
                Console.WriteLine($"All door access for badge {badgeID} has been deleted: ");
                DisplayBadgeByID(badgeID);
            }
            else
            {
                Console.WriteLine("Something went wrong :/");
            }
        }
        private bool DeleteAllDoorsByBadgeID(int badgeID)
        {
            List<string> emptyList = new List<string>();
            return _repo.UpdateBadgeDoorAccess(badgeID, emptyList);
        }
        //---------------------------------------------------------------------------------------------
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
