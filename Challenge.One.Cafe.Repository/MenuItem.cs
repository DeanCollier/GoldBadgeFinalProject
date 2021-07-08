using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOneCafe_Repository
{
    public class MenuItem
    { 
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }
        
        public MenuItem() { }
        public MenuItem(int mealNumber, string mealName, string mealDescription, List<string> ingredients, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
