using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloTestAutomation.DataEntities
{
    public class Board
    {
        public string name { get; set; }
        public string desc { get; set; }
        public object descData { get; set; }
        public bool closed { get; set; }
        public object idOrganization { get; set; }
        public object limits { get; set; }
        public object pinned { get; set; }
        public string shortLink { get; set; }
        public List<object> powerUps { get; set; }
        public object dateLastActivity { get; set; }
        public List<object> idTags { get; set; }
        public object datePluginDisable { get; set; }
        public string creationMethod { get; set; }
        public object ixUpdate { get; set; }
        public bool enterpriseOwned { get; set; }
        public string id { get; set; }
        public bool starred { get; set; }
        public string url { get; set; }
        public Prefs prefs { get; set; }
        public bool subscribed { get; set; }
        public LabelNames labelNames { get; set; }
        public string shortUrl { get; set; }
        public object templateGallery { get; set; }
        public List<Membership> memberships { get; set; }
    }
}
