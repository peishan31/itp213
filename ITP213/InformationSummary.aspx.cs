using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyFunctions.DAL;

namespace ITP213
{
    public partial class InformationSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AcademicResultDAO acadDAO = new AcademicResultDAO();
            List<AcademicResult> tdList = new List<AcademicResult>();
            tdList = acadDAO.getTDbyAdminNo();
            GridView1.DataSource = tdList;
            GridView1.DataBind();

            GeneralRecordDAO genDAO = new GeneralRecordDAO();
            List<GeneralRecord> genList = new List<GeneralRecord>();
            genList = genDAO.getTDbyAdminNo();
            GridView2.DataSource = genList;
            GridView2.DataBind();
        }

        protected void DropDownListSummary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListSummary.SelectedValue == "Acad")
            {
                PanelAcademicSummary.Visible = true;
                PanelDietSummary.Visible = false;
            }
            else if (DropDownListSummary.SelectedValue == "Diet")
            {
                PanelAcademicSummary.Visible = false;
                PanelDietSummary.Visible = true;
            }
            else
            {
                PanelAcademicSummary.Visible = false;
                PanelDietSummary.Visible = false;
            }
        }
    }
}