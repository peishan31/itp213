using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class CreateAnnouncement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // first time coming to the page
            {
                string id = Request.QueryString["AnnouncementID"];

                if (id != null)
                {
                    lblTitle.Text = "Update Announcement";
                    lblTitle2.Text = "Update Announcement";
                    btnCreate.Text = "Update";

                    //Announcement a = AnnouncementDAO.getAnnouncementBy(Convert.ToInt32(id));

                    //tbTitle.Text = a.announcementTitle;
                    //tbMessage.Text = a.announcementMessage;
                }

                if (Session["accountType"].ToString() == "lecturer")
                {

                    ddlTripName.DataSource = AnnouncementDAO.displayAllocatedTrips(Session["staffID"].ToString());
                    ddlTripName.DataTextField = "tripNameAndTripType";
                    ddlTripName.DataValueField = "tripID";
                    ddlTripName.DataBind();
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string errorMsg = "Sorry please ensure that you have entered everything correctly:";
            if (btnCreate.Text == "Update")
            {
                string id = Request.QueryString["AnnouncementID"];
                string msg = tbMessage.Text;
                string title = tbTitle.Text;
                AnnouncementDAO.updateById(Convert.ToInt32(id), title, msg);
                Response.Redirect("ViewAnnouncement.aspx");
            }
            
            if ((string.IsNullOrEmpty(tbMessage.Text)) || (string.IsNullOrEmpty(tbTitle.Text)) || (ddlTripName.SelectedItem.Text == "--Select--") || (cbLecturers.Checked == false && cbStudents.Checked == false) || (String.IsNullOrEmpty(tbTimeDue.Text)))
            {
                panelAlert.Visible = true;
                panelSuccess.Visible = false;
                lblMsg.ForeColor = System.Drawing.Color.Red;
                
                if (ddlTripName.SelectedItem.Text == "--Select--")
                {
                    errorMsg += "<br>-Please select the group";
                }
                if (string.IsNullOrEmpty(tbTitle.Text))
                {
                    errorMsg += Environment.NewLine + "<br>-Please write your title";
                }
                if (string.IsNullOrEmpty(tbMessage.Text))
                {
                    errorMsg += Environment.NewLine + "<br>-Please write your message";
                }
                if (cbLecturers.Checked == false && cbStudents.Checked == false)
                {
                    errorMsg += Environment.NewLine + "<br>-Please check who can see the announcement";
                }
                DateTime temp;
                if (DateTime.TryParse(tbTimeDue.Text, out temp))
                {
                    // Valid
                    //panelAlert.Visible = true;
                    //errorMsg += "<br>-Valid DateTime format!";
                }
                else
                {
                    // Invalid
                    panelAlert.Visible = true;
                    errorMsg += "<br>-  Invalid DateTime format!"; // **************** not fully working!!!!!
                }
                lblMsg.Text = errorMsg;
            }
            else
            {
                // Yay :)
                string studentView = "False";
                string lecturerView = "False";
                if (cbStudents.Checked == true)
                {
                    studentView = "True";
                }
                if (cbLecturers.Checked == true)
                {
                    lecturerView = "True";
                }
                AnnouncementDAO.insertAnnouncement(tbTitle.Text, tbMessage.Text, Convert.ToInt32(ddlTripName.SelectedValue.ToString()), Session["staffID"].ToString(), studentView, lecturerView, tbTimeDue.Text);
                panelSuccess.Visible = true;
                panelAlert.Visible = false;
                lblSuccess.ForeColor = System.Drawing.Color.Green;
                lblSuccess.Text = "Announcement created successfully!!";
                
            }
        }
    }
}