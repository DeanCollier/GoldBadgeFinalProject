using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.One.Cafe.Repository
{
    public class MenuItem
    { 
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> ListOfIngredients { get; set; }
        public decimal Price { get; set; }
        
        public MenuItem() { }
        public MenuItem(int mealNumber, string mealName, string mealDescription, List<string> listOfIngredients, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            ListOfIngredients = listOfIngredients;
            Price = price;
        }
    }
}
