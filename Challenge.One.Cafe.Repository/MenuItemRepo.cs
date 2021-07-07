using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.One.Cafe.Repository
{
    public class MenuItemRepo
    {
        private readonly List<MenuItem> _menu = new List<MenuItem>();
        //create
        public bool AddMenuItem(MenuItem menuItem)
        {
            _menu.Add(menuItem);
            return (_menu.Contains(menuItem));
        }
        //read
        public List<MenuItem> GetAllMenuItems() => _menu;
        public MenuItem GetMenuItemByNumber(int mealNumber)
        {
            foreach (var menuItem in _menu)
            {
                if (menuItem.MealNumber == mealNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }

        //No need to update menu items right now
        //SomeKindOfUpdateMethdos()

        //delete
        public bool DelelteMenuItem(MenuItem itemToDelete)
        {
            _menu.Remove(itemToDelete);
            return !(_menu.Contains(itemToDelete));
        }
        public bool DeleteMenuItemByNumber(int mealNumber)
        {
            foreach (var menuItem in _menu)
            {
                if (menuItem.MealNumber == mealNumber)
                {
                    return DelelteMenuItem(menuItem);
                }
            }
            return false;
        }



    }
}
