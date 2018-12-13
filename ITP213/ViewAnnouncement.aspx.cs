using ITP213.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ITP213
{
    public partial class ViewAnnouncement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = AnnouncementDAO.getAllAnnouncement();
            GridView1.DataBind();

            
            //=============================================================================================================================
            /*Announcement obj = AnnouncementDAO.getAnnouncementByAdminNo(Convert.ToInt32("17")); 
            lblAnnouncementTitle.Text = obj.announcementTitle;
            lblAnnouncementMessage.Text = obj.announcementMessage;*/
            //=============================================================================================================================
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            MultiView1.ActiveViewIndex = index;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View Announcement")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                string id = GridView1.Rows[index].Cells[1].Text;
                Response.Redirect("ViewIndividualAnnouncement.aspx?AnnouncementID="+id);
            }
        }
    }
}