using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["name"] != null)
                {
                    lblName.Text = Session["name"].ToString();
                    if (Session["accountType"].ToString() == "lecturer")
                    {
                        if (AnnouncementDAO.getUnreadAnnouncementCountByStaffID(Session["staffID"].ToString()) == null)
                        {
                            PanelAnnouncement.Visible = false;
                            badgeUnreadCount.Visible = false;
                        }
                        else
                        {
                            PanelAnnouncement.Visible = true;
                            badgeUnreadCount.Visible = true;
                            RepeaterUnreadCount.DataSource = AnnouncementDAO.getUnreadAnnouncementCountByStaffID(Session["staffID"].ToString());
                            RepeaterUnreadCount.DataBind();
                        }
                    }
                    else if (Session["accountType"].ToString() == "student")
                    {
                        if (AnnouncementDAO.getUnreadAnnouncementCountByAdminNo(Session["adminNo"].ToString()) == null)
                        {
                            PanelAnnouncement.Visible = false;
                            badgeUnreadCount.Visible = false;
                        }
                        else
                        {
                            PanelAnnouncement.Visible = true;
                            badgeUnreadCount.Visible = true;
                            RepeaterUnreadCount.DataSource = AnnouncementDAO.getUnreadAnnouncementCountByAdminNo(Session["adminNo"].ToString());
                            RepeaterUnreadCount.DataBind();
                        }
                    }
                    else if (Session["accountType"].ToString() == "parent")
                    {
                        RepeaterUnreadCount.DataSource = AnnouncementDAO.getUnreadAnnouncementCountByAdminNo(Session["adminNo"].ToString());
                        RepeaterUnreadCount.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
                
            }
           
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {

        }

        protected void RepeaterUnreadMsg_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Session["accountType"].ToString() == "lecturer")
            {
                if (AnnouncementDAO.getUnreadAnnouncementCountByStaffID(Session["staffID"].ToString()) == null)
                {
                    PanelAnnouncement.Visible = false;
                    badgeUnreadCount.Visible = false;
                }
                else
                {
                    PanelAnnouncement.Visible = true;
                    badgeUnreadCount.Visible = true;
                }
            }
            else if (Session["accountType"].ToString() == "student")
            {
                if (AnnouncementDAO.getUnreadAnnouncementCountByAdminNo(Session["adminNo"].ToString()) == null)
                {
                    PanelAnnouncement.Visible = false;
                    badgeUnreadCount.Visible = false;
                }
                else
                {
                    PanelAnnouncement.Visible = true;
                    badgeUnreadCount.Visible = true;
                }
            }
            else if (Session["accountType"].ToString() == "parent")
            {
                if (AnnouncementDAO.getUnreadAnnouncementCountByAdminNo(Session["adminNo"].ToString()) == null)
                {
                    PanelAnnouncement.Visible = false;
                    badgeUnreadCount.Visible = false;
                }
                else
                {
                    PanelAnnouncement.Visible = true;
                    badgeUnreadCount.Visible = true;
                }
            }
        }
    }
}