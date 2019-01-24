using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class CreateBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["accountType"] != null)
                {
                    if (Session["accountType"].ToString() == "student")
                    {
                        ddlTripName.DataSource = WithdrawalRequestDAO.displayAllocatedTrips(Session["adminNo"].ToString());
                        ddlTripName.Items.Insert(0, new ListItem("--Select Trip--", "0"));
                        ddlTripName.AppendDataBoundItems = true;
                        ddlTripName.DataTextField = "tripNameAndTripType";
                        ddlTripName.DataValueField = "tripID";
                        ddlTripName.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("/login.aspx");
                }
            }
            
        }

        protected void btnPublish_Click(object sender, EventArgs e)
        {
            if (ValidateBlog())
            {
                panelError.Visible = false;

                BlogDAO.insertBlog(txtBoxTitle.Text, txtBoxContent.Text, Session["name"].ToString(), Session["adminNo"].ToString(), ddlTripName.SelectedItem.ToString());

                panelSuccess.Visible = true;
                lblMsg.Text = "Blog Published".ToString();
                lblMsg.Visible = true;

            }

        }

        private bool ValidateBlog()
        {
            bool result = false;
            lblError.Text = String.Empty;

            panelError.Visible = true;
            panelSuccess.Visible = false;

            if (ddlTripName.SelectedItem.Value == "0")
            {
                lblError.Text += "Please select a trip" + "<br>";
                ddlTripName.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                ddlTripName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                ddlTripName.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                ddlTripName.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }

            if (String.IsNullOrEmpty(txtBoxTitle.Text))
            {
                lblError.Text += "Please write your title" + "<br>";
                txtBoxTitle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                txtBoxTitle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                txtBoxTitle.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                txtBoxTitle.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }

            if (String.IsNullOrEmpty(txtBoxContent.Text))
            {
                lblError.Text += "Please write your content" + "<br>";
                txtBoxContent.BackColor = System.Drawing.ColorTranslator.FromHtml("#F8D7DA");
                txtBoxContent.BorderColor = System.Drawing.ColorTranslator.FromHtml("#E6707B");
            }
            else
            {
                txtBoxContent.BackColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                txtBoxContent.BorderColor = System.Drawing.ColorTranslator.FromHtml("#CED4DA");
            }

            result = String.IsNullOrEmpty(lblError.Text);
            return result;
        }
    }
}