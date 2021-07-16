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
            BadgeRepo _repoType = new BadgeRepo();
            ProgramUI ui = new ProgramUI(_repoType);
            ui.Start();

        }
    }
}
