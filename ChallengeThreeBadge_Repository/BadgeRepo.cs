using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeBadge_Repository
{
    public class BadgeRepo : IBadgeRepo
    {
        private readonly Dictionary<int, Badge> _badges = new Dictionary<int, Badge>();

        public bool AddNewBadge(Badge badgeToAdd)
        {
            _badges.Add(badgeToAdd.BadgeID, badgeToAdd);
            return _badges.ContainsKey(badgeToAdd.BadgeID);
        }

        public Dictionary<int, Badge> GetAllBadges() => _badges;

        public Badge GetBadgeByID(int badgeID)
        {
            foreach (var dictItem in _badges)
            {
                if (dictItem.Key == badgeID)
                {
                    return dictItem.Value;
                }
            }
            return null;
        }

        public bool UpdateBadgeDoorAccess(int badgeID, List<string> accessDoors)
        {
            if (GetBadgeByID(badgeID) != null)
            {
                _badges[badgeID].AccessDoors = accessDoors;
                return true;
            }
            return false;
            
        }

        public bool DeleteBadgeByID(int badgeID)
        {
            return _badges.Remove(badgeID);
        }
    }
}
