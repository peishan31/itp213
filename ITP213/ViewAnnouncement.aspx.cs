using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class ViewAnnouncement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["accountType"].ToString() == "lecturer")
                {
                    if (AnnouncementDAO.getStudyTripAnnouncementByStaffID(Session["staffID"].ToString()) == null)
                    {
                        PanelStudyTrips.Visible = true;
                    }
                    else
                    {
                        RepeaterStudyTrips.DataSource = AnnouncementDAO.getStudyTripAnnouncementByStaffID(Session["staffID"].ToString());
                        RepeaterStudyTrips.DataBind();

                        RepeaterStudyTripsPastAnnouncement.DataSource = AnnouncementDAO.getStudyTripPastAnnouncementByStaffID(Session["staffID"].ToString());
                        RepeaterStudyTripsPastAnnouncement.DataBind();
                    }

                    if (AnnouncementDAO.getImmersionTripAnnouncementByStaffID(Session["staffID"].ToString()) == null)
                    {
                        PanelImmersionTrips.Visible = true;
                    }
                    else
                    {
                        RepeaterImmersionTrips.DataSource = AnnouncementDAO.getImmersionTripAnnouncementByStaffID(Session["staffID"].ToString());
                        RepeaterImmersionTrips.DataBind();

                        RepeaterImmersionTripsPastAnnouncement.DataSource = AnnouncementDAO.getImmersionTripPastAnnouncementByStaffID(Session["staffID"].ToString());
                        RepeaterImmersionTripsPastAnnouncement.DataBind();
                    }
                    
                }
                else if (Session["accountType"].ToString() == "student")
                {
                    if (AnnouncementDAO.getStudyTripAnnouncementByAdminNo(Session["adminNo"].ToString()) == null)
                    {
                        PanelStudyTrips.Visible = true;
                    }
                    else
                    {
                        RepeaterStudyTrips.DataSource = AnnouncementDAO.getStudyTripAnnouncementByAdminNo(Session["adminNo"].ToString());
                        RepeaterStudyTrips.DataBind();

                        RepeaterStudyTripsPastAnnouncement.DataSource = AnnouncementDAO.getStudyTripPastAnnouncementByAdminNo(Session["adminNo"].ToString());
                        RepeaterStudyTripsPastAnnouncement.DataBind();
                    }
                    if (AnnouncementDAO.getImmersionTripAnnouncementByAdminNo(Session["adminNo"].ToString()) == null)
                    {
                        PanelImmersionTrips.Visible = true;
                    }
                    else
                    {
                        RepeaterImmersionTrips.DataSource = AnnouncementDAO.getImmersionTripAnnouncementByAdminNo(Session["adminNo"].ToString());
                        RepeaterImmersionTrips.DataBind();

                        RepeaterImmersionTripsPastAnnouncement.DataSource = AnnouncementDAO.getImmersionTripPastAnnouncementByAdminNo(Session["adminNo"].ToString());
                            // AnnouncementDAO.getImmersionTripAnnouncementByAdminNo(Session["adminNo"].ToString());
                        RepeaterImmersionTripsPastAnnouncement.DataBind();
                    }
                }
            }
             
            //=============================================================================================================================
            /*Announcement obj = AnnouncementDAO.getAnnouncementByAdminNo(Convert.ToInt32("17")); 
            lblAnnouncementTitle.Text = obj.announcementTitle;
            lblAnnouncementMessage.Text = obj.announcementMessage;*/
            //=============================================================================================================================
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnEditTrip_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "trips_Click")
            {
                string announcementID = e.CommandArgument.ToString();
                Response.Redirect("CreateAnnouncement.aspx?AnnouncementID=" + announcementID);
            }
        }

        protected void btnStudyTrips_Command(object sender, CommandEventArgs e) // for deletion
        {
            if (e.CommandName == "trips_Click")
            {
                string announcementID = e.CommandArgument.ToString();
                lblTesting.Text = announcementID;
                AnnouncementDAO.deleteById(Convert.ToInt32(announcementID));
                Response.Redirect("/ViewAnnouncement.aspx");
            }
        }

        protected void RepeaterStudyTrips_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "trips_Click")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                //Response.Redirect("ViewIndividualAnnouncement.aspx?AnnouncementID=" + index);
            }
        }

        protected void RepeaterImmersionTrips_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "trips_Click")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                //Response.Redirect("ViewIndividualAnnouncement.aspx?AnnouncementID=" + index);
            }
        }
    }
}