
using ChallengeOneCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneCafe_Console
{
    public class ProgramUI
    {
        private bool isRunning = true;

        private readonly MenuItemRepo _repo = new MenuItemRepo();

        public void Start()
        {
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
            Console.WriteLine("Welcome to Komodo Cafe's Menu.\n" +
                              "Select a menu option:\n" +
                              "1. Add New Menu Item\n" +
                              "2. Delete Current Menu Item\n" +
                              "3. View All Menu Items\n" +
                              "4. Exit");
            string userInput = Console.ReadLine();
            return userInput;
        }
        private void OpenMenuItem(string userInput)
        {
            Console.Clear();
            int userChoice = int.Parse(userInput);
            switch (userChoice)
            {
                case 1:
                    AddMenuItem();
                    break;
                case 2:
                    DeleteMenuItem();
                    break;
                case 3:
                    DisplayAllMenuItems();
                    break;
                case 4:
                    isRunning = false;
                    return;
                default:
                    Console.WriteLine("Invalid Selection.");
                    PressKeyToReturnMainMenu();
                    return;
            }
        }

        private void AddMenuItem()
        {
            Console.WriteLine("Adding New Menu Item");
            string mealName = EnterNewItemName();
            string mealDesc = EnterNewItemDescription(mealName);
            List<string> ingredients = EnterNewItemIngredients(mealName);
            decimal price = EnterNewItemPrice(mealName);
            int mealNumber = EnterNewItemNumber(mealName);




        }
        private string EnterNewItemName()
        {
            Console.WriteLine("Enter name of new menu item:");
            string mealName = Console.ReadLine().ToLower();
            mealName = IsThisCorrect(mealName);
            return mealName;
        }
        private string EnterNewItemDescription(string mealName)
        {
            Console.WriteLine($"Enter a description for " + mealName + ":");
            string mealDesc = Console.ReadLine().ToLower();
            mealDesc = IsThisCorrect(mealDesc);
            return mealDesc;
        }
        private List<string> EnterNewItemIngredients(string mealName)
        {
            List<string> ingredientList = new List<string>();
            Console.WriteLine($"Seperately enter each ingredient in " + mealName + ".  Press 'ENTER' twice when done: ");
            string ingredient;
            while ((ingredient = Console.ReadLine().ToLower()) != "")
            {
                ingredientList.Add(ingredient);
            }
            if (!IsThisCorrect(String.Join(", ", ingredientList)))
            {
                EnterNewItemIngredients(mealName);
            }
            Console.Clear();
            return ingredientList;
        }
        private decimal EnterNewItemPrice(string mealName)
        {
            Console.WriteLine($"How much will " + mealName + " cost?");
            string mealNumber = Console.ReadLine().ToLower();
            mealNumber = IsThisCorrect(mealNumber);
            return decimal.Parse(mealNumber);
        }
        private int EnterNewItemNumber(string mealName)
        {
            Console.WriteLine($"Enter the menu item number for " + mealName + ":");
            string mealNumber = Console.ReadLine().ToLower();
            bool temp = true;
            while (temp)
            {
                foreach (var menuItem in _repo.GetAllMenuItems())
                {
                    if (int.Parse(mealNumber) == menuItem.MealNumber)
                    {
                        Console.WriteLine("That menu item number is already being used.\n" +
                                          "Enter a different menu item number:");
                        mealNumber = Console.ReadLine().ToLower();
                    }
                }
                mealNumber = IsThisCorrect(mealNumber);
                temp = false;
            }

            return int.Parse(mealNumber);
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private void DeleteMenuItem()
        {
            throw new NotImplementedException();
        }
        private void DisplayAllMenuItems()
        {
            throw new NotImplementedException();
        }
        //-----------------------------------------------------------------------------------------------------------------------------
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
            Console.WriteLine("Press any key to return to the main menu: ");
            Console.ReadKey();
            RunMenu();
        }






    }
}
