using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITP213.DAL
{
    public class CreateBlogDAO
    {
        public static int insertBlog(string announcementTitle, string announcementMessage)
        {
            // Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            int result = 0;
            //StringBuilder strSql = new StringBuilder();

            //strSql.AppendLine("INSERT INTO announcement (annnouncementTitle, announcementMessage)");
            //strSql.AppendLine("VALUES (@aAnnouncementTitle', '@aAnnouncementMessage)");
            string strSql = "INSERT INTO announcement (announcementTitle, announcementMessage, adminNo) VALUES(@aAnnouncementTitle, @aAnnouncementMessage, @aAdminNo); ";

            // Announcement obj = new Announcement(); // create an announcement instance
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand cmd = new SqlCommand(strSql, myConn);

            cmd.Parameters.AddWithValue("@aAnnouncementTitle", announcementTitle);
            cmd.Parameters.AddWithValue("@aAnnouncementMessage", announcementMessage);
            cmd.Parameters.AddWithValue("@aAdminNo", "171846Z"); // hardcoding it becauuse login page is not crxted yet

            myConn.Open();
            result = cmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
}