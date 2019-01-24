using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ITP213.DAL
{
    public class BlogDAO
    {
        public static int insertBlog(string title, string content, string studentName, string adminNo,string country)
        {
            //Get connection string from webvconfig
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            string sqlstr =
                "INSERT INTO studentBlog(title,content,studentName,adminNo,country, blogtime)VALUES(@title,@content,@studentName,@adminNo,@country, GETDATE())";
            /*INSERT INTO studentBlog(title,content,studentName,adminNo,country, blogtime)VALUES('Hi','Hi','hi','171846z','SG', GETDATE())*/

            Blog obj = new Blog();

            SqlConnection myConn = new SqlConnection(DBConnect);
            myConn.Open();
            SqlCommand cmd = new SqlCommand(sqlstr, myConn);
            cmd.Parameters.AddWithValue("title", title);
            cmd.Parameters.AddWithValue("content", content);
            cmd.Parameters.AddWithValue("studentName", studentName);
            cmd.Parameters.AddWithValue("adminNo", adminNo);
            cmd.Parameters.AddWithValue("country", country);

            int result = cmd.ExecuteNonQuery();
            return result;

        }
    }
}