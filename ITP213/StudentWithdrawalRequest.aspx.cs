using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class StudentWithdrawalRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Request.QueryString["tripID"] != null)
                {
                    ddlTripName.SelectedValue = Request.QueryString["tripID"].ToString();

                }
                if (Session["accountType"].ToString() == "student")
                {
                    lblAdminNo.Text += Session["adminNo"].ToString();
                    /*
                    lbStudents.DataSource = TripAllocationDAO.getStudentName(ddlCourses.SelectedValue);
                    lbStudents.DataTextField = "name";
                    lbStudents.DataValueField = "adminNo";
                    lbStudents.DataBind();
                     */

                    ddlTripName.DataSource = WithdrawalRequestDAO.displayAllocatedTrips(Session["adminNo"].ToString());
                    ddlTripName.DataTextField = "tripNameAndTripType";
                    ddlTripName.DataValueField = "tripID";
                    ddlTripName.DataBind();
                }
            }
            
        }

        protected void tbReasons_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbReasons.Text))
            {
                panelError.Visible = true;
            }
            else
            {
                panelError.Visible = false;
                WithdrawalRequestDAO.insert(tbReasons.Text, lblAdminNo.Text, Convert.ToInt32(ddlTripName.SelectedValue));
                Response.Redirect("/Default.aspx");
            }
        }
    }
}