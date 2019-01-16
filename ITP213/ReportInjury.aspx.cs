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
                    ddlTrip.Items.Insert(0, new ListItem("--Select Trip--", "0"));
                    ddlTrip.AppendDataBoundItems = true;
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

                lblName.Visible = true;
                ddlName.Visible = true;
                ddlName.DataSource = ReportInjuryDAO.getStudentName(Convert.ToInt32(ddlTrip.SelectedValue));
                ddlName.Items.Insert(0, new ListItem("--Select Name--", "0"));
                ddlName.AppendDataBoundItems = true;
                ddlName.DataTextField = "name";
                ddlName.DataValueField = "adminNo";
                ddlName.DataBind();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // ***************** have not validate date time of injury!
            if (ValidateReportInjury())
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
        }

        private bool ValidateReportInjury()
        {
            bool result = false;
            lblError.Text = string.Empty;

            panelSuccess.Visible = false;
            panelAlert.Visible = true;

            if (ddlTrip.SelectedValue.ToString() == "0")
            {
                lblError.Text += "Please select a trip!<br>";
                ddlTrip.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                ddlTrip.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                ddlTrip.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                ddlTrip.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }
            if (ddlName.SelectedValue.ToString() == "0")
            {
                lblError.Text += "Please select a name!<br>";
                ddlName.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                ddlName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                ddlName.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                ddlName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }
            if (String.IsNullOrEmpty(ddlName.SelectedValue.ToString()))
            {
                lblError.Text += "Please select a student!<br>";
                ddlName.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                ddlName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                ddlName.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                ddlName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }
            /*if (String.IsNullOrEmpty(tbDateTimeOfInjury.Text))
            {
                lblError.Text += "DateTime is empty!<br>";
                tbDateTimeOfInjury.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                tbDateTimeOfInjury.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                tbDateTimeOfInjury.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                tbDateTimeOfInjury.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }*/
            DateTime temp;
            if (!DateTime.TryParse(tbDateTimeOfInjury.Text, out temp))
            {
                lblError.Text += "Invalid date and time of the injury!<br>";
                tbDateTimeOfInjury.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                tbDateTimeOfInjury.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                tbDateTimeOfInjury.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                tbDateTimeOfInjury.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }
            // check datetime logic
            DateTime temp2;
            if (tbDateTimeOfInjury.Text != null && DateTime.TryParse(tbDateTimeOfInjury.Text, out temp2))
            {
                var timeDue = DateTime.Parse(tbDateTimeOfInjury.Text);
                var currentTime = DateTime.Now;

                if (timeDue > currentTime)
                {
                    lblError.Text += "Please verify the injury date again!<br>";
                    tbDateTimeOfInjury.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                    tbDateTimeOfInjury.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
                }
                else
                {
                    tbDateTimeOfInjury.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                    tbDateTimeOfInjury.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
                }
            }
            if (String.IsNullOrEmpty(tbLocation.Text))
            {
                lblError.Text += "Location is empty!<br>";
                tbLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                tbLocation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                tbLocation.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                tbLocation.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }
            if (String.IsNullOrEmpty(tbDescription.Text))
            {
                lblError.Text += "Description is empty!<br>";
                tbDescription.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                tbDescription.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                tbDescription.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                tbDescription.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }
            if (String.IsNullOrEmpty(tbWitnessName.Text))
            {
                lblError.Text += "Witness name is empty!<br>";
                tbWitnessName.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                tbWitnessName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                tbWitnessName.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                tbWitnessName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }
            if (String.IsNullOrEmpty(tbWitnessPhone.Text))
            {
                lblError.Text += "Witness phone is empty!<br>";
                tbWitnessPhone.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                tbWitnessPhone.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                tbWitnessPhone.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                tbWitnessPhone.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }
            if (String.IsNullOrEmpty(tbNatureOfInjury.Text))
            {
                lblError.Text += "Nature of injury is empty!<br>";
                tbNatureOfInjury.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                tbNatureOfInjury.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                tbNatureOfInjury.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                tbNatureOfInjury.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }
            if (String.IsNullOrEmpty(tbCauseOfInjury.Text))
            {
                lblError.Text += "Cause of injury is empty!<br>";
                tbCauseOfInjury.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                tbCauseOfInjury.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                tbCauseOfInjury.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                tbCauseOfInjury.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }
            if (String.IsNullOrEmpty(tbLocationOfBody.Text))
            {
                lblError.Text += "Location of body is empty!<br>";
                tbLocationOfBody.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                tbLocationOfBody.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                tbLocationOfBody.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                tbLocationOfBody.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }
            if (String.IsNullOrEmpty(tbAgency.Text))
            {
                lblError.Text += "Agency is empty!<br>";
                tbAgency.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                tbAgency.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                tbAgency.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                tbAgency.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }
            if (String.IsNullOrEmpty(rbFirstAidGiven.Text))
            {
                lblError.Text += "First aid given is empty!<br>";
                lblRbValidation.Visible = true;
            }
            else
            {
                lblRbValidation.Visible = false;
            }

            result = String.IsNullOrEmpty(lblError.Text);
            return result;
        }
    }
}