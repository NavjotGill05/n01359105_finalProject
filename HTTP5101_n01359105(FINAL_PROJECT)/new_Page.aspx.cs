using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP5101_n01359105_FINAL_PROJECT_
{
    public partial class new_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Add_Page(object sender, EventArgs e)
        {
           
            htmldb db = new htmldb();

            HTTP_Page new_page = new HTTP_Page();

            new_page.SetPageTitle(html_title.Text);
            new_page.SetPageBody(html_body.Text);

            db.Add_Page(new_page);

            Response.Redirect("list_pages.aspx");
        }

    }
}