
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
            switch (userInput)
            {
                case "1":
                    AddMenuItem();
                    break;
                case "2":
                    DeleteMenuItem();
                    break;
                case "3":
                    DisplayAllMenuItems();
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

        private void AddMenuItem()
        {
            Console.WriteLine("Adding New Menu Item");
            string mealName = EnterNewItemName();
            string mealDesc = EnterNewItemDescription(mealName);
            List<string> ingredients = EnterNewItemIngredients(mealName);
            decimal price = EnterNewItemPrice(mealName);
            int mealNumber = EnterNewItemNumber(mealName);

            MenuItem newItem = new MenuItem(mealNumber, mealName, mealDesc, ingredients, price);
            bool result = _repo.AddMenuItem(newItem);
            if (result)
            {
                Console.WriteLine("Your menu item has been added! ");
                PressKeyToReturnMainMenu();
            }
            else
            {
                Console.WriteLine("Something went wrong, item not added.");
                PressKeyToReturnMainMenu();
            }
        }
        private string EnterNewItemName()
        {
            Console.WriteLine("Enter name of new menu item:");
            string mealName = IsThisCorrect(Console.ReadLine().ToLower());
            return mealName;
        }
        private string EnterNewItemDescription(string mealName)
        {
            Console.WriteLine($"Enter a description for {mealName}:");
            string mealDesc = IsThisCorrect(Console.ReadLine().ToLower());
            return mealDesc;
        }
        private List<string> EnterNewItemIngredients(string mealName)
        {
            List<string> ingredientList = new List<string>();
            Console.WriteLine($"Seperately enter each ingredient in {mealName}.  Press 'ENTER' again when done: ");
            string ingredient;
            while ((ingredient = Console.ReadLine().ToLower()) != "")
            {
                ingredientList.Add(ingredient);
            }
            return ingredientList;
        }
        private decimal EnterNewItemPrice(string mealName)
        {
            Console.WriteLine($"How much will {mealName} cost?");
            string mealNumber = IsThisCorrect(Console.ReadLine().ToLower());
            return decimal.Parse(mealNumber);
        }
        private int EnterNewItemNumber(string mealName)
        {
            Console.WriteLine($"Enter the menu item number for {mealName}:");
            string mealNumber = Console.ReadLine().ToLower();
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
            return int.Parse(mealNumber);
        }

        //------------------------------------------------------------------------------------------------------------------------------
        private void DeleteMenuItem()
        {
            Console.WriteLine("What menu item would you like to delete?");
            foreach (var menuItem in _repo.GetAllMenuItems())
            {
                Console.WriteLine($" {menuItem.MealNumber}. {menuItem.MealName} ");
            }
            string input = Console.ReadLine().ToLower();
            input = IsThisCorrect(input);
            bool result = _repo.DeleteMenuItemByNumber(int.Parse(input));
            if (result)
            {
                Console.WriteLine("Menu item has been removed");
                PressKeyToReturnMainMenu();
            }
            else
            {
                Console.WriteLine("Something went wrong, item not removed.");
                PressKeyToReturnMainMenu();
            }
        }
        private void DisplayAllMenuItems()
        {
            foreach (var menuItem in _repo.GetAllMenuItems())
            {
                Console.WriteLine($"Item Number: {menuItem.MealNumber}\n" +
                                  $"Item Name: {menuItem.MealName}\n" +
                                  $"Item Description: {menuItem.MealDescription}\n" +
                                  $"Ingredients: {string.Join(", ",menuItem.Ingredients)}\n" +
                                  $"Price: {menuItem.Price}\n" +
                                  $"");
            }
            PressKeyToReturnMainMenu();
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
            Console.Clear();
            RunMenu();
        }
        private void Seed()
        {
            var mealNumber = 1;
            var mealName = "Bull TEST-icles";
            var mealDescription = "This is a test desription, yum!";
            var ingredients = new List<string> { "list", "of", "test", "ingredients" };
            var price = 10.95m;

            var firstItem = new MenuItem(mealNumber, mealName, mealDescription, ingredients, price);
            _repo.AddMenuItem(firstItem);

            mealNumber = 2;
            mealName = "In-TEST-ines";
            mealDescription = "Wow, that's some good test puns!";
            ingredients = new List<string> { "some", "other", "test", "ingredients" };
            price = 12.49m;

            var secondItem = new MenuItem(mealNumber, mealName, mealDescription, ingredients, price);
            _repo.AddMenuItem(secondItem);
        }





    }
}
