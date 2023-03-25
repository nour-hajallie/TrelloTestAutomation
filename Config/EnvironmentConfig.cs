using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace TrelloTest
{
    public class EnvironmentConfig
    {

        private String trollyLoginUrl;

        public EnvironmentConfig()
        {
            trollyLoginUrl = "https://trello.com/login";
            setTrollyLoginURL(trollyLoginUrl);
        }

        public void setTrollyLoginURL(String _trollyLoginUrl)
        {
            trollyLoginUrl = _trollyLoginUrl;

        }

        public String getTrollyLoginURL()
        {
            return trollyLoginUrl;
        }

    }
}
