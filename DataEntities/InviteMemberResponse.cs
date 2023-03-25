using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloTestAutomation.DataEntities
{
    public class InviteMemberResponse
    {
        public string id { get; set; }
        public List<Member> members { get; set; }
        public List<Membership> memberships { get; set; }
    }
}
