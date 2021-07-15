using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeBadge_Repository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> AccessDoors { get; set; }
        public string EmployeeName { get; set; }

        public Badge(int badgeID, List<string> accessDoors, string employeeName)
        {
            BadgeID = badgeID;
            AccessDoors = accessDoors;
            EmployeeName = employeeName;
        }
        public Badge() { }
    }
}
