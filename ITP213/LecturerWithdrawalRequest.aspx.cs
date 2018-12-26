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
            if (Session["accountType"].ToString() == "lecturer")
            {
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
    }
}