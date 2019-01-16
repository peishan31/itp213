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
    public class ReportInjuryDAO
    {
        public static List<ReportInjury> getStudentName(int tripID)
        {
            List<ReportInjury> resultList = new List<ReportInjury>();
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            string sqlStr = "SELECT * FROM overseasEnrolledStudent INNER JOIN student on overseasEnrolledStudent.adminNo = student.adminNo INNER JOIN account on student.accountID = account.accountID WHERE tripID = @tripID;";

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlStr, myConn);
            da.SelectCommand.Parameters.AddWithValue("tripID", tripID);
            // fill dataset
            da.Fill(ds, "resultTable");
            int rec_cnt = ds.Tables["resultTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["resultTable"].Rows)
                {
                    ReportInjury obj = new ReportInjury();
                    obj.adminNo = row["adminNo"].ToString();
                    obj.name = row["name"].ToString();
                    resultList.Add(obj);

                }
            }

            return resultList;

        }

        /*INSERT INTO injuryReport(dateTimeOfInjury, location, description, witnessName, witnessPhone, natureOfInjury, causeOfInjury, locationOnBody, agency, firstAidGiven, firstAiderName, treatment, staffID, adminNo, tripID) VALUES('12/26/2018 12:00AM', 'Street', 'a', 'a','8123456','a','a','a','a','a','a','a','johnny_appleseed','171846z',26)*/
        public static int insert(string dateTimeOfInjury, string location, string description, string witnessName, string witnessPhone, string natureOfInjury, string causeOfInjury, string locationOnBody, string agency, string firstAidGiven, string firstAiderName, string treatment, string staffID, string adminNo, string studentName, int tripID)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            string sqlStr =
                "INSERT INTO injuryReport(dateTimeOfInjury, location, description, witnessName, witnessPhone, natureOfInjury, causeOfInjury, locationOnBody, agency, firstAidGiven, firstAiderName, treatment, staffID, adminNo, studentName, tripID, createdOn) "+
                "VALUES(@dateTimeOfInjury, @location, @description, @witnessName, @witnessPhone, @natureOfInjury, @causeOfInjury, @locationOnBody, @agency, @firstAidGiven, @firstAiderName, @treatment, @staffID, @adminNo, @studentName, @tripID, GETDATE())";


            ReportInjury obj = new ReportInjury();   // create a customer instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            myConn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, myConn);
            cmd.Parameters.AddWithValue("dateTimeOfInjury", Convert.ToDateTime(dateTimeOfInjury));
            cmd.Parameters.AddWithValue("location", location);
            cmd.Parameters.AddWithValue("description", description);
            cmd.Parameters.AddWithValue("witnessName", witnessName);
            cmd.Parameters.AddWithValue("witnessPhone", witnessPhone);
            cmd.Parameters.AddWithValue("natureOfInjury", natureOfInjury);
            cmd.Parameters.AddWithValue("causeOfInjury", causeOfInjury);
            cmd.Parameters.AddWithValue("locationOnBody", locationOnBody);
            cmd.Parameters.AddWithValue("agency", agency);
            cmd.Parameters.AddWithValue("firstAidGiven", firstAidGiven);
            cmd.Parameters.AddWithValue("firstAiderName", firstAiderName);
            cmd.Parameters.AddWithValue("treatment", treatment);
            cmd.Parameters.AddWithValue("staffID", staffID);
            cmd.Parameters.AddWithValue("adminNo", adminNo);
            cmd.Parameters.AddWithValue("studentName", studentName);
            cmd.Parameters.AddWithValue("tripID", tripID);

            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public static List<ReportInjury> getAllReports()
        {
            List<ReportInjury> resultList = new List<ReportInjury>();
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            string sqlStr = "SELECT * FROM injuryReport INNER JOIN overseasTrip on overseasTrip.tripID = injuryReport.tripID INNER JOIN lecturer on lecturer.staffID = injuryReport.staffID  INNER JOIN account on account.accountID = lecturer.accountID;";

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlStr, myConn);
            
            // fill dataset
            da.Fill(ds, "resultTable");
            int rec_cnt = ds.Tables["resultTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["resultTable"].Rows)
                {
                    ReportInjury obj = new ReportInjury();
                    obj.injuryReportID = Convert.ToInt32(row["injuryReportID"]);
                    obj.dateTimeOfInjury = row["dateTimeOfInjury"].ToString();
                    obj.location = row["location"].ToString();
                    obj.description = row["description"].ToString();
                    obj.witnessName = row["witnessName"].ToString();
                    obj.witnessPhone = row["witnessPhone"].ToString();
                    obj.natureOfInjury = row["natureOfInjury"].ToString();
                    obj.causeOfInjury = row["causeOfInjury"].ToString();
                    obj.locationOnBody = row["locationOnBody"].ToString();
                    obj.agency = row["agency"].ToString();
                    obj.firstAidGiven = row["firstAidGiven"].ToString();
                    obj.firstAiderName = row["firstAiderName"].ToString();
                    obj.treatment = row["treatment"].ToString();
                    obj.tripName = row["tripName"].ToString();
                    obj.tripType = row["tripType"].ToString();
                    obj.createdOn = row["createdOn"].ToString();
                    obj.name = row["name"].ToString();
                    obj.studentName = row["studentName"].ToString();
                    obj.staffID = row["staffID"].ToString();
                    resultList.Add(obj);

                }
            }
            else
            {
                resultList = null;
            }

            return resultList;

        }

        public static List<ReportInjury> getAllPastReports()
        {
            List<ReportInjury> resultList = new List<ReportInjury>();
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            string sqlStr = "SELECT * FROM injuryReport INNER JOIN overseasTrip on overseasTrip.tripID = injuryReport.tripID INNER JOIN lecturer on lecturer.staffID = injuryReport.staffID  INNER JOIN account on account.accountID = lecturer.accountID WHERE arrivalDate<=GETDATE();";

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlStr, myConn);

            // fill dataset
            da.Fill(ds, "resultTable");
            int rec_cnt = ds.Tables["resultTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["resultTable"].Rows)
                {
                    ReportInjury obj = new ReportInjury();
                    obj.injuryReportID = Convert.ToInt32(row["injuryReportID"]);
                    obj.dateTimeOfInjury = row["dateTimeOfInjury"].ToString();
                    obj.location = row["location"].ToString();
                    obj.description = row["description"].ToString();
                    obj.witnessName = row["witnessName"].ToString();
                    obj.witnessPhone = row["witnessPhone"].ToString();
                    obj.natureOfInjury = row["natureOfInjury"].ToString();
                    obj.causeOfInjury = row["causeOfInjury"].ToString();
                    obj.locationOnBody = row["locationOnBody"].ToString();
                    obj.agency = row["agency"].ToString();
                    obj.firstAidGiven = row["firstAidGiven"].ToString();
                    obj.firstAiderName = row["firstAiderName"].ToString();
                    obj.treatment = row["treatment"].ToString();
                    obj.tripName = row["tripName"].ToString();
                    obj.tripType = row["tripType"].ToString();
                    obj.createdOn = row["createdOn"].ToString();
                    obj.name = row["name"].ToString();
                    obj.studentName = row["studentName"].ToString();
                    resultList.Add(obj);

                }
            }

            return resultList;

        }

        public static int deleteById(int injuryReportID)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            string sqlStr = "DELETE injuryReport WHERE injuryReportID = @injuryReportID";

            SqlConnection myConn = new SqlConnection(DBConnect);
            myConn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, myConn);
            cmd.Parameters.AddWithValue("injuryReportID", injuryReportID);
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public static int updateInjuryReport(DateTime dateTimeOfInjury, string location, string description, string witnessName, string witnessPhone, string natureOfInjury, string causeOfInjury, string locationOnBody, string agency, string firstAidGiven, string firstAiderName, string treatment, string staffID, string adminNo, string studentName, int tripID, int injuryReportID)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("UPDATE injuryReport SET ");
            sqlStr.AppendLine("dateTimeOfInjury=@dateTimeOfInjury,");
            sqlStr.AppendLine("location=@location,");
            sqlStr.AppendLine("description=@description, ");
            sqlStr.AppendLine("witnessName=@witnessName, ");
            sqlStr.AppendLine("witnessPhone=@witnessPhone, ");
            sqlStr.AppendLine("natureOfInjury=@natureOfInjury, ");
            sqlStr.AppendLine("causeOfInjury=@causeOfInjury, ");
            sqlStr.AppendLine("locationOnBody=@locationOnBody, ");
            sqlStr.AppendLine("agency=@agency, ");
            sqlStr.AppendLine("firstAidGiven=@firstAidGiven, ");
            sqlStr.AppendLine("firstAiderName=@firstAiderName, ");
            sqlStr.AppendLine("treatment=@treatment, ");
            sqlStr.AppendLine("staffID = @staffID, ");
            sqlStr.AppendLine("adminNo=@adminNo, ");
            sqlStr.AppendLine("studentName=@studentName, ");
            sqlStr.AppendLine("tripID=@tripID,");
            sqlStr.AppendLine("createdOn=getDate()");
            sqlStr.AppendLine("WHERE injuryReportID=@injuryReportID;");
            /*
             UPDATE injuryReport SET
             dateTimeOfInjury='12-28-2018 16:24', 
             location='SG', 
             description='This is a description', 
             witnessName='Lin Peishan', 
             witnessPhone='81234567', 
             natureOfInjury='Sprain', 
             causeOfInjury='fall', 
             locationOnBody='Knee', 
             agency='Pushed by another person', 
             firstAidGiven='No', 
             firstAiderName='', 
             treatment='', 
             staffID='johnny_appleseed', 
             adminNo='171846Z', 
             studentName='Lin Peishan', 
             tripID=30, 
             createdOn='12-28-2018 16:24';
             */


            SqlConnection myConn = new SqlConnection(DBConnect);
            myConn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr.ToString(), myConn);
            cmd.Parameters.AddWithValue("dateTimeOfInjury", dateTimeOfInjury);
            cmd.Parameters.AddWithValue("location", location);
            cmd.Parameters.AddWithValue("description", description);
            cmd.Parameters.AddWithValue("witnessName", witnessName);
            cmd.Parameters.AddWithValue("witnessPhone", witnessPhone);
            cmd.Parameters.AddWithValue("natureOfInjury", natureOfInjury);
            cmd.Parameters.AddWithValue("causeOfInjury", causeOfInjury);
            cmd.Parameters.AddWithValue("locationOnBody", locationOnBody);
            cmd.Parameters.AddWithValue("agency", agency);
            cmd.Parameters.AddWithValue("firstAidGiven", firstAidGiven);
            cmd.Parameters.AddWithValue("firstAiderName", firstAiderName);
            cmd.Parameters.AddWithValue("treatment", treatment);
            cmd.Parameters.AddWithValue("staffID", staffID);
            cmd.Parameters.AddWithValue("adminNo", adminNo);
            cmd.Parameters.AddWithValue("studentName", studentName);
            cmd.Parameters.AddWithValue("tripID", tripID);
            cmd.Parameters.AddWithValue("injuryReportID", injuryReportID);
            int result = cmd.ExecuteNonQuery();
            return result;
        }

        public static ReportInjury getInjuryReportByID(int injuryReportID)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer by customer Id using query parameter
            string sqlStr = "SELECT * FROM injuryReport where injuryReportID=@injuryReportID;";

            // change custId in where clause to custId1 or 
            // change connection string in web config to a wrong file name  

            ReportInjury obj = new ReportInjury();   // create a customer instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlStr, myConn);
            da.SelectCommand.Parameters.AddWithValue("injuryReportID", injuryReportID);
            // fill dataset
            da.Fill(ds, "resultTable");
            int rec_cnt = ds.Tables["resultTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["resultTable"].Rows[0];  // Sql command returns only one record
                obj.injuryReportID = Convert.ToInt32(row["injuryReportID"]);
                obj.dateTimeOfInjury = row["dateTimeOfInjury"].ToString();
                obj.location = row["location"].ToString();
                obj.description = row["description"].ToString();
                obj.witnessName = row["witnessName"].ToString();
                obj.witnessPhone = row["witnessPhone"].ToString();
                obj.natureOfInjury = row["natureOfInjury"].ToString();
                obj.causeOfInjury = row["causeOfInjury"].ToString();
                obj.locationOnBody = row["locationOnBody"].ToString();
                obj.agency = row["agency"].ToString();
                obj.firstAidGiven = row["firstAidGiven"].ToString();
                obj.firstAiderName = row["firstAiderName"].ToString();
                obj.treatment = row["treatment"].ToString();
                //obj.tripName = row["tripName"].ToString();
               // obj.tripType = row["tripType"].ToString();
                obj.createdOn = row["createdOn"].ToString();
                //obj.name = row["name"].ToString();
                obj.adminNo = row["adminNo"].ToString();
                obj.studentName = row["studentName"].ToString();
                obj.tripID = Convert.ToInt32(row["tripID"]);
            }
            else
            {
                obj = null;
            }

            return obj;
        }
    }
}