using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwoClaims_Repository
{
    public class ClaimRepo : IClaimRepo
    {   
        private readonly List<Claim> _claims = new List<Claim>();

        public bool AddNewClaim(Claim claimToAdd)
        {
            _claims.Add(claimToAdd);
            return _claims.Contains(claimToAdd);
        }
        public List<Claim> GetAllClaims() => _claims;
        public Claim GetClaimByID(int claimID)
        {
            foreach (var claim in _claims)
            {
                if(claim.ClaimID == claimID)
                {
                    return claim;
                }
            }
            return null;
        }
        //doesn't look like this assignment needs any updating methods
        //SomeUpdateMethods();
        public bool DeleteClaim(Claim claimToDelete)
        {
            return _claims.Remove(claimToDelete);
        }
        public bool DeleteClaimByID(int claimID)
        {
            Claim claimToDelete = new Claim();
            foreach (var claim in _claims)
            {
                if (claim.ClaimID == claimID)
                {
                    claimToDelete = claim;
                }
            }
            return DeleteClaim(claimToDelete);
        }
    }
}
