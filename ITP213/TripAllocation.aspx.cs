//using ITP213.DAL;
using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class TripAllocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tripID = Request.QueryString["tripID"];
                if (tripID != null)
                {
                    btnCreate.Text = "Update";
                    DAL.TripAllocation obj = TripAllocationDAO.getTripByTripID(Convert.ToInt32(Request.QueryString["tripID"]));
                    tbTripName.Text = obj.tripName.ToString();
                    ddlTripType.SelectedValue = ddlTripType.Items.FindByText(obj.tripType.ToString()).Value;
                    ddlCountry.SelectedValue = ddlCountry.Items.FindByText(obj.country.ToString()).Value;
                    tbDepartureDate.Text = Convert.ToDateTime(obj.departureDate).ToString("MM/dd/yyyy");
                    tbArrivalDate.Text = Convert.ToDateTime(obj.arrivalDate.ToString()).ToString("MM/dd/yyyy");

                    lbSelectedStudents.DataSource = TripAllocationDAO.getStudentNameByTripID(Convert.ToInt32(Request.QueryString["tripID"]));
                    lbSelectedStudents.DataTextField = "name";
                    lbSelectedStudents.DataValueField = "adminNo";
                    lbSelectedStudents.DataBind();

                    lbSelectedLecturers.DataSource = TripAllocationDAO.getLecturerNameByTripID(Convert.ToInt32(Request.QueryString["tripID"]));
                    lbSelectedLecturers.DataTextField = "name";
                    lbSelectedLecturers.DataValueField = "staffID";
                    lbSelectedLecturers.DataBind();

                }
                else
                {

                }

                ddlCourses.Items.Clear();
                ddlCourses.Items.Add(new ListItem("--Select--", "-1"));
                ddlCourses.Items.Add(new ListItem("Business & Financial Technology", "C35"));
                ddlCourses.Items.Add(new ListItem("Business Informatics", "C78"));
                ddlCourses.Items.Add(new ListItem("Business Intelligence & Analytics", "C43"));
                ddlCourses.Items.Add(new ListItem("Common ICT Programme", "C36"));
                ddlCourses.Items.Add(new ListItem("Cybersecurity & Digital Forensics", "C54"));
                ddlCourses.Items.Add(new ListItem("Financial Informatics", "C58"));
                ddlCourses.Items.Add(new ListItem("Infocomm & Security", "C80"));
                ddlCourses.Items.Add(new ListItem("Information Technology", "C85"));
            }
            
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            lblMsg.Text = $"Arrival Date: {tbArrivalDate.Text}; Departure Date: {tbDepartureDate.Text}; noOfStudents: {lbSelectedStudents.Items.Count};" +
            $"noOfLecturers: {lbSelectedLecturers.Items.Count}; tripType: {ddlTripType.SelectedItem.ToString()}; tripName: {tbTripName.Text};" +
            $"country: {ddlCountry.SelectedItem.ToString()};" +
            $"Admin No: {lbSelectedStudents.Text};" +
            $"Staff No: {lbSelectedStudents.Text}; ";

            if (ValidateTrip())
            {
                panelSuccess.Visible = true;
                panelAlert.Visible = false;
                lblSuccess.Text = "Yup";

                foreach (ListItem studItem in lbSelectedStudents.Items)
                {
                    lblMsg.Text += $"<br>Student's admin No: {studItem.Value.ToString()};";
                }
                foreach (ListItem lecItem in lbSelectedLecturers.Items)
                {
                    lblMsg.Text += $"<br>Lecturer's staff No: {lecItem.Value.ToString()};";
                }

                if (btnCreate.Text == "Update")
                {
                    TripAllocationDAO.updateTripByTripID(Convert.ToInt32(Request.QueryString["tripID"].ToString()), tbDepartureDate.Text, tbArrivalDate.Text, lbSelectedStudents.Items.Count, lbSelectedLecturers.Items.Count, ddlTripType.SelectedItem.ToString(), tbTripName.Text, ddlCountry.SelectedItem.ToString());

                    // DELETE current enrolledStudent & enrolledLecturer datas and re-insert them with new datas
                    TripAllocationDAO.deleteEnrolledStudentsByTripID(Convert.ToInt32(Request.QueryString["tripID"].ToString()));
                    TripAllocationDAO.deleteEnrolledLecturerByTripID(Convert.ToInt32(Request.QueryString["tripID"].ToString()));
                    foreach (ListItem studItem in lbSelectedStudents.Items)
                    {
                        TripAllocationDAO.insertEnrolledStudent(Convert.ToInt32(Request.QueryString["tripID"].ToString()), studItem.Value.ToString());
                    }

                    foreach (ListItem lecItem in lbSelectedLecturers.Items)
                    {
                        TripAllocationDAO.insertEnrolledLecturer(Convert.ToInt32(Request.QueryString["tripID"].ToString()), lecItem.Value.ToString());
                    }
                    Response.Redirect("/ViewAllocatedTrip.aspx?CreateTripStatus=success");
                }
                else // insert new trip
                {
                    // insert trip --> find tripID --> insert enrolledStudent & enrolledLecturer tables.
                    TripAllocationDAO.insertTrip(tbArrivalDate.Text, tbDepartureDate.Text, lbSelectedStudents.Items.Count, lbSelectedLecturers.Items.Count, ddlTripType.SelectedItem.ToString(), tbTripName.Text, ddlCountry.SelectedItem.ToString());

                    DAL.TripAllocation p = TripAllocationDAO.getTripIDByTripNameDepartureDateAndArrivalDate(tbTripName.Text, tbDepartureDate.Text, tbArrivalDate.Text, ddlTripType.SelectedItem.ToString());

                    lblMsg.Text = $"p obj: {p.tripID}";

                    foreach (ListItem studItem in lbSelectedStudents.Items)
                    {
                        TripAllocationDAO.insertEnrolledStudent(p.tripID, studItem.Value.ToString());
                    }

                    foreach (ListItem lecItem in lbSelectedLecturers.Items)
                    {
                        TripAllocationDAO.insertEnrolledLecturer(p.tripID, lecItem.Value.ToString());
                    }
                    Response.Redirect("/ViewAllocatedTrip.aspx?CreateTripStatus=success");
                }
                
            }
        }

        private bool ValidateTrip()
        {
            panelAlert.Visible = true;
            panelSuccess.Visible = false;
            bool result = false;
            lblError.Text = String.Empty;

            if (lbSelectedStudents.Items.Count < 1)
            {
                lblError.Text += "Please select at least one student!" + "<br>";
                lbSelectedStudents.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                lbSelectedStudents.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                lbSelectedStudents.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                lbSelectedStudents.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }

            if (lbSelectedLecturers.Items.Count < 1)
            {
                lblError.Text += "Please select at least one lecturer!" + "<br>";
                lbSelectedLecturers.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                lbSelectedLecturers.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                lbSelectedLecturers.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                lbSelectedLecturers.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }

            if (String.IsNullOrEmpty(tbTripName.Text))
            {
                lblError.Text += "Please include trip name!" + "<br>";
                tbTripName.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                tbTripName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                tbTripName.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                tbTripName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }

            if (ddlTripType.SelectedItem.ToString() == "--Please Select--")
            {
                lblError.Text += "Please select a trip type!" + "<br>";
                ddlTripType.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                ddlTripType.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                ddlTripType.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                ddlTripType.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }

            if (ddlCountry.SelectedItem.ToString() == "--Select--")
            {
                lblError.Text += "Please select a country!" + "<br>";
                ddlCountry.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                ddlCountry.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                ddlCountry.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                ddlCountry.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }

            /*
             DateTime.TryParseExact(dateTime, 
                       "yyyy-dd-MM hh:mm tt", 
                       CultureInfo.InvariantCulture, 
                       DateTimeStyles.None, 
                       out dt);
             */
            DateTime temp;
            if (!DateTime.TryParseExact(tbDepartureDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
            {
                lblError.Text += "Invalid Departure Date!" + "<br>";
                tbDepartureDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                tbDepartureDate.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                tbDepartureDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                tbDepartureDate.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }
            DateTime temp2;
            if (!DateTime.TryParseExact(tbArrivalDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp2))
            {
                lblError.Text += "Invalid Arrival Date!" + "<br>";
                tbArrivalDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                tbArrivalDate.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                tbArrivalDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                tbArrivalDate.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }
            if (tbDepartureDate.Text != null && DateTime.TryParseExact(tbArrivalDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp2) && DateTime.TryParseExact(tbDepartureDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out temp))
            {
                var deptDate = DateTime.ParseExact(tbDepartureDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                var arrDate = DateTime.ParseExact(tbArrivalDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                if (deptDate > arrDate)
                {
                    lblError.Text += "Departure Date must be before arrival date!";
                    tbDepartureDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                    tbDepartureDate.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
                    tbArrivalDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                    tbArrivalDate.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
                }
                else
                {
                    tbDepartureDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                    tbDepartureDate.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
                    tbArrivalDate.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                    tbArrivalDate.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
                }
            }
            
            result = String.IsNullOrEmpty(lblError.Text);

            return result;
        }

        protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ddlSchool.SelectedItem != null)
            {
                //lblMsg.Text = $"you selected {ddlSchool.SelectedValue.ToString()}";
                lblCourses.Visible = true;
                ddlCourses.Visible = true;
                
                
                if (ddlSchool.SelectedValue.ToString() == "SIT")
                {
                    ddlCourses.Items.Clear();
                    ddlCourses.Items.Add(new ListItem("--Select--", "-1"));
                    ddlCourses.Items.Add(new ListItem("Business & Financial Technology", "C35"));
                    ddlCourses.Items.Add(new ListItem("Business Informatics", "C78"));
                    ddlCourses.Items.Add(new ListItem("Business Intelligence & Analytics", "C43"));
                    ddlCourses.Items.Add(new ListItem("Common ICT Programme", "C36"));
                    ddlCourses.Items.Add(new ListItem("Cybersecurity & Digital Forensics", "C54"));
                    ddlCourses.Items.Add(new ListItem("Financial Informatics", "C58"));
                    ddlCourses.Items.Add(new ListItem("Infocomm & Security", "C80"));
                    ddlCourses.Items.Add(new ListItem("Information Technology", "C85"));
                }
                tab_index.Value = "0";
                /*else if (ddlSchool.SelectedValue.ToString() == "SBM")
                {
                    ddlCourses.Items.Clear();
                    ddlCourses.Items.Add(new ListItem("--Select--", "-1"));
                    ddlCourses.Items.Add(new ListItem("Accountancy & Finance", "C98"));
                    ddlCourses.Items.Add(new ListItem("Banking & Finance", "C96"));
                    ddlCourses.Items.Add(new ListItem("Business Management", "C94"));
                    ddlCourses.Items.Add(new ListItem("Common Business Programme", "C34"));
                    ddlCourses.Items.Add(new ListItem("Food & Beverage Business", "C46"));
                    ddlCourses.Items.Add(new ListItem("Hospitality & Tourism Management", "C67"));
                    ddlCourses.Items.Add(new ListItem("Marketing", "C99"));
                    ddlCourses.Items.Add(new ListItem("Mass Media Management", "C93"));
                    ddlCourses.Items.Add(new ListItem("Sport & Wellness Management", "C81"));

                }
                else if (ddlSchool.SelectedValue.ToString() == "SCL")
                {
                    ddlCourses.Items.Clear();
                    ddlCourses.Items.Add(new ListItem("--Select--", "-1"));
                    ddlCourses.Items.Add(new ListItem("Biologics & Process Technology", "C49"));
                    ddlCourses.Items.Add(new ListItem("Chemical & Green Techology", "C55"));
                    ddlCourses.Items.Add(new ListItem("Chemical & Pharmaceutical Technology", "C73"));
                    ddlCourses.Items.Add(new ListItem("Food Science & Nutrition", "C69"));
                    ddlCourses.Items.Add(new ListItem("Medicinal Chemistry", "C45"));
                    ddlCourses.Items.Add(new ListItem("Molecular Biotechnology", "C74"));
                    ddlCourses.Items.Add(new ListItem("Pharmaceutical Science", "C65"));
                }
                else if (ddlSchool.SelectedValue.ToString() == "SID") 
                {
                    ddlCourses.Items.Clear();
                    ddlCourses.Items.Add(new ListItem("--Select--", "-1"));
                    ddlCourses.Items.Add(new ListItem("Architecture", "C38"));
                    ddlCourses.Items.Add(new ListItem("Industrial Design", "C83"));
                    ddlCourses.Items.Add(new ListItem("Spatial Design", "C64"));
                    ddlCourses.Items.Add(new ListItem("Visual Communication", "C63"));
                }
                else if (ddlSchool.SelectedValue.ToString() == "SEG")
                {
                    ddlCourses.Items.Clear();
                    ddlCourses.Items.Add(new ListItem("--Select--", "-1"));
                    ddlCourses.Items.Add(new ListItem("Aerospace/Electrical/Electronics Programme", "C39"));
                    ddlCourses.Items.Add(new ListItem("Aerospace/Mechatronics Programme", "C40"));
                    ddlCourses.Items.Add(new ListItem("Aeronautical & Aerospace Technology", "C51"));
                    ddlCourses.Items.Add(new ListItem("Aerospace System & Management", "C52"));
                    ddlCourses.Items.Add(new ListItem("Biomedical Engineering", "C71"));
                    ddlCourses.Items.Add(new ListItem("Common Engineering Programme", "C42"));
                    ddlCourses.Items.Add(new ListItem("Digital & Precision Engineering", "C62"));
                    ddlCourses.Items.Add(new ListItem("Electrical Engineering with Eco-Design", "C48"));
                    ddlCourses.Items.Add(new ListItem("Electronic Systems", "C89"));
                    ddlCourses.Items.Add(new ListItem("Engineering with Business", "C41"));
                    ddlCourses.Items.Add(new ListItem("Multimedia & Infocomm Technology", "C75"));
                    ddlCourses.Items.Add(new ListItem("Nanotechnology & Materials Science", "C50"));
                    ddlCourses.Items.Add(new ListItem("Robotics & Mechatronics", "C87"));
                }
                else if (ddlSchool.SelectedValue.ToString() == "SHSS")
                {
                    ddlCourses.Items.Clear();
                    ddlCourses.Items.Add(new ListItem("--Select--", "-1"));
                    ddlCourses.Items.Add(new ListItem("Nursing", "C97"));
                    ddlCourses.Items.Add(new ListItem("Oral Healthy Theraphy", "C72"));
                    ddlCourses.Items.Add(new ListItem("Social Sciences(Social Work)", "C47"));
                }
                else if (ddlSchool.SelectedValue.ToString() == "SIDM")
                {
                    ddlCourses.Items.Clear();
                    ddlCourses.Items.Add(new ListItem("--Select--", "-1"));
                    ddlCourses.Items.Add(new ListItem("Animation", "C61"));
                    ddlCourses.Items.Add(new ListItem("Digital Game Art & Design", "C60"));
                    ddlCourses.Items.Add(new ListItem("Digital Visual Effects", "C57"));
                    ddlCourses.Items.Add(new ListItem("Game Development Technology", "C70"));
                    ddlCourses.Items.Add(new ListItem("Interaction Design", "C59"));
                    ddlCourses.Items.Add(new ListItem("Motion Graphics & Broadcast Design", "C66"));
                }
                else if (ddlSchool.SelectedValue.ToString() == "--Please Select--")
                {
                    ddlCourses.Items.Clear();
                    lblCourses.Visible = false;
                    ddlCourses.Visible = false;
                }*/

            }
            
        }

        protected void ddlCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCourses.SelectedItem != null)
            {
                //lblMsg.Text = $"{ddlCourses.SelectedValue}";

                lbStudents.DataSource = TripAllocationDAO.getStudentName(ddlCourses.SelectedValue);
                lbStudents.DataTextField = "name";
                lbStudents.DataValueField = "adminNo";
                lbStudents.DataBind();
                tab_index.Value = "0";
            }
        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lbStudents.Items)
            {
                lbSelectedStudents.Items.Add(new ListItem(item.Text, item.Value.ToString()));
            }
            lbStudents.Items.Clear();
            tab_index.Value = "0";
        }

        protected void lbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbSelectedStudents.Items.Add(new ListItem(lbStudents.SelectedItem.ToString(), lbStudents.SelectedValue.ToString()));
            // lblMsg.Text = $"Selected item: {lbStudents.SelectedItem.ToString()}; Selected value: {lbStudents.SelectedValue.ToString()}";
            while (lbStudents.GetSelectedIndices().Length > 0)
            {
              lbStudents.Items.Remove(lbStudents.SelectedItem);
            }
            tab_index.Value = "0";
        }

        protected void lbSelectedStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbStudents.Items.Add(new ListItem(lbSelectedStudents.SelectedItem.ToString(), lbSelectedStudents.SelectedValue.ToString()));
            // lblMsg.Text = $"Selected item: {lbSelectedStudents.SelectedItem.ToString()}; Selected value: {lbSelectedStudents.SelectedValue.ToString()}";
            while (lbSelectedStudents.GetSelectedIndices().Length > 0)
            {
                lbSelectedStudents.Items.Remove(lbSelectedStudents.SelectedItem);
            }
            tab_index.Value = "0";
        }

        protected void btnMoveAllStudent_Click(object sender, EventArgs e)
        {

        }

        protected void btnRemoveStudent_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lbSelectedStudents.Items)
            {
                lbStudents.Items.Add(new ListItem(item.Text, item.Value.ToString()));
            }
            lbSelectedStudents.Items.Clear();
            tab_index.Value = "0";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlLecturerDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLecturerDepartment.SelectedItem != null)
            {
                // lblMsg.Text = $"{ddlLecturerDepartment.SelectedValue}";

                lbLecturers.DataSource = TripAllocationDAO.getLecturerName(ddlLecturerDepartment.SelectedValue);
                lbLecturers.DataTextField = "name";
                lbLecturers.DataValueField = "staffID";
                lbLecturers.DataBind();
            }
            tab_index.Value = "1";
        }

        protected void btnAddLecturer_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lbLecturers.Items)
            {
                lbSelectedLecturers.Items.Add(new ListItem(item.Text, item.Value.ToString()));
            }
            tab_index.Value = "1";
            lbLecturers.Items.Clear();
            
        }

        protected void btnRemoveLecturer_Click(object sender, EventArgs e)
        {
            foreach (ListItem item in lbSelectedLecturers.Items)
            {
                lbLecturers.Items.Add(new ListItem(item.Text, item.Value.ToString()));
            }
            lbSelectedLecturers.Items.Clear();
            tab_index.Value = "1";
        }

        protected void lbLecturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbSelectedLecturers.Items.Add(new ListItem(lbLecturers.SelectedItem.ToString(), lbLecturers.SelectedValue.ToString()));
            // lblMsg.Text = $"Selected item: {lbLecturers.SelectedItem.ToString()}; Selected value: {lbLecturers.SelectedValue.ToString()}";
            while (lbLecturers.GetSelectedIndices().Length > 0)
            {
                lbLecturers.Items.Remove(lbLecturers.SelectedItem);
            }
        }

        protected void lbSelectedLecturers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbLecturers.Items.Add(new ListItem(lbSelectedLecturers.SelectedItem.ToString(), lbSelectedLecturers.SelectedValue.ToString()));
            // lblMsg.Text = $"Selected item: {lbSelectedLecturers.SelectedItem.ToString()}; Selected value: {lbSelectedLecturers.SelectedValue.ToString()}";
            while (lbSelectedLecturers.GetSelectedIndices().Length > 0)
            {
                lbSelectedLecturers.Items.Remove(lbSelectedLecturers.SelectedItem);
            }
            tab_index.Value = "1";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            tab_index.Value = "0";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            tab_index.Value = "1";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            tab_index.Value = "2";
        }
    }
}