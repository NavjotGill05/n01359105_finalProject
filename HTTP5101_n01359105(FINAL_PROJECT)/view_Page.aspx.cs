using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP5101_n01359105_FINAL_PROJECT_
{
    public partial class view_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            htmldb db = new htmldb();
  
            ShowPageInfo(db);      

        }
        protected void ShowPageInfo(htmldb db)
        {

            bool valid = true;
            string html_id = Request.QueryString["html_id"];
            if (String.IsNullOrEmpty(html_id)) valid = false;

            if (valid)
            {

                HTTP_Page page_record = db.Find_Page(Int32.Parse(html_id));

                html_tag_title.InnerHtml = page_record.GetPageTitle();
                html_tag_desc.InnerHtml = page_record.GetPageBody();
     
            }
            else
            {
                valid = false;
            }

            if (!valid)
            {
                html_element.InnerHtml = "There is an error finding a page.";
            }
        }
        protected void Delete_Page(object sender, EventArgs e)
        {
            bool valid = true;
            string html_id = Request.QueryString["html_id"];
            if (String.IsNullOrEmpty(html_id)) valid = false;

            htmldb db = new htmldb();

            if (valid)
            {
                db.Delete_Page(Int32.Parse(html_id));
                Response.Redirect("list_pages.aspx");
            }
        }

    }
}