using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class ViewInjuryReport : System.Web.UI.Page
    {
        public string lblStudentName;
        public string lblDateTimeInjury;
        public string lblLocation;
        public string lblTrip;
        public string lblNatureOfInjury;
        public string lblCauseOfInjury;
        public string lblLocationOnBody;
        public string lblAgency;
        public string lblFirstAidGiven;
        public string lblFirstAiderName;
        public string lblTreatment;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["accountType"].ToString() == "lecturer")
            //{
            if (!Page.IsPostBack)
            {
                if (ReportInjuryDAO.getAllReports() == null)
                {
                    PanelViewInjury.Visible = true;
                }
                else
                {
                    PanelViewInjury.Visible = false;
                    RepeaterViewInjury.DataSource = ReportInjuryDAO.getAllReports();
                    RepeaterViewInjury.DataBind();
                }
            }
            
            //}
        }

        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "trips_Click")
            {
                string name = e.CommandArgument.ToString();
                lblTesting.Text = name;
                Response.Redirect("/ReportInjury.aspx?injuryReportID=" + name);
            }
        }

        protected void btnDelete_command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "trips_Click")
            {
                string name = e.CommandArgument.ToString();
                lblTesting.Text = name;
                DAL.ReportInjuryDAO.deleteById(Convert.ToInt32(name));
                Response.Redirect("/ViewInjuryReport.aspx");
            }
        }

        protected void RepeaterViewInjury_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
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

            // Delete if it fails
            Button informB = (Button)item.FindControl("btnSendReportViaSMS");
            lblStudentName = ((Label)item.FindControl("lblStudentName")).Text.Trim();
            lblDateTimeInjury = ((Label)item.FindControl("lblDateTimeInjury")).Text.Trim();
            lblLocation = ((Label)item.FindControl("lblLocation")).Text.Trim();
            lblTrip = ((Label)item.FindControl("lblTrip")).Text.Trim();
            lblNatureOfInjury = ((Label)item.FindControl("lblNatureOfInjury")).Text.Trim();
            lblCauseOfInjury = ((Label)item.FindControl("lblCauseOfInjury")).Text.Trim();
            lblLocationOnBody = ((Label)item.FindControl("lblLocationOnBody")).Text.Trim();
            lblAgency = ((Label)item.FindControl("lblAgency")).Text.Trim();
            lblFirstAidGiven = ((Label)item.FindControl("lblFirstAidGiven")).Text.Trim();
            lblFirstAiderName = ((Label)item.FindControl("lblFirstAiderName")).Text.Trim();
            lblTreatment = ((Label)item.FindControl("lblTreatment")).Text.Trim();

            informB.OnClientClick = $"return confirm('Dear Parents,<br>{lblStudentName} has been injured on {lblDateTimeInjury}. Below are the details:<br>Location: {lblLocation}<br>Nature of injury: {lblNatureOfInjury}<br>Cause of injury: {lblNatureOfInjury}<br>Location: {lblLocationOnBody}');";
        }

        protected void btnSendReportViaSMS_Click(object sender, EventArgs e)
        {
            /*lblTesting.Text = $"Dear Parents,<br>"+
                $" has been injured on 31/12/2018 3:29:00AM in 2019-China Trip (Immersion Trip)." +
                "Below are the details:<br>Location: Space"
                +"<br>Nature of injury: Burn"
                +"<br>Cause of injury: Pouring hot drinks"
                +"<br>Location: Forearm<br>Agency: Hot water"
                +"<br>First Aid Given: No"
                + "<br>First Aider name: Lin Peishan"
                +"<br>Treatment: null";*/
        }

        protected void btnSendReport_command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "informParent")
            {
                foreach (RepeaterItem item in RepeaterViewInjury.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                       /*ar lblStudentName = (Label)item.FindControl("lblStudentName");
                        var lblDateTimeInjury = (Label)item.FindControl("lblDateTimeInjury");
                        var lblLocation = (Label)item.FindControl("lblLocation");
                        var lblTrip = (Label)item.FindControl("lblTrip");
                        var lblNatureOfInjury = (Label)item.FindControl("lblNatureOfInjury");
                        var lblCauseOfInjury = (Label)item.FindControl("lblCauseOfInjury");
                        var lblLocationOnBody = (Label)item.FindControl("lblLocationOnBody");
                        var lblAgency = (Label)item.FindControl("lblAgency");
                        var lblFirstAidGiven = (Label)item.FindControl("lblFirstAidGiven");
                        var lblFirstAiderName = (Label)item.FindControl("lblFirstAiderName");
                        var lblTreatment = (Label)item.FindControl("lblTreatment");*/

                        lblTesting.Text = $"Dear Parents,<br>" +
                        $"{lblStudentName} has been injured on {lblDateTimeInjury} in {lblTrip}." +
                        $"Below are the details:<br>Location: {lblLocation}"
                        + $"<br>Nature of injury: {lblNatureOfInjury}"
                        + $"<br>Cause of injury: {lblCauseOfInjury}"
                        + $"<br>Location: {lblLocationOnBody}"+$"<br>Agency: {lblAgency}"
                        + $"<br>First Aid Given: {lblFirstAidGiven}"
                        + $"<br>First Aider name: {lblFirstAiderName}"
                        + $"<br>Treatment: {lblTreatment}";
                    }
                }
            }
            //=================================================================================
            // ***************************** DO NOT DELETE 
            /*SMSSvrRef.SMSSoapClient S = new SMSSvrRef.SMSSoapClient();
            try
            {
                string display = S.sendMessage("EADPJ47", "061785", "83997254", "Hi");
                lblTesting.Text = display;
            }
            catch (Exception error)
            {
                lblTesting.Text = error.Message;
            }*/
            //=================================================================================
        }
    }
}