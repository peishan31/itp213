using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class ViewAllocatedTrip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // first load of the page
            {
                string CreateTripStatus = Request.QueryString["CreateTripStatus"];

                if (CreateTripStatus != null)
                {
                    panelAlert.Visible = true;
                }
                else
                {
                    panelAlert.Visible = false;
                }
                if (Session["accountType"].ToString() == "student")
                {
                    if (TripAllocationDAO.displayStudyTripsBasedOnAdminNo(Session["adminNo"].ToString()) == null)
                    {
                        PanelStudyTrips.Visible = true;
                    }
                    else
                    {
                        RepeaterStudyTrips.DataSource = TripAllocationDAO.displayStudyTripsBasedOnAdminNo(Session["adminNo"].ToString());
                        RepeaterStudyTrips.DataBind();
                    }
                    if (TripAllocationDAO.displayImmersionTripsBasedOnAdminNo(Session["adminNo"].ToString()) == null)
                    {
                        PanelImmersionTrips.Visible = true;
                    }
                    else
                    {
                        RepeaterImmersionTrips.DataSource = TripAllocationDAO.displayImmersionTripsBasedOnAdminNo(Session["adminNo"].ToString());
                        RepeaterImmersionTrips.DataBind();
                    }
                }
                else if (Session["accountType"].ToString() == "parent")
                {
                    if (TripAllocationDAO.displayStudyTripsBasedOnAdminNo(Session["adminNo"].ToString()) == null)
                    {
                        PanelStudyTrips.Visible = true;
                    }
                    else
                    {
                        RepeaterStudyTrips.DataSource = TripAllocationDAO.displayStudyTripsBasedOnAdminNo(Session["adminNo"].ToString());
                        RepeaterStudyTrips.DataBind();
                    }
                    if (TripAllocationDAO.displayImmersionTripsBasedOnAdminNo(Session["adminNo"].ToString()) == null)
                    {
                        PanelImmersionTrips.Visible = true;
                    }
                    else
                    {
                        RepeaterImmersionTrips.DataSource = TripAllocationDAO.displayImmersionTripsBasedOnAdminNo(Session["adminNo"].ToString());
                        RepeaterImmersionTrips.DataBind();
                    }
                }
                else if (Session["accountType"].ToString() == "lecturer")
                {
                    if (TripAllocationDAO.displayStudyTripsBasedOnStaffID(Session["staffID"].ToString()) == null)
                    {
                        PanelStudyTrips.Visible = true;
                    }
                    else
                    {
                        RepeaterStudyTrips.DataSource = TripAllocationDAO.displayStudyTripsBasedOnStaffID(Session["staffID"].ToString());
                        RepeaterStudyTrips.DataBind();
                    }
                    if (TripAllocationDAO.displayImmersionTripsBasedOnStaffID(Session["staffID"].ToString()) == null)
                    {
                        PanelImmersionTrips.Visible = true;
                    }
                    else
                    {
                        RepeaterImmersionTrips.DataSource = TripAllocationDAO.displayImmersionTripsBasedOnStaffID(Session["staffID"].ToString());
                        RepeaterImmersionTrips.DataBind();
                    }
                }
                /*
                if (Session["accountType"].ToString() == "parent")
                {
                    lblTitle.Text = Session["adminNo"].ToString();
                }
                else if (Session["accountType"].ToString() == "lecturer")
                {
                    lblTitle.Text = $"staffID:{Session["staffID"].ToString()}, lecturerSchool: {Session["school"].ToString()}, staffRole: {Session["staffRole"].ToString()}";
                }
                else if (Session["accountType"].ToString() == "student")
                {
                    lblTitle.Text = $"adminNo:{Session["adminNo"]}";
                }    
                */
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e) // for repeater study trip
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

        protected void btnStudyTripsWithdraw_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnStudyTrips_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "trips_Click")
            {
                string name = e.CommandArgument.ToString();
                lblTesting.Text = name;
                Response.Redirect("/StudentWithdrawalRequest.aspx?tripID="+name);
            }
        }

        protected void EditTrip_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "trips_Click")
            {
                string name = e.CommandArgument.ToString();
                lblTesting.Text = name;
                Response.Redirect("/TripAllocation.aspx?tripID=" + name);
            }
        }

        protected void delete_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "trips_Click")
            {
                string name = e.CommandArgument.ToString();
                lblTesting.Text = name;
                DAL.TripAllocationDAO.deleteById(Convert.ToInt32(name));
                Response.Redirect("/ViewAllocatedTrip.aspx");
            }
        }
    }
}