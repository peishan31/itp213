using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class ViewStatistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // first time coming to page
            {
                buildBarChart("2018 - Thailand Trip", "Study Trip");
                //buildPieChart("All");
                //buildHorizontalChart("All");
                //buildLineChart("All", "All");
            }
        }

        private void buildBarChart(string nameOfTrip, string typeOfTrip)
        {
            String myConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
            SqlConnection myConn = new SqlConnection(myConnect);

            DataSet ds = new DataSet();

            //String strSQL = "SELECT tripCost, country, tripType, tripName FROM overseasTrip";
            String strSQL = "SELECT tripCost, country, tripType, tripName, CONCAT(tripName,' (', tripType, ')') AS tripNameAndTripType FROM overseasTrip";
            // Sorry, I named it as tripCost instead of cost.
            /*if (!country.Equals("All"))
            {
                //strSQL += "where location = @paraCountry ";
            }

            if (!type.Equals("All") && (!country.Equals("All")))
            {
                //strSQL += "and triptype = @paratype ";

            }*/
            //strSQL += "GROUP BY country";

            SqlDataAdapter da = new SqlDataAdapter(strSQL.ToString(), myConn);

            /*if (!country.Equals("All"))
            {
                //da.SelectCommand.Parameters.AddWithValue("@paraCountry", country);
            }

            if (!type.Equals("All"))
            {
                //da.SelectCommand.Parameters.AddWithValue("@paratype", type);
            }*/

            // NOT SURE ABOUT HOW THE BELOW CODE WORKS
            /*if (!dateStart.Equals(""))
            {
                //da.SelectCommand.Parameters.AddWithValue("@paradateStart", dateStart);
            }

            if (!dateEnd.Equals(""))
            {
                //da.SelectCommand.Parameters.AddWithValue("@paradateEnd", dateEnd);
            }*/

            da.Fill(ds, "resultTable");

            Chart2.DataSource = ds;
            Chart2.DataBind();
            CountryDropDown.SelectedItem.ToString();
        }

        private void buildPieChart(string country)
        {
            String myConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
            SqlConnection myConn = new SqlConnection(myConnect);

            DataSet ds = new DataSet();

            String strSQL = "SELECT COUNT([Diploma]) NoOfStudents, [Diploma] FROM [Trip] o ";
            strSQL += "INNER JOIN [Student] S ON o.[TripId] = s.[TripId] ";

            if (!country.Equals("All"))
            {
                strSQL += "where location = @paraCountry ";
            }

            strSQL += "Group By [Diploma]";

            SqlDataAdapter da = new SqlDataAdapter(strSQL.ToString(), myConn);

            if (!country.Equals("All"))
            {
                da.SelectCommand.Parameters.AddWithValue("@paraCountry", country);
            }

            da.Fill(ds, "tripTable");

            Chart1.DataSource = ds;
            Chart1.DataBind();
        }

        private void buildLineChart(string Diploma, string StudentYear)
        {
            String myConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
            SqlConnection myConn = new SqlConnection(myConnect);

            DataSet ds = new DataSet();

            SqlDataAdapter da;

            DateTime now = DateTime.Now;


            String strSQL = "SELECT COUNT([adminno]) NoOfStudents, DATENAME(month, TripEnd) AS [Month] FROM [Trip] o INNER JOIN [Student] S ON o.[TripId] = s.[TripId] ";

            if (!Diploma.Equals("All"))
            {
                strSQL += "WHERE Diploma = @paraDiploma ";
                da = new SqlDataAdapter(strSQL.ToString(), myConn);

                if (!StudentYear.Equals("All"))
                {
                    if (now.Month > 4)
                    {
                        int studentyr = int.Parse(StudentYear);
                        studentyr--;
                        strSQL += "AND ((year(getdate()) - 2000) - convert(int, SUBSTRING(AdminNo, 1, 2))) = @paraStudentYear Group By [TripEnd] ";
                        //check
                        da = new SqlDataAdapter(strSQL.ToString(), myConn);
                        da.SelectCommand.Parameters.AddWithValue("@paraStudentYear", studentyr);
                    }
                    else
                    {
                        strSQL += "AND ((year(getdate()) - 2000) - convert(int, SUBSTRING(AdminNo, 1, 2))) = @paraStudentYear Group By [TripEnd] ";
                        //check
                        da = new SqlDataAdapter(strSQL.ToString(), myConn);
                        da.SelectCommand.Parameters.AddWithValue("@paraStudentYear", StudentYear);
                    }
                }
                else
                {
                    strSQL += "Group By [TripEnd] ";
                    da = new SqlDataAdapter(strSQL.ToString(), myConn);

                }
                da.SelectCommand.Parameters.AddWithValue("@paraDiploma", Diploma);
            }
            
            else
            {
                strSQL += "Group By [TripEnd] ";
                da = new SqlDataAdapter(strSQL.ToString(), myConn);
            }
            da.Fill(ds, "tripTable");

            Chart3.DataSource = ds;
            Chart3.DataBind();
        }

        private void buildHorizontalChart(string StudentYear)
        {
            String myConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ToString();
            SqlConnection myConn = new SqlConnection(myConnect);

            DataSet ds = new DataSet();

            String strSQL = "SELECT Count(AdminNo) NoOfStudents,Location FROM [Trip] O Inner join [Student] S on O.[TripId] = S.[TripId] ";

            SqlDataAdapter da;

            DateTime now = DateTime.Now;

            if (!StudentYear.Equals("All"))
            {
                if (now.Month > 4)
                {
                    int studentyr = int.Parse(StudentYear);
                    studentyr--;
                    strSQL += "WHERE ((year(getdate()) - 2000) - convert(int, SUBSTRING(AdminNo, 1, 2))) = @paraStudentYear Group By [Location] ";
                    //check
                    da = new SqlDataAdapter(strSQL.ToString(), myConn);
                    da.SelectCommand.Parameters.AddWithValue("@paraStudentYear", studentyr);
                }
                else
                {
                    strSQL += "WHERE ((year(getdate()) - 2000) - convert(int, SUBSTRING(AdminNo, 1, 2))) = @paraStudentYear Group By [Location] ";
                    //check
                    da = new SqlDataAdapter(strSQL.ToString(), myConn);
                    da.SelectCommand.Parameters.AddWithValue("@paraStudentYear", StudentYear);
                }
            }
            else
            {
                strSQL += "Group By [Location] ";
                da = new SqlDataAdapter(strSQL.ToString(), myConn);
            }
            
            da.Fill(ds, "tripTable");

            Chart4.DataSource = ds;
            Chart4.DataBind();
        }
    }
}