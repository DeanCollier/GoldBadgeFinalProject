using ChallengeThreeBadge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeBadge_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IBadgeRepo _repo = new BadgeRepo();
            Badge test = new Badge(222, new List<string> { "q", "e" }, "name");
            _repo.AddNewBadge(test);
            Badge getBadge = new Badge();

            getBadge = _repo.GetBadgeByID(222);

            Console.WriteLine(getBadge.BadgeID);
            Console.WriteLine(string.Join(",",getBadge.AccessDoors));
            Console.WriteLine(getBadge.EmployeeName);
            Console.ReadKey();

        }
    }
}
