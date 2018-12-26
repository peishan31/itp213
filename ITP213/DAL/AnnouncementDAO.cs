﻿using System;
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
        public static int insertAnnouncement(string announcementTitle, string announcementMessage, int tripID, string staffID, string studentView, string lecturerView, string timeDue) {
            // Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            int result = 0;
            //StringBuilder strSql = new StringBuilder();

            /*
             INSERT INTO announcement (announcementTitle, announcementMessage, tripID, createdOn, staffID, studentView, lecturerView) VALUES('YOO','THIS IS A MSG',29,GETDATE(), 'johnny_appleseed', 'Yes', 'Yes');
             */
            string strSql = "INSERT INTO announcement (announcementTitle, announcementMessage, tripID, createdOn, staffID, studentView, lecturerView, timeDue) VALUES(@announcementTitle,@announcementMessage,@tripID,GETDATE(), @staffID, @studentView, @lecturerView, @timeDue); ";

            // Announcement obj = new Announcement(); // create an announcement instance
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand cmd = new SqlCommand(strSql, myConn);

            cmd.Parameters.AddWithValue("@announcementTitle", announcementTitle);
            cmd.Parameters.AddWithValue("@announcementMessage", announcementMessage);
            cmd.Parameters.AddWithValue("@tripID", Convert.ToInt32(tripID));
            cmd.Parameters.AddWithValue("@staffID", staffID);
            cmd.Parameters.AddWithValue("@studentView", studentView);
            cmd.Parameters.AddWithValue("@lecturerView", lecturerView);
            cmd.Parameters.AddWithValue("@timeDue", Convert.ToDateTime(timeDue));

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
            string sqlStr = "SELECT announcementID, announcementTitle, announcementMessage FROM announcement";

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

        public static List<Announcement> getImmersionTripAnnouncementByStaffID(string staffID)
        {
            List<Announcement> resultList = new List<Announcement>();
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            /*
            SELECT * FROM announcement INNER JOIN overseasTrip on announcement.tripID = overseasTrip.tripID INNER JOIN overseasEnrolledLecturer on overseasEnrolledLecturer.tripID = overseasTrip.tripID WHERE overseasEnrolledLecturer.staffID = 'johnny_appleseed';
             */
            string sqlStr = "SELECT * FROM announcement INNER JOIN overseasTrip on announcement.tripID = overseasTrip.tripID INNER JOIN overseasEnrolledLecturer on overseasEnrolledLecturer.tripID = overseasTrip.tripID INNER JOIN lecturer on announcement.staffID = lecturer.staffID INNER JOIN account on account.accountID = lecturer.accountID WHERE overseasEnrolledLecturer.staffID = @staffID  and tripType='Immersion Trip';";

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlStr, myConn);
            da.SelectCommand.Parameters.AddWithValue("staffID", staffID);
            // fill dataset
            da.Fill(ds, "resultTable");
            int rec_cnt = ds.Tables["resultTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["resultTable"].Rows)
                {
                    Announcement obj = new Announcement();
                    obj.announcementID = Convert.ToInt32(row["announcementID"]);
                    obj.announcementTitle = row["announcementTitle"].ToString();
                    obj.announcementMessage = row["announcementMessage"].ToString();
                    obj.staffID = row["staffID"].ToString();
                    obj.tripName = row["tripName"].ToString();
                    obj.createdOn = row["createdOn"].ToString();
                    obj.staffName = row["name"].ToString();
                    resultList.Add(obj);

                }
            }
            else
            {
                resultList = null;
            }

            return resultList;

        }

        public static List<Announcement> getStudyTripAnnouncementByStaffID(string staffID)
        {
            List<Announcement> resultList = new List<Announcement>();
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            /*
            SELECT * FROM announcement INNER JOIN overseasTrip on announcement.tripID = overseasTrip.tripID INNER JOIN overseasEnrolledLecturer on overseasEnrolledLecturer.tripID = overseasTrip.tripID WHERE overseasEnrolledLecturer.staffID = 'johnny_appleseed';
             */
            string sqlStr = "SELECT * FROM announcement INNER JOIN overseasTrip on announcement.tripID = overseasTrip.tripID INNER JOIN overseasEnrolledLecturer on overseasEnrolledLecturer.tripID = overseasTrip.tripID INNER JOIN lecturer on announcement.staffID = lecturer.staffID INNER JOIN account on account.accountID = lecturer.accountID WHERE overseasEnrolledLecturer.staffID = @staffID  and tripType='Study Trip';";

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlStr, myConn);
            da.SelectCommand.Parameters.AddWithValue("staffID", staffID);
            // fill dataset
            da.Fill(ds, "resultTable");
            int rec_cnt = ds.Tables["resultTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["resultTable"].Rows)
                {
                    Announcement obj = new Announcement();
                    obj.announcementID = Convert.ToInt32(row["announcementID"]);
                    obj.announcementTitle = row["announcementTitle"].ToString();
                    obj.announcementMessage = row["announcementMessage"].ToString();
                    obj.staffID = row["staffID"].ToString();
                    obj.tripName = row["tripName"].ToString();
                    obj.createdOn = row["createdOn"].ToString();
                    obj.staffName = row["name"].ToString();
                    resultList.Add(obj);

                }
            }
            else
            {
                resultList = null;
            }
            return resultList;

        }

        public static List<Announcement> getStudyTripAnnouncementByAdminNo(string adminNo)
        {
            List<Announcement> resultList = new List<Announcement>();
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            /*
            SELECT * FROM announcement INNER JOIN overseasTrip on announcement.tripID = overseasTrip.tripID INNER JOIN overseasEnrolledStudent on overseasEnrolledStudent.tripID = overseasTrip.tripID WHERE adminNo = '171846Z' and tripType='Study Trip';
             */
            string sqlStr = "SELECT * FROM announcement INNER JOIN overseasTrip on announcement.tripID = overseasTrip.tripID INNER JOIN overseasEnrolledStudent on overseasEnrolledStudent.tripID = overseasTrip.tripID INNER JOIN lecturer on announcement.staffID = lecturer.staffID INNER JOIN account on account.accountID = lecturer.accountID WHERE adminNo = @adminNo and tripType='Study Trip';";

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlStr, myConn);
            da.SelectCommand.Parameters.AddWithValue("adminNo", adminNo);
            // fill dataset
            da.Fill(ds, "resultTable");
            int rec_cnt = ds.Tables["resultTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["resultTable"].Rows)
                {
                    Announcement obj = new Announcement();
                    obj.announcementID = Convert.ToInt32(row["announcementID"]);
                    obj.announcementTitle = row["announcementTitle"].ToString();
                    obj.announcementMessage = row["announcementMessage"].ToString();
                    obj.staffID = row["staffID"].ToString();
                    obj.tripName = row["tripName"].ToString();
                    obj.createdOn = row["createdOn"].ToString();
                    obj.staffName = row["name"].ToString();
                    resultList.Add(obj);

                }
            }
            else
            {
                resultList = null;
            }
            return resultList;

        }

        public static List<Announcement> getImmersionTripAnnouncementByAdminNo(string adminNo)
        {
            List<Announcement> resultList = new List<Announcement>();
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            /*
            SELECT * FROM announcement INNER JOIN overseasTrip on announcement.tripID = overseasTrip.tripID INNER JOIN overseasEnrolledStudent on overseasEnrolledStudent.tripID = overseasTrip.tripID WHERE adminNo = '171846Z' and tripType='Study Trip';
             */
            string sqlStr = "SELECT * FROM announcement INNER JOIN overseasTrip on announcement.tripID = overseasTrip.tripID INNER JOIN overseasEnrolledStudent on overseasEnrolledStudent.tripID = overseasTrip.tripID INNER JOIN lecturer on announcement.staffID = lecturer.staffID INNER JOIN account on account.accountID = lecturer.accountID WHERE adminNo = @adminNo and tripType='Immersion Trip';";

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlStr, myConn);
            da.SelectCommand.Parameters.AddWithValue("adminNo", adminNo);
            // fill dataset
            da.Fill(ds, "resultTable");
            int rec_cnt = ds.Tables["resultTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["resultTable"].Rows)
                {
                    Announcement obj = new Announcement();
                    obj.announcementID = Convert.ToInt32(row["announcementID"]);
                    obj.announcementTitle = row["announcementTitle"].ToString();
                    obj.announcementMessage = row["announcementMessage"].ToString();
                    obj.staffID = row["staffID"].ToString();
                    obj.tripName = row["tripName"].ToString();
                    obj.createdOn = row["createdOn"].ToString();
                    obj.staffName = row["name"].ToString();
                    resultList.Add(obj);

                }
            }
            else
            {
                resultList = null;
            }
            return resultList;

        }

        public static Announcement getAnnouncementByAnnouncementID(int announcementID)
        {

            //===============================================================================
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer by customer Id using query parameter
            string sqlStr = "SELECT * FROM announcement where announcementID = @aAnnouncementID";

            // change custId in where clause to custId1 or 
            // change connection string in web config to a wrong file name  

            Announcement obj = new Announcement();   // create a customer instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlStr, myConn);
            da.SelectCommand.Parameters.AddWithValue("aAnnouncementID", announcementID);
            // fill dataset
            da.Fill(ds, "announcementTable");
            int rec_cnt = ds.Tables["announcementTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["announcementTable"].Rows[0];  // Sql command returns only one record
                obj.announcementID = Convert.ToInt32(row["announcementID"]);
                obj.announcementMessage = row["announcementMessage"].ToString();
                obj.announcementTitle = row["announcementTitle"].ToString();
            }
            else
            {
                obj = null;
            }

            return obj;
        }

        public static int deleteById(int announcementID)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            string sqlStr = "DELETE announcement WHERE announcementID = @pAnnouncementID";


            SqlConnection myConn = new SqlConnection(DBConnect);
            myConn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, myConn);
            cmd.Parameters.AddWithValue("pAnnouncementID", announcementID);
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public static int updateById(int announcementID, string announcementTitle, string announcementMessage)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            /*UPDATE announcement SET 
            announcementTitle='Updated',announcementMessage='Updated'
            where announcementID=21;*/
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("UPDATE announcement SET ");
            sqlStr.AppendLine("announcementTitle = @aAnnouncementTitle,");
            sqlStr.AppendLine("announcementMessage=@aAnnouncementMessage");
            sqlStr.AppendLine("WHERE announcementID=@aAnnouncementID");



            SqlConnection myConn = new SqlConnection(DBConnect);
            myConn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr.ToString(), myConn);
            cmd.Parameters.AddWithValue("aAnnouncementID", announcementID);
            cmd.Parameters.AddWithValue("aAnnouncementTitle", announcementTitle);
            cmd.Parameters.AddWithValue("aAnnouncementMessage", announcementMessage);
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public static List<Announcement> displayAllocatedTrips(string staffID)
        {
            List<Announcement> resultList = new List<Announcement>();
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            /*
            SELECT overseasTrip.tripID, tripName, CONCAT(tripName,' (', tripType, ')') AS tripNameAndTripType, staffID FROM overseasTrip INNER JOIN overseasEnrolledLecturer on overseasTrip.tripID = overseasEnrolledLecturer.tripID WHERE staffID='johnny_appleseed';
             */
            string sqlStr = "SELECT overseasTrip.tripID, tripName, CONCAT(tripName,' (', tripType, ')') AS tripNameAndTripType, staffID FROM overseasTrip INNER JOIN overseasEnrolledLecturer on overseasTrip.tripID = overseasEnrolledLecturer.tripID WHERE staffID=@staffID;";

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlStr, myConn);
            da.SelectCommand.Parameters.AddWithValue("staffID", staffID);
            // fill dataset
            da.Fill(ds, "resultTable");
            int rec_cnt = ds.Tables["resultTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["resultTable"].Rows)
                {
                    Announcement obj = new Announcement();
                    obj.tripID = Convert.ToInt32(row["tripID"]);
                    obj.tripNameAndTripType = row["tripNameAndTripType"].ToString();
                    resultList.Add(obj);

                }
            }

            return resultList;

        }
    }
}