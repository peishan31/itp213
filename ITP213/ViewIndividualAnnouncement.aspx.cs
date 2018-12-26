using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class ViewIndividualAnnouncement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["AnnouncementID"];
            //=============================================================================================================================
            Announcement obj = AnnouncementDAO.getAnnouncementByAnnouncementID(Convert.ToInt32(id)); 
            lblAnnouncementTitle.Text = obj.announcementTitle;
            lblAnnouncementMessage.Text = obj.announcementMessage;
            //=============================================================================================================================
        }

        //protected void btnDelete(object sender, EventArgs e)
        //{
            
        //}

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["AnnouncementID"];
            AnnouncementDAO.deleteById(Convert.ToInt32(id));
            Response.Redirect("ViewAnnouncement.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["AnnouncementID"];
            //AnnouncementDAO.updateById(Convert.ToInt32(id), )
            Response.Redirect("CreateAnnouncement.aspx?AnnouncementID=" + id);
        }
    }
}