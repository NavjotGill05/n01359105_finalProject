using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTTP5101_n01359105_FINAL_PROJECT_
{
    public partial class list_pages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            pages_result.InnerHtml = "";

            string searchkey = "";

            string query = "select * from html";

            if (searchkey != "")
            {
                query += " WHERE html_tags_id like '%" + searchkey + "%' ";
                query += " or html_tags_title like '%" + searchkey + "%' ";
                query += " or html_tags_body like '%" + searchkey + "%' ";
            }

            var db = new htmldb();
            List<Dictionary<String, String>> rs = db.List_Query(query);
            foreach (Dictionary<String, String> row in rs)
            {
                pages_result.InnerHtml += "<div class=\"listitem\">";

                string html_id = row["html_tags_id"];
                pages_result.InnerHtml += "<div class=\"col\">" + html_id + "</div>";

                string html_title = row["html_tags_title"];
                pages_result.InnerHtml += "<div class=\"col\"><a href=\"view_Page.aspx?html_id=" + html_id + "\">" + html_title + "</a></div>";

                string html_body = row["html_tags_body"];
                pages_result.InnerHtml += "<div class=\"col_last\">" + html_body + "</div>";

                pages_result.InnerHtml += "</div>";
            }

        }
    }
}