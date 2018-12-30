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
            }
            
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //if (Request.QueryString["tripID"].ToString() != null)
            //{
                

                // Update action
            //}
            //else
            //{
                /*
                INSERT INTO overseasTrip (overseasTripStatus, arrivalDate, departureDate, noOfStudents, noOfLecturers, tripType, tripName, country, adminNo, staffID)
                VALUES ('ONGOING', '10/29/2018', '10/30/2018', 20, 4, 'Immersion Trip', '2018 - Japan Immersion Trip' ,'Japan', '171846Z', 'johnny_appleseed')
                 */
            lblMsg.Text = $"Arrival Date: {tbArrivalDate.Text}; Departure Date: {tbDepartureDate.Text}; noOfStudents: {lbSelectedStudents.Items.Count};" +
            $"noOfLecturers: {lbSelectedLecturers.Items.Count}; tripType: {ddlTripType.SelectedItem.ToString()}; tripName: {tbTripName.Text};" +
            $"country: {ddlCountry.SelectedItem.ToString()};" +
            $"Admin No: {lbSelectedStudents.Text};" +
            $"Staff No: {lbSelectedStudents.Text}; ";

            string errorMsg = "Sorry please ensure that you have entered everything correctly:";
            if (lbSelectedStudents.Items.Count < 1)
            {
                errorMsg += "<br>- Please select at least one student!";
            }
            if (lbSelectedLecturers.Items.Count < 1)
            {
                errorMsg += "<br>- Please select at least one lecturer!";
            }
            if (String.IsNullOrEmpty(tbTripName.Text))
            {
                errorMsg += "<br>- Please include trip name!";
            }
            if (ddlTripType.SelectedItem.ToString() == "--Please Select--")
            {
                errorMsg += "<br>- Please select a trip type!";
            }
            if (ddlCountry.SelectedItem.ToString() == "--Please Select--")
            {
                errorMsg += "<br>- Please select a country!";
            }

            /*DateTime temp;
            if (DateTime.TryParse(tbDepartureDate.Text, out temp))
            {
                // Valid
                //panelAlert.Visible = true;
                //errorMsg += "<br>-Valid Departure DateTime format!";
            }
            else
            {
                // Invalid
                //panelAlert.Visible = true;
                errorMsg += "<br>- Invalid Departure DateTime format!"; // **************** not fully working!!!!!
            }
            DateTime temp2;
            if (DateTime.TryParse(tbArrivalDate.Text, out temp2))
            {
                // Valid
                //panelAlert.Visible = true;
                //errorMsg += "<br>-Valid Arrival DateTime format!";
            }
            else
            {
                // Invalid
                //panelAlert.Visible = true;
                errorMsg += "<br>- Invalid Arrival DateTime format!"; // **************** not fully working!!!!!
            }*/
            if (errorMsg == "Sorry please ensure that you have entered everything correctly:")
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
            else
            {
                panelAlert.Visible = true;
                panelSuccess.Visible = false;
                lblError.Text = errorMsg;
            }
            
            //}

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