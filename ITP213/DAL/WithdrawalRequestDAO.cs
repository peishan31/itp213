using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ITP213.DAL
{
    public class WithdrawalRequestDAO
    {
        // StudentWithdrawalRequest.aspx
        public static List<WithdrawalRequest> displayAllocatedTrips(string adminNo)
        {
            List<WithdrawalRequest> resultList = new List<WithdrawalRequest>();
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            /*
            SELECT * FROM overseasTrip INNER JOIN overseasEnrolledStudent on overseasTrip.tripID = overseasEnrolledStudent.tripID WHERE adminNo='171846z';
            SELECT overseasTrip.tripID, tripName, CONCAT(tripName,' (', tripType, ') - ', departureDate,' to ', arrivalDate) AS tripNameAndTripType FROM overseasTrip INNER JOIN overseasEnrolledStudent on overseasTrip.tripID = overseasEnrolledStudent.tripID WHERE adminNo='171846z';
             */
            string sqlStr = "SELECT overseasTrip.tripID, tripName, CONCAT(tripName,' (', tripType, ')') AS tripNameAndTripType FROM overseasTrip INNER JOIN overseasEnrolledStudent on overseasTrip.tripID = overseasEnrolledStudent.tripID WHERE adminNo=@adminNo;";
                //"SELECT * FROM overseasTrip INNER JOIN overseasEnrolledStudent on overseasTrip.tripID = overseasEnrolledStudent.tripID WHERE adminNo=@adminNo;";

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
                    WithdrawalRequest obj = new WithdrawalRequest();
                    obj.tripID = Convert.ToInt32(row["tripID"]);
                    obj.tripName = row["tripName"].ToString();
                    //obj.tripType = row["tripType"].ToString();
                    obj.tripNameAndTripType = row["tripNameAndTripType"].ToString();
                    resultList.Add(obj);

                }
            }

            return resultList;

        }

        public static int insert(string withdrawalReason, string adminNo, int tripID)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;


            /*
             INSERT INTO withdrawTripRequest(withdrawalTripRequestStatus, withdrawalReason, adminNo, tripID, createdOn) VALUES('ONGOING', 'Testing 1 2 3','171846Z',28, GETDATE());
             */
            string sqlStr = "INSERT INTO withdrawTripRequest(withdrawalTripRequestStatus, withdrawalReason, adminNo, tripID, createdOn) VALUES('ONGOING', @withdrawalReason,@adminNo,@tripID, GETDATE());";

            WithdrawalRequest obj = new WithdrawalRequest();
            SqlConnection myConn = new SqlConnection(DBConnect);
            myConn.Open();
            SqlCommand cmd = new SqlCommand(sqlStr, myConn);
            cmd.Parameters.AddWithValue("withdrawalReason", withdrawalReason);
            cmd.Parameters.AddWithValue("adminNo", adminNo);
            cmd.Parameters.AddWithValue("tripID", Convert.ToInt32(tripID));

            int result = cmd.ExecuteNonQuery();
            return result;
        }

        // LecturerWithdrawalRequest.aspx
        public static List<WithdrawalRequest> displayWithdrawalRequest(string staffID)
        {
            List<WithdrawalRequest> resultList = new List<WithdrawalRequest>();
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            /*
            Select overseasTrip.tripID, withdrawTripRequestID, adminNo, departureDate, arrivalDate ,withdrawalReason, CONCAT(tripName,' (', tripType, ')') AS tripNameAndTripType  FROM withdrawTripRequest INNER JOIN overseasEnrolledLecturer ON withdrawTripRequest.tripID = overseasEnrolledLecturer.tripID INNER JOIN overseasTrip ON withdrawTripRequest.tripID = overseasTrip.tripID WHERE staffID='susie_waters';
             */
            string sqlStr = "Select createdOn, overseasTrip.tripID, withdrawTripRequestID, adminNo, departureDate, arrivalDate ,withdrawalReason, CONCAT(tripName,' (', tripType, ')') AS tripNameAndTripType  FROM withdrawTripRequest INNER JOIN overseasEnrolledLecturer ON withdrawTripRequest.tripID = overseasEnrolledLecturer.tripID INNER JOIN overseasTrip ON withdrawTripRequest.tripID = overseasTrip.tripID WHERE staffID=@staffID;";

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
                    WithdrawalRequest obj = new WithdrawalRequest();
                    obj.tripID = Convert.ToInt32(row["tripID"]);
                    obj.withdrawTripRequestID = Convert.ToInt32(row["withdrawTripRequestID"]);
                    obj.adminNo = row["adminNo"].ToString();
                    obj.departureDate = row["departureDate"].ToString();
                    obj.arrivalDate = row["arrivalDate"].ToString();
                    obj.withdrawalReason = row["withdrawalReason"].ToString();
                    obj.tripNameAndTripType = row["tripNameAndTripType"].ToString();
                    obj.createdOn = row["createdOn"].ToString();
                    resultList.Add(obj);

                }
            }
            else
            {
                resultList = null;
            }

            return resultList;

        }

    }
}