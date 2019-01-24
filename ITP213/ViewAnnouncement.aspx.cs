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
                if (Session["accountType"] != null)
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
                        }

                        if (AnnouncementDAO.getImmersionTripAnnouncementByStaffID(Session["staffID"].ToString()) == null)
                        {
                            PanelImmersionTrips.Visible = true;
                        }
                        else
                        {
                            RepeaterImmersionTrips.DataSource = AnnouncementDAO.getImmersionTripAnnouncementByStaffID(Session["staffID"].ToString());
                            RepeaterImmersionTrips.DataBind();


                        }

                        // for withdrawal request
                        if (WithdrawalRequestDAO.displayWithdrawalRequest(Session["staffID"].ToString()) == null)
                        {
                            PanelEmptyWithdrawalRequest.Visible = true;
                        }
                        else
                        {
                            RepeaterWithdrawalRequest.DataSource = WithdrawalRequestDAO.displayWithdrawalRequest(Session["staffID"].ToString());
                            RepeaterWithdrawalRequest.DataBind();

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


                        }
                        if (AnnouncementDAO.getImmersionTripAnnouncementByAdminNo(Session["adminNo"].ToString()) == null)
                        {
                            PanelImmersionTrips.Visible = true;
                        }
                        else
                        {
                            RepeaterImmersionTrips.DataSource = AnnouncementDAO.getImmersionTripAnnouncementByAdminNo(Session["adminNo"].ToString());
                            RepeaterImmersionTrips.DataBind();
                        }

                    }
                }else
                {
                    Response.Redirect("/login.aspx");
                }   
                
            }
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

        protected void RepeaterWithdrawalRequest_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "trips_Click")
                {
                    string name = e.CommandArgument.ToString();
                    lblTesting.Text = name;
                }
            }
        }

        protected void btnApproved_Click(object sender, EventArgs e)
        {

        }

        protected void btnRejected_Click(object sender, EventArgs e)
        {

        }

        protected void btnApproved_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "trips_Click")
            {
                string name = e.CommandArgument.ToString();
                lblTesting.Text = name;
                WithdrawalRequestDAO.approveTripRequestByWithdrawTripRequestID(Convert.ToInt32(name));
            }
        }

        protected void btnRejected_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "trips_Click")
            {
                string name = e.CommandArgument.ToString();
                lblTesting.Text = name;
                WithdrawalRequestDAO.rejectTripRequestByWithdrawTripRequestID(Convert.ToInt32(name));
            }
        }

        protected void cbSelector_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        protected void cbRead_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            lblTesting.Text = chk.Checked.ToString();
        }

        protected void RepeaterStudyTrips_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (Session["accountType"].ToString() == "lecturer")
            {
                RepeaterItem item = e.Item;
                Label lblStaffID = (Label)item.FindControl("lblStaffIDForEditAndDeleteBtn");
                string createdBy = lblStaffID.Text;
                string currentID = Session["staffID"].ToString();

                Button editB = (Button)item.FindControl("btnStudyTripsEdit");
                Button deleteB = (Button)item.FindControl("btnStudyTripsDelete");

                int i = 0;

                if (createdBy == currentID)
                {
                    editB.Visible = true;
                    deleteB.Visible = true;
                }
                else
                {
                    editB.Visible = false;
                    deleteB.Visible = false;
                }
            }
            /*
             RepeaterItem item = e.Item;
            Label tempL = (Label)item.FindControl("Label20");
            string createdBy = tempL.Text;
            string currentID = Session["staffID"].ToString();

            Button editB = (Button)item.FindControl("btnStudyTripsEdit");
            Button deleteB = (Button)item.FindControl("btnStudyTripsDelete");

            int i = 0;

            if (createdBy == currentID)
            {
                editB.Visible = true;
                deleteB.Visible = true;
            }
            else
            {
                editB.Visible = false;
                deleteB.Visible = false;
            }
             */
        }

        protected void RepeaterImmersionTrips_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (Session["accountType"].ToString() == "lecturer")
            {
                RepeaterItem item = e.Item;
                Label lblStaffID = (Label)item.FindControl("lblStaffIDForEditAndDeleteBtn");
                string createdBy = lblStaffID.Text;
                string currentID = Session["staffID"].ToString();

                Button editB = (Button)item.FindControl("btnImmersionTripsEdit");
                Button deleteB = (Button)item.FindControl("btnImmersionTripsDelete");

                int i = 0;

                if (createdBy == currentID)
                {
                    editB.Visible = true;
                    deleteB.Visible = true;
                }
                else
                {
                    editB.Visible = false;
                    deleteB.Visible = false;
                }
            }
        }

        protected void cbRead_CheckedChanged1(object sender, EventArgs e)
        {
            var chk = (CheckBox)sender;
            var announcementID = chk.Attributes["CommandName"];
            lblTesting.Text = announcementID.ToString();
            AnnouncementDAO.updateAnnouncementVisibleByAnnouncementID(Convert.ToInt32(announcementID));
            //chk.Visible = false;
            Response.Redirect("/ViewAnnouncement.aspx");
        }
    }
}