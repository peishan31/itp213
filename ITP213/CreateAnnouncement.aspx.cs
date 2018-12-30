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

                    Announcement obj = DAL.AnnouncementDAO.getAnnouncementByAnnouncementID(Convert.ToInt32(id));

                    tbTitle.Text = obj.announcementTitle;
                    tbMessage.Text = obj.announcementMessage;
                    tbTimeDue.Text = obj.timeDue;
                    if (obj.studentView == "True")
                    {
                        cbStudents.Checked = true;
                    }
                    if (obj.lecturerView == "True")
                    {
                        cbLecturers.Checked = true;
                    }
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
                //tbTitle.Text, tbMessage.Text, Convert.ToInt32(ddlTripName.SelectedValue.ToString()), Session["staffID"].ToString(), studentView, lecturerView, tbTimeDue.Text
                AnnouncementDAO.updateById(Convert.ToInt32(ddlTripName.SelectedValue.ToString()), Convert.ToInt32(id), title, msg, Convert.ToDateTime(tbTimeDue.Text), studentView, lecturerView);
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
                /*try
                {
                    DateTime temp = Convert.ToDateTime(tbTimeDue.Text);
                }
                catch
                {
                    errorMsg += "<br>-  Invalid DateTime format!"; // **************** not fully working!!!!!
                }*/
                /*
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
                }*/
                
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

                // Yay :)
                if (errorMsg == "Sorry please ensure that you have entered everything correctly:")
                {
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
                    AnnouncementDAO.insertAnnouncement(tbTitle.Text, tbMessage.Text, Convert.ToInt32(ddlTripName.SelectedValue.ToString()), Session["staffID"].ToString(), studentView, lecturerView, tbTimeDue.Text, Session["staffID"].ToString());
                    panelSuccess.Visible = true;
                    panelAlert.Visible = false;
                    lblSuccess.ForeColor = System.Drawing.Color.Green;
                    lblSuccess.Text = "Announcement created successfully!!";
                }
                else
                {
                    panelAlert.Visible = true;
                    lblMsg.Text = errorMsg;
                }
        }
    }
}