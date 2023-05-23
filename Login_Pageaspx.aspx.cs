using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FinalFYP.BootstrapCSS_Login
{
    public partial class Login_Pageaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBweb"].ConnectionString);
            SqlDataAdapter sda1 = new SqlDataAdapter("Select Count(*) from tblUser Where UserName='" + txtUserName.Text + "'  AND UserPassword='" + txtPassword.Text + "' AND UserType='" + combo_UserType.Text + "'", con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                SqlDataAdapter sda2 = new SqlDataAdapter("SELECT UserType from tblUser WHERE UserName='" + txtUserName.Text + "'  AND UserPassword='" + txtPassword.Text + "'", con);
                DataTable dt1 = new DataTable();
                sda2.Fill(dt1);
                if (dt1.Rows[0][0].ToString() == "Coordinator")
                {
                    Response.Redirect("~/NoticeBoard.aspx");
                }

                if (dt1.Rows[0][0].ToString() == "Teacher")
                {
                    Response.Redirect("~/Lectures.aspx");
                }
               
            }
        }

        }
    }
