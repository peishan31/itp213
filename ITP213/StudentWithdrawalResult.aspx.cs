using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class StudentWithdrawalResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RepeaterStudyTrips.DataSource = WithdrawalRequestDAO.displayStudentWithdrawalRequest(Session["adminNo"].ToString());
                RepeaterStudyTrips.DataBind();
            }
        }
    }
}