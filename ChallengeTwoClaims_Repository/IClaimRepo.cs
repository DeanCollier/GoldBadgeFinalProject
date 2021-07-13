using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoClaims_Repository
{
    public interface IClaimRepo
    {
        bool AddNewClaim(Claim claimToAdd);
        List<Claim> GetAllClaims();
        Claim GetClaimByID(int claimID);
        bool DeleteClaim(Claim claimToDelete);
        bool DeleteClaimByID(int claimID);
    }
}
