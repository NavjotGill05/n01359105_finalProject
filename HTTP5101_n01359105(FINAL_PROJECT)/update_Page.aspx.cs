using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP5101_n01359105_FINAL_PROJECT_
{
    public partial class update_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                htmldb db = new htmldb();
                ShowPageInfo(db);
            }
        }

        protected void ShowPageInfo(htmldb db)
        {

            bool valid = true;
            string html_id = Request.QueryString["html_id"];
            if (String.IsNullOrEmpty(html_id)) valid = false;

            if (valid)
            {

                HTTP_Page page_record = db.Find_Page(Int32.Parse(html_id));
                html_tag.Text = page_record.GetPageTitle();
                html_body.Text = page_record.GetPageBody();
            }


            if (!valid)
            {
                update_element.InnerHtml = html_id;
            }
        }
        protected void Update_Page(object sender, EventArgs e)
        {

            htmldb db = new htmldb();

            bool valid = true;
            string html_id = Request.QueryString["html_id"];
            if (String.IsNullOrEmpty(html_id)) valid = false;
            if (valid)
            {
                HTTP_Page new_page = new HTTP_Page();
               
                new_page.SetPageTitle(html_tag.Text);
                new_page.SetPageBody(html_body.Text);

                try
                {
                    db.UpdatePage(Int32.Parse(html_id), new_page);
                    Response.Redirect("view_Page.aspx?html_id=" + html_id);
                }
                catch
                {
                    valid = false;
                }

            }

            if (!valid)
            {
                update_element.InnerHtml = "There was an error updating the page.";
            }

        }

    }
}