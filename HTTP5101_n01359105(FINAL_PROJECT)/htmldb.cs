using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace HTTP5101_n01359105_FINAL_PROJECT_
{
    public class htmldb
    {
       
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "htmldb"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        private static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }

        public List<Dictionary<String, String>> List_Query(string query)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);

                        List<Dictionary<String, String>> ResultSet = new List<Dictionary<String, String>>();


            try
            {
                Debug.WriteLine("Connection Initialized...");
                Debug.WriteLine("Attempting to execute query " + query);

                Connect.Open();

                MySqlCommand cmd = new MySqlCommand(query, Connect);

                MySqlDataReader resultset = cmd.ExecuteReader();

                while (resultset.Read())
                {
                    Dictionary<String, String> Row = new Dictionary<String, String>();

                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        Row.Add(resultset.GetName(i), resultset.GetString(i));

                    }

                    ResultSet.Add(Row);
                }
                resultset.Close();


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the List_Query method!");
                Debug.WriteLine(ex.ToString());

            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return ResultSet;
        }

        public HTTP_Page Find_Page(int html_id)
        {
            MySqlConnection Connect = new MySqlConnection(ConnectionString);
        
            HTTP_Page result_page = new HTTP_Page();

            try
            {
                string query = "select * from html where html_tags_id = " + html_id;
                Debug.WriteLine("Connection Initialized...");
                
                Connect.Open();
                
                MySqlCommand cmd = new MySqlCommand(query, Connect);
                
                MySqlDataReader resultset = cmd.ExecuteReader();

                List<HTTP_Page> pages = new List<HTTP_Page>();

                while (resultset.Read())
                {
                    
                    HTTP_Page currentpage = new HTTP_Page();


                    for (int i = 0; i < resultset.FieldCount; i++)
                    {
                        string key = resultset.GetName(i);
                        string value = resultset.GetString(i);
                        Debug.WriteLine("Attempting to transfer " + key + " data of " + value);
                        
                        switch (key)
                        {
                            case "html_tags_title":
                                currentpage.SetPageTitle(value);
                                break;
                            case "html_tags_body":
                                currentpage.SetPageBody(value);
                                break;
                        }

                    }

                    pages.Add(currentpage);
                }

                result_page = pages[0]; 

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the find Page method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
            Debug.WriteLine("Database Connection Terminated.");

            return result_page;
        }
        public void Delete_Page(int html_id)
        {

            string remove_page = "delete from html where html_tags_id = {0}";
            remove_page = String.Format(remove_page, html_id);

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            
            MySqlCommand cmd_removePage = new MySqlCommand(remove_page, Connect);
            try
            {

                Connect.Open();

                cmd_removePage.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + cmd_removePage);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the delete Page Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }
        public void Add_Page(HTTP_Page new_page)
        {

            string query = "insert into html (html_tags_title, html_tags_body) values ('{0}','{1}')";
            query = String.Format(query, new_page.GetPageTitle(), new_page.GetPageBody());

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the Add_Page Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }
        public void UpdatePage(int html_id, HTTP_Page new_page)
        {
            string query = "update html set html_tags_title='{0}', html_tags_body='{1}' where html_tags_id={2}";
            query = String.Format(query, new_page.GetPageTitle(), new_page.GetPageBody(), html_id);

            MySqlConnection Connect = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, Connect);
            try
            {
                Connect.Open();
                cmd.ExecuteNonQuery();
                Debug.WriteLine("Executed query " + query);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Something went wrong in the Update_Page Method!");
                Debug.WriteLine(ex.ToString());
            }

            Connect.Close();
        }

    }
}