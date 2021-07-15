using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeBadge_Repository
{
    public interface IBadgeRepo
    {
        bool AddNewBadge(Badge badgeToAdd);
        Dictionary<int, Badge> GetAllBadges();
        Badge GetBadgeByID(int badgeID);
        Badge UpdateBadgeDoorAccess(int badgeID, List<string> accessDoors);
        bool DeleteBadgeByID(int badgeID);
    }
}
