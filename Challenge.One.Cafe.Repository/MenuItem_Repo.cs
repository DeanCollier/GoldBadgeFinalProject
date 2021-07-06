using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.One.Cafe.Repository
{
    class MenuItem_Repo
    {
        List<MenuItem> _menu = new List<MenuItem>();
        //create
        public bool AddMenuItem(MenuItem menuItem)
        {
            _menu.Add(menuItem);
            return (_menu.Contains(menuItem));
        }
        //read
        public List<MenuItem> GetAllMenuItems() => _menu;
        public MenuItem GetMenuItemByNumber(int mealNumer)
        {
            foreach (var menuItem in _menu)
            {
                if (menuItem.MealNumber == mealNumer)
                {
                    return menuItem;
                }
            }
            return null;
        }

        //No need to update menu items right now
        //SomeKindOfUpdateMethdos()

        //delete
        public bool DeleteMenuItemByNumber(int mealNumber)
        {
            foreach (var menuItem in _menu)
            {
                if (menuItem.MealNumber == mealNumber)
                {
                    _menu.Remove(menuItem);
                    return !(_menu.Contains(menuItem));
                }
            }
            return false;
        }



    }
}
