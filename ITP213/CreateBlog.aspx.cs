using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class CreateBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["accountType"].ToString() == "student")
            {
                ddlTripName.DataSource = WithdrawalRequestDAO.displayAllocatedTrips(Session["adminNo"].ToString());
                ddlTripName.Items.Insert(0, new ListItem("--Select Trip--", "0"));
                ddlTripName.AppendDataBoundItems = true;
                ddlTripName.DataTextField = "tripNameAndTripType";
                ddlTripName.DataValueField = "tripID";
                ddlTripName.DataBind();
            }
        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            if (Session["accountType"].ToString() == "student")
            {
                //lblTitle.Text = $"adminNo:{}";
                
                BlogDAO.insertBlog(txtBoxTitle.Text, txtBoxContent.Text, Session["name"].ToString(), Session["adminNo"].ToString(), ddlTripName.SelectedItem.ToString());
                lblMsg.Text = "Blog Published".ToString();
                lblMsg.Visible = true;
                txtBoxContent.Text = "";
                txtBoxTitle.Text = "";

            }
            

        }
    }
}