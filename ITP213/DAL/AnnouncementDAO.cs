using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ITP213.DAL
{
    public class AnnouncementDAO
    {
        public static int insertAnnouncement(string announcementTitle, string announcementMessage) {
            // Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            int result = 0;
            //StringBuilder strSql = new StringBuilder();

            //strSql.AppendLine("INSERT INTO announcement (annnouncementTitle, announcementMessage)");
            //strSql.AppendLine("VALUES (@aAnnouncementTitle', '@aAnnouncementMessage)");
            string strSql = "INSERT INTO announcement (annnouncementTitle, announcementMessage) VALUES(@aAnnouncementTitle, @aAnnouncementMessage); ";

            // Announcement obj = new Announcement(); // create an announcement instance
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand cmd = new SqlCommand(strSql, myConn);

            cmd.Parameters.AddWithValue("@aAnnouncementTitle", announcementTitle);
            cmd.Parameters.AddWithValue("@aAnnouncementMessage", announcementMessage);

            myConn.Open();
            result = cmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public static List<Announcement> getAllAnnouncement()
        {
            List<Announcement> resultList = new List<Announcement>();
            // Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Create Adapter
            string sqlStr = "SELECT * FROM announcement";

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlStr, myConn);

            // Fill dataset
            da.Fill(ds, "announcementTable");
            int rec_cnt = ds.Tables["announcementTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["announcementTable"].Rows)
                {
                    Announcement obj = new Announcement(); // create announcement instance
                    obj.announcementID = Convert.ToInt32(row["announcementID"]);
                    obj.announcementTitle = row["announcementTitle"].ToString();
                    obj.announcementMessage = row["announcementMessage"].ToString();

                    resultList.Add(obj);
                }
            }
            return resultList;
        }
    }
}