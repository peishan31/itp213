using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class LecturerWithdrawalRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["accountType"].ToString() == "lecturer")
                {
                    // for withdrawal request
                    if (WithdrawalRequestDAO.displayWithdrawalRequest(Session["staffID"].ToString()) == null)
                    {
                        PanelEmptyWithdrawalRequest.Visible = true;
                    }
                    else
                    {
                        PanelEmptyWithdrawalRequest.Visible = false;
                        RepeaterWithdrawalRequest.DataSource = WithdrawalRequestDAO.displayWithdrawalRequest(Session["staffID"].ToString());
                        RepeaterWithdrawalRequest.DataBind();

                    }
                }

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

        protected void btnApproved_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "trips_Click")
            {
                string name = e.CommandArgument.ToString();
                lblTesting.Text = name;
                WithdrawalRequestDAO.approveTripRequestByWithdrawTripRequestID(Convert.ToInt32(name));
            }
        }

        protected void btnRejected_Click(object sender, EventArgs e)
        {

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
    }
}