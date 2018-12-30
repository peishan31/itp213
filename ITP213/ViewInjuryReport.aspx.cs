using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class ViewInjuryReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["accountType"].ToString() == "lecturer")
            //{
            if (!Page.IsPostBack)
            {
                RepeaterViewInjury.DataSource = ReportInjuryDAO.getAllReports();
                RepeaterViewInjury.DataBind();

                //Repeater1.DataSource = ReportInjuryDAO.getAllReports();
                //Repeater1.DataBind();
            }
            
            //}
        }

        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "trips_Click")
            {
                string name = e.CommandArgument.ToString();
                lblTesting.Text = name;
                Response.Redirect("/ReportInjury.aspx?injuryReportID=" + name);
            }
        }

        protected void btnDelete_command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "trips_Click")
            {
                string name = e.CommandArgument.ToString();
                lblTesting.Text = name;
                DAL.ReportInjuryDAO.deleteById(Convert.ToInt32(name));
                Response.Redirect("/ViewInjuryReport.aspx");
            }
        }
    }
}