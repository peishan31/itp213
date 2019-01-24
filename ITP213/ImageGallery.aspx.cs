using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITP213.DAL;

namespace ITP213
{
    public partial class ImageGallery : System.Web.UI.Page
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageDAO imgDAO = new ImageDAO();
            List<UploadedImage> imgList = new List<UploadedImage>();
            imgList = imgDAO.getImage();
            GridView1.DataSource = imgList;
            GridView1.DataBind();
        }
        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            if (FileUploadImage.FileName == null)
            {
                Label1.Text = "Please insert image";
            }
            else
            {
                /*
                string title = TextBoxTitle.Text;
                int length = FileUploadImage.PostedFile.ContentLength;
                byte[] pic = new byte[length];
                string user = TextBoxUser.Text;
                string location = TextBoxLocation.Text;

                FileUploadImage.PostedFile.InputStream.Read(pic, 0, length);

                ImageDAO imgDAO = new ImageDAO();
                int insCnt = imgDAO.insertImage(title, pic, user, location);
                if (insCnt == 1)
                {
                    Label1.Text = "Uploaded";
                }
                else
                {
                    Label1.Text = "Unable to upload";
                }
                ButtonUpload.Enabled = false;*/
                SqlConnection myConn = new SqlConnection(DBConnect);
                string s = "Images/" + FileUploadImage.FileName;
                string strSql = "insert into [image] ([title],[image],[user],[location]) values(@paraTitle,@paraImage,@paraUser,@paraLocation)";
                SqlCommand cmd = new SqlCommand(strSql, myConn);
                cmd.Parameters.AddWithValue("@paraTitle", TextBoxTitle.Text);
                cmd.Parameters.AddWithValue("@paraImage", s);
                cmd.Parameters.AddWithValue("@paraUser", Session["name"].ToString());
                cmd.Parameters.AddWithValue("@paraLocation", TextBoxLocation.Text);
                myConn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    FileUploadImage.SaveAs(Server.MapPath("~/Images/") + FileUploadImage.FileName);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    myConn.Close();
                    TextBoxTitle.Text = "";
                    TextBoxLocation.Text = "";
                    Response.Redirect("ImageGallery.aspx");
                }
            }
        }
    }
}