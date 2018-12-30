using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class ReportInjury : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["accountType"].ToString() == "lecturer")
                {

                    ddlTrip.DataSource = AnnouncementDAO.displayAllocatedTrips(Session["staffID"].ToString());
                    ddlTrip.DataTextField = "tripNameAndTripType";
                    ddlTrip.DataValueField = "tripID";
                    ddlTrip.DataBind();

                    string reportInjuryID = Request.QueryString["injuryReportID"];
                    if (reportInjuryID != null)
                    {
                        DAL.ReportInjury obj = ReportInjuryDAO.getInjuryReportByID(Convert.ToInt32(reportInjuryID));
                        tbDateTimeOfInjury.Text = obj.dateTimeOfInjury.ToString();
                        tbLocation.Text = obj.location.ToString();
                        tbDescription.Text = obj.description.ToString();
                        tbWitnessName.Text = obj.witnessName.ToString();
                        tbWitnessPhone.Text = obj.witnessPhone.ToString();
                        tbNatureOfInjury.Text = obj.natureOfInjury.ToString();
                        tbCauseOfInjury.Text = obj.causeOfInjury.ToString();
                        tbLocationOfBody.Text = obj.locationOnBody.ToString();
                        tbAgency.Text = obj.agency.ToString();
                        if (obj.firstAidGiven.ToString() == "Yes")
                        {
                            rbFirstAidGiven.SelectedIndex = 0;
                        }
                        else if (obj.firstAidGiven.ToString() == "No")
                        {
                            rbFirstAidGiven.SelectedIndex = 1;
                        }
                        tbFirstAiderName.Text = obj.firstAiderName.ToString();
                        tbTreatment.Text = obj.treatment.ToString();

                        ddlTrip.SelectedValue = obj.tripID.ToString();
                        ddlName.DataSource = ReportInjuryDAO.getStudentName(Convert.ToInt32(obj.tripID));
                        ddlName.DataTextField = "name";
                        ddlName.DataValueField = "adminNo";
                        ddlName.DataBind();
                        ddlName.SelectedValue = obj.adminNo.ToString();
                        //tbWitnessName.Text = obj.name.ToString();
                        btnSubmit.Text = "Update";
                    }
                }
            }
        }

        protected void ddlTrip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTrip.SelectedItem != null)
            {

                Label1.Text = ddlTrip.SelectedValue.ToString();
                //lblMsg.Text = $"{ddlCourses.SelectedValue}";

                ddlName.DataSource = ReportInjuryDAO.getStudentName(Convert.ToInt32(ddlTrip.SelectedValue));
                ddlName.DataTextField = "name";
                ddlName.DataValueField = "adminNo";
                ddlName.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            string errorMsg = "Sorry please ensure that you have entered everything correctly:";
            DateTime dateTimeOfInjury = DateTime.Now;

            if (String.IsNullOrEmpty(ddlName.SelectedValue.ToString()))
            {
                errorMsg += "<br>-Please select a student!";
            }
            if (String.IsNullOrEmpty(tbDateTimeOfInjury.Text))
            {
                errorMsg += "<br>-DateTime is empty!";
            }
            if (String.IsNullOrEmpty(tbLocation.Text))
            {
                errorMsg += "<br>-Location is empty!";
            }
            if (String.IsNullOrEmpty(tbDescription.Text))
            {
                errorMsg += "<br>-Description is empty!";
            }
            if (String.IsNullOrEmpty(tbWitnessName.Text))
            {
                errorMsg += "<br>-Witness name is empty!";
            }
            if (String.IsNullOrEmpty(tbWitnessPhone.Text))
            {
                errorMsg += "<br>-Witness phone is empty!";
            }
            if (String.IsNullOrEmpty(tbNatureOfInjury.Text))
            {
                errorMsg += "<br>-Nature of injury is empty!";
            }
            if (String.IsNullOrEmpty(tbCauseOfInjury.Text))
            {
                errorMsg += "<br>-Cause of injury is empty!";
            }
            if (String.IsNullOrEmpty(tbLocationOfBody.Text))
            {
                errorMsg += "<br>-Location of body is empty!";
            }
            if (String.IsNullOrEmpty(tbAgency.Text))
            {
                errorMsg += "<br>-Agency is empty!";
            }
            if (String.IsNullOrEmpty(rbFirstAidGiven.Text))
            {
                errorMsg += "<br>-First aid given is empty!";
            }
            

            // ***************** have not validate date time of injury!
            if (errorMsg == "Sorry please ensure that you have entered everything correctly:")
            {
                if (btnSubmit.Text == "Finish")
                {
                    panelSuccess.Visible = true;
                    panelAlert.Visible = false;
                    lblSuccess.Text = "You have successfully created your injury report";
                    ReportInjuryDAO.insert(Convert.ToString(tbDateTimeOfInjury.Text), tbLocation.Text, tbDescription.Text, tbWitnessName.Text, tbWitnessPhone.Text, tbNatureOfInjury.Text, tbCauseOfInjury.Text, tbLocationOfBody.Text, tbAgency.Text, rbFirstAidGiven.Text, tbFirstAiderName.Text, tbTreatment.Text, Session["staffID"].ToString(), ddlName.SelectedValue.ToString(), ddlName.SelectedItem.ToString(), Convert.ToInt32(ddlTrip.SelectedValue.ToString()));
                }
                else if (btnSubmit.Text == "Update")
                {
                    string reportInjuryID = Request.QueryString["injuryReportID"];
                    panelSuccess.Visible = true;
                    panelAlert.Visible = false;
                    lblSuccess.Text = "You have successfully update your injury report";
                    ReportInjuryDAO.updateInjuryReport(Convert.ToDateTime(tbDateTimeOfInjury.Text), tbLocation.Text, tbDescription.Text, tbWitnessName.Text, tbWitnessPhone.Text, tbNatureOfInjury.Text, tbCauseOfInjury.Text, tbLocationOfBody.Text, tbAgency.Text, rbFirstAidGiven.Text, tbFirstAiderName.Text, tbTreatment.Text, Session["staffID"].ToString(), ddlName.SelectedValue.ToString(), ddlName.SelectedItem.ToString(), Convert.ToInt32(ddlTrip.SelectedValue.ToString()), Convert.ToInt32(reportInjuryID));
                }
                
            }
            else
            {
                panelSuccess.Visible = false;
                panelAlert.Visible = true;
                lblError.Text = errorMsg;
            }
                
            
            
            //Label1.Text = "Announcement created successfully!!";
        }
    }
}