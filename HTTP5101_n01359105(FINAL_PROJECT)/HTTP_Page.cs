using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTTP5101_n01359105_FINAL_PROJECT_
{
    public class HTTP_Page
    {
        private string Page_title;
        private string Page_body;

        public string GetPageTitle()
        {
            return Page_title;
        }
        public string GetPageBody()
        {
            return Page_body;
        }

        public void SetPageTitle(string value)
        {
            Page_title = value;
        }
        public void SetPageBody(string value)
        {
            Page_body = value;
        }
    }
}