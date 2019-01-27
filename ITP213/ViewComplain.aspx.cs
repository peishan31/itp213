using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class ViewComplain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void deleteCommand(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "delete_Click")
            {
                string ID = e.CommandArgument.ToString();
                ComplainDAO.updateByComplainID(Convert.ToInt32(ID));
                Response.Redirect("ViewComplain.aspx");
            }
        }
    }
}