
using ChallengeOneCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeOneCafe_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private MenuItemRepo _repo = new MenuItemRepo();

        [TestInitialize]
        public void Seed()
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
        [TestMethod]
        public void CreateMenuItemInRepo_ShouldAddToMenuList()
        {
            var mealNumber = 3;
            var mealName = "The Test Tube";
            var mealDescription = "Sounds sketchy, I'll eat it!";
            var ingredients = new List<string> { "more", "test", "ingredients" };
            var price = 10.95m;
            bool itemAdded = false;
            var itemToAdd = new MenuItem(mealNumber,mealName,mealDescription,ingredients,price);

            itemAdded = _repo.AddMenuItem(itemToAdd);

            Assert.IsTrue(itemAdded);
        }
        [TestMethod]
        public void GetAllMenuItems_ShouldReturnEntireListOfItems()
        {
            //should only be 2 menu items in the test _repo
            int count = _repo.GetAllMenuItems().Count;

            Assert.AreEqual(2, count);
        }
        [TestMethod]
        public void GetMenuItemByNumber_ShouldReturnMenuItemWithSpecificNumber()
        {
            int mealNumber = 1;
            MenuItem testItem = new MenuItem();
            testItem = _repo.GetMenuItemByNumber(mealNumber);

            Assert.AreEqual(mealNumber, testItem.MealNumber);
        }
        [TestMethod]
        public void DeleteMenuItemByNumber_ShouldDeleteMenuItemFromList()
        {
            int mealNumber = 2;
            bool itemDeleted = false;

            itemDeleted = _repo.DeleteMenuItemByNumber(mealNumber);

            Assert.IsTrue(itemDeleted);
        }
        [TestMethod]
        public void DeleteMenuItem_ShouldDeleteMenuItemFromList()
        {
            bool itemDeleted = false;
            MenuItem testItem = new MenuItem();
            _repo.AddMenuItem(testItem); //already tested above

            itemDeleted = _repo.DelelteMenuItem(testItem);

            Assert.IsTrue(itemDeleted);
        }
    }
}
