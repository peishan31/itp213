using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
        public static int insert(string dateTimeOfInjury, string location, string description, string witnessName, string witnessPhone, string natureOfInjury, string causeOfInjury, string locationOnBody, string agency, string firstAidGiven, string firstAiderName, string treatment, string staffID, string adminNo, int tripID)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            string sqlStr =
                "INSERT INTO injuryReport(dateTimeOfInjury, location, description, witnessName, witnessPhone, natureOfInjury, causeOfInjury, locationOnBody, agency, firstAidGiven, firstAiderName, treatment, staffID, adminNo, tripID, createdOn) "+
                "VALUES(@dateTimeOfInjury, @location, @description, @witnessName, @witnessPhone, @natureOfInjury, @causeOfInjury, @locationOnBody, @agency, @firstAidGiven, @firstAiderName, @treatment, @staffID, @adminNo, @tripID, GETDATE())";


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
            cmd.Parameters.AddWithValue("tripID", tripID);

            int result = cmd.ExecuteNonQuery();
            return result;
        }
    }
}