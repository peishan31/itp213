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

                    Announcement a = AnnouncementDAO.getAnnouncementByAdminNo(Convert.ToInt32(id));

                    tbTitle.Text = a.announcementTitle;
                    tbMessage.Text = a.announcementMessage;
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (btnCreate.Text == "Update")
            {
                string id = Request.QueryString["AnnouncementID"];
                string msg = tbMessage.Text;
                string title = tbTitle.Text;
                AnnouncementDAO.updateById(Convert.ToInt32(id), title, msg);
                Response.Redirect("ViewAnnouncement.aspx");
            }
            if ((string.IsNullOrEmpty(tbMessage.Text)) || (string.IsNullOrEmpty(tbTitle.Text)) || (ddlGroup.SelectedItem.Text == "--Select--") || (cbLecturers.Checked == false && cbStudents.Checked == false))
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                string errorMsg = "Sorry please ensure that you have entered everything correctly:";
                if (ddlGroup.SelectedItem.Text == "--Select--")
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
                lblMsg.Text = errorMsg;
            }
            else
            {
                AnnouncementDAO.insertAnnouncement(tbTitle.Text, tbMessage.Text);
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Announcement created successfully!!";
            }
        }
    }
}