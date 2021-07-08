using Challenge.One.Cafe.Repository;
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

        private void OpenMenuItem(string userInput)
        {
            Console
        }

        private string GetMenuSelection()
        {
            throw new NotImplementedException();
        }
    }
}
