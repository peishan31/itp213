using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class CreateComplaints : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["accountType"].ToString() == "student" || Session["accountType"].ToString() == "parent")
            {
                ddlTripName.DataSource = WithdrawalRequestDAO.displayAllocatedTrips(Session["adminNo"].ToString());
                ddlTripName.Items.Insert(0, new ListItem("--Select Trip--", "0"));
                ddlTripName.AppendDataBoundItems = true;
                ddlTripName.DataTextField = "tripNameAndTripType";
                ddlTripName.DataValueField = "tripID";
                ddlTripName.DataBind();
                ddlTripName.SelectedIndex = 0;
            }
        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            if (Session["accountType"].ToString() == "student")
            {
                string s = "Images/" + FileUpload1.FileName;
                ComplainDAO.insertComplain(txtBoxSubject.Text, txtBoxComments.Text, Session["name"].ToString(), Session["adminNo"].ToString(), ddlTripName.SelectedItem.ToString(),s,txtBoxComplainType.Text);
                FileUpload1.SaveAs(Server.MapPath("~/Images/") + FileUpload1.FileName);
                txtBoxSubject.Text = "";
                txtBoxComments.Text = "";
                txtBoxComplainType.Text = "";
                Label2.Text = "Complaint sucessfully uploaded";
                Label2.Visible = true;
            }



        }

        protected void txtBoxComments_TextChanged(object sender, EventArgs e)
        {

        }
    }
 }