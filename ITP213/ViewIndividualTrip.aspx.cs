using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class ViewIndividualTrip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Request.QueryString["tripID"] != null)
                {   
                    int tripID = Convert.ToInt32(Request.QueryString["tripID"]);
                    DAL.TripAllocation obj = TripAllocationDAO.getTripByTripID(tripID);
                    lblTripName.Text = obj.tripName;
                    lblTripName2.Text = obj.tripName;

                    RepeaterIndividualTrip.DataSource = TripAllocationDAO.getTripDetailsByTripIDForViewInividualTrip(tripID);
                    RepeaterIndividualTrip.DataBind();

                    RepeaterStudentName.DataSource = TripAllocationDAO.getEnrolledStudentNameByTripIDForViewInividualTrip(tripID);
                    RepeaterStudentName.DataBind();

                    RepeaterStaffName.DataSource = TripAllocationDAO.getEnrolledLecturerNameByTripIDForViewInividualTrip(tripID);
                    RepeaterStaffName.DataBind();
                }
            }
        }
    }
}