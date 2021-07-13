using ChallengeTwoClaims_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoClaims_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IClaimRepo repoType = new ClaimRepo();
            ProgramUI _userInterface = new ProgramUI(repoType);
            _userInterface.Start();
        }
    }
}
