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
                        
                        if (TripAllocationDAO.displayPastStudyTripsBasedOnAdminNo(Session["adminNo"].ToString()) == null)
                        {
                            lblPastStudyTripMsg.Visible = true;
                        }
                        else
                        {
                            lblPastStudyTripMsg.Visible = false;
                            RepeaterPastStudyTrips.DataSource = TripAllocationDAO.displayPastStudyTripsBasedOnAdminNo(Session["adminNo"].ToString());
                            RepeaterPastStudyTrips.DataBind();
                        }
                    }
                    if (TripAllocationDAO.displayImmersionTripsBasedOnAdminNo(Session["adminNo"].ToString()) == null)
                    {
                        PanelImmersionTrips.Visible = true;
                    }
                    else
                    {
                        RepeaterImmersionTrips.DataSource = TripAllocationDAO.displayImmersionTripsBasedOnAdminNo(Session["adminNo"].ToString());
                        RepeaterImmersionTrips.DataBind();

                        if (TripAllocationDAO.displayPastImmersionTripsBasedOnAdminNo(Session["adminNo"].ToString()) == null)
                        {
                            lblPastImmersionTripMsg.Visible = true;
                        }
                        else
                        {
                            lblPastImmersionTripMsg.Visible = false;
                            RepeaterPastImmersionTrips.DataSource = TripAllocationDAO.displayPastImmersionTripsBasedOnAdminNo(Session["adminNo"].ToString());
                            RepeaterPastImmersionTrips.DataBind();
                        }
                    }
                }
                /*else if (Session["accountType"].ToString() == "parent")
                {
                    if (TripAllocationDAO.displayStudyTripsBasedOnAdminNo(Session["adminNo"].ToString()) == null)
                    {
                        PanelStudyTrips.Visible = true;
                    }
                    else
                    {
                        RepeaterStudyTrips.DataSource = TripAllocationDAO.displayStudyTripsBasedOnAdminNo(Session["adminNo"].ToString());
                        RepeaterStudyTrips.DataBind();

                        RepeaterPastStudyTrips.DataSource = TripAllocationDAO.displayPastStudyTripsBasedOnAdminNo(Session["adminNo"].ToString());
                        RepeaterPastStudyTrips.DataBind();
                    }
                    if (TripAllocationDAO.displayImmersionTripsBasedOnAdminNo(Session["adminNo"].ToString()) == null)
                    {
                        PanelImmersionTrips.Visible = true;
                    }
                    else
                    {
                        RepeaterImmersionTrips.DataSource = TripAllocationDAO.displayImmersionTripsBasedOnAdminNo(Session["adminNo"].ToString());
                        RepeaterImmersionTrips.DataBind();

                        RepeaterPastImmersionTrips.DataSource = TripAllocationDAO.displayPastImmersionTripsBasedOnAdminNo(Session["adminNo"].ToString());
                        RepeaterPastImmersionTrips.DataBind();
                    }
                }*/
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

                        if (TripAllocationDAO.displayPastStudyTripsBasedOnStaffID(Session["staffID"].ToString()) == null)
                        {
                            lblPastStudyTripMsg.Visible = true;
                        }
                        else
                        {
                            lblPastStudyTripMsg.Visible = false;
                            RepeaterPastStudyTrips.DataSource = TripAllocationDAO.displayPastStudyTripsBasedOnStaffID(Session["staffID"].ToString());
                            RepeaterPastStudyTrips.DataBind();
                        }
                    }
                    if (TripAllocationDAO.displayImmersionTripsBasedOnStaffID(Session["staffID"].ToString()) == null)
                    {
                        PanelImmersionTrips.Visible = true;
                    }
                    else
                    {
                        RepeaterImmersionTrips.DataSource = TripAllocationDAO.displayImmersionTripsBasedOnStaffID(Session["staffID"].ToString());
                        RepeaterImmersionTrips.DataBind();

                        if (TripAllocationDAO.displayPastImmersionTripsBasedOnStaffID(Session["staffID"].ToString()) == null)
                        {
                            lblPastImmersionTripMsg.Visible = true;
                        }
                        else
                        {
                            lblPastImmersionTripMsg.Visible = false;
                            RepeaterPastImmersionTrips.DataSource = TripAllocationDAO.displayPastImmersionTripsBasedOnStaffID(Session["staffID"].ToString());
                            RepeaterPastImmersionTrips.DataBind();
                        }
                    }
                }
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
                    // **** to redirect to test
                    //if (Session["accountType"].ToString() == "lecturer") 
                    //{
                    //Response.Redirect("/lec.aspx?tripID=" + name);
                    //}

                    //******************* shang ji: TEST
                    /*if (Session["accountType"].ToString() == "student")
                    {
                        Response.Redirect("/stud.aspx?tripID=" + name); // do test
                    }*/
                    Response.Redirect("/ViewIndividualTrip.aspx?tripID=" + name);
                        
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

        protected void CreateTest_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "trips_Click")
            {
                string name = e.CommandArgument.ToString();
                lblTesting.Text = name;
                //***** shang ji: TEST
                Response.Redirect("/test.aspx?tripID=" + name);
            }
        }


        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
        }

        protected void RepeaterStudyTrip_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;

            // parent, student
            Button withdrawB = (Button)item.FindControl("btnStudyTripsWithdraw");
            // lecturer
            Button createB = (Button)item.FindControl("btnCreateTest");
            Button editB = (Button)item.FindControl("btnStudyTripsEdit");
            Button deleteB = (Button)item.FindControl("btnStudyTripsDelete");

            if (Session["accountType"].ToString() == "parent" || Session["accountType"].ToString() == "student")
            {
                withdrawB.Visible = true;
                createB.Visible = false;
                editB.Visible = false;
                deleteB.Visible = false;
            }
            else
            {
                withdrawB.Visible = false;
                createB.Visible = true;
                editB.Visible = true;
                deleteB.Visible = true;
            }
        }

        protected void RepeaterImmersionTrip_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            // parent, student
            Button withdrawB = (Button)item.FindControl("btnImmersionTripsWithdraw");
            // lecturer
            Button createB = (Button)item.FindControl("btnCreateTest");
            Button editB = (Button)item.FindControl("btnImmersionTripsEdit");
            Button deleteB = (Button)item.FindControl("btnImmersionTripsDelete");

            if (Session["accountType"].ToString() == "parent" || Session["accountType"].ToString() == "student")
            {
                withdrawB.Visible = true;
                createB.Visible = false;
                editB.Visible = false;
                deleteB.Visible = false;
            }
            else
            {
                withdrawB.Visible = false;
                createB.Visible = true;
                editB.Visible = true;
                deleteB.Visible = true;
            }
        }

        protected void RepeaterPastStudyTrips_Command(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "trips_Click")
                {
                    string name = e.CommandArgument.ToString();
                    lblTesting.Text = name;
                    // **** to redirect to test
                    //if (Session["accountType"].ToString() == "lecturer") 
                    //{
                    //Response.Redirect("/lec.aspx?tripID=" + name);
                    //}

                    //******************* shang ji: TEST
                    /*if (Session["accountType"].ToString() == "student")
                    {
                        Response.Redirect("/stud.aspx?tripID=" + name); // do test
                    }*/
                    Response.Redirect("/ViewIndividualTrip.aspx?tripID=" + name);

                }
            }
        }
    }
}