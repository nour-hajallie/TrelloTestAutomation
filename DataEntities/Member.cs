using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloTestAutomation.DataEntities
{
    public class Member
    {
        public string id { get; set; }
        public bool activityBlocked { get; set; }
        public object avatarHash { get; set; }
        public object avatarUrl { get; set; }
        public bool confirmed { get; set; }
        public string fullName { get; set; }
        public object idMemberReferrer { get; set; }
        public string initials { get; set; }
        public string memberType { get; set; }
        public NonPublic nonPublic { get; set; }
        public bool nonPublicAvailable { get; set; }
        public string username { get; set; }
    }
}
