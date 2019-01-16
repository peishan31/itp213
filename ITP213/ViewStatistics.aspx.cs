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
            
        }

        private void ShowData()
        {
            String myConnection = ConfigurationManager.ConnectionStrings["myConnection"].ToString();
            SqlConnection con = new SqlConnection(myConnection);
            String query = "SELECT * FROM studentAttempt";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable tb = new DataTable();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                tb.Load(dr, LoadOption.OverwriteChanges);
                con.Close();
            }
            catch { }

            if(tb != null)
            {
                String chart = "";
                // You can change your chart height by modify height value
                chart = "<canvas id=\"line-chart\" width=\"100%\" height=\"40\"></canvas>";
                chart += "<script>";
                chart += "new Chart(document.getElementById(\"line-chart\"), { type: 'line', data: {labels: [";

                // more details in x-axis
                for (int i = 0; i < 100; i++)
                    chart += i.ToString() + ",";
                chart = chart.Substring(0, chart.Length - 1);

                chart += "],datasets: [{ data: [";
                
                // put data from database to chart
                String value = "";
                for (int i = 0; i < tb.Rows.Count; i++)
                    value += tb.Rows[i]["NhietDo"].ToString() + ",";
                value = value.Substring(0, value.Length - 1);

                chart += value;

                chart += "],label: \"Air Temperature\", borderColor: \"#3e95cd\",fill: true}"; // Chart color
                chart += "]},options: { title: { display: true,text: 'Air Temperature (oC)'} }"; // Chart title
                chart += "});";
                chart += "</script>";

                testChart.Text = chart;
            }            
        }
    }
}