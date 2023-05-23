using FinalFYP.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalFYP
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DisplayGirdView.get_GridViewAndProcedure("usp_SelectFromUser", GridView_User);
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            Manage_User user = new Manage_User();
            user.UserName = tbName.Text;
            user.UserPassword = tbPassword.Text;
            user.UserType = combo_UserType.SelectedValue;
            user.insertUser();
            DisplayGirdView.get_GridViewAndProcedure("usp_SelectFromUser", GridView_User);
            Response.Redirect(Request.Url.AbsoluteUri);

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {// try
           // {
            Manage_User user = new Manage_User();
            user.UserID = Convert.ToInt32(tbUser.Text);
            user.UserName = tbName.Text;
            user.UserPassword = tbPassword.Text;
            user.UserType = combo_UserType.SelectedValue;
            user.UpdateUser();
            DisplayGirdView.get_GridViewAndProcedure("usp_SelectFromUser", GridView_User);
            Response.Redirect(Request.Url.AbsoluteUri);
            }

//        catch (Exception)
  //      { Response.Write("<script language=javascript>alert('Please Select Fields')</script>"); }
       // }

        protected void GridView_User_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_User.PageIndex = e.NewPageIndex;
            GridView_User.DataBind();
            /*  For Show in Department Table  */
            DisplayGirdView.get_GridViewAndProcedure("usp_SelectFromUser", GridView_User);
        }

        protected void GridView_User_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Manage_User user = new Manage_User();
                user.UserID = Convert.ToInt32(GridView_User.DataKeys[e.RowIndex].Values[0]);

                user.deleteUser();
                DisplayGirdView.get_GridViewAndProcedure("usp_SelectFromUser", GridView_User);
            }
            catch (Exception)
            {

            }
        }

        protected void GridView_User_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbUser.Text = GridView_User.SelectedRow.Cells[1].Text;
            tbName.Text = GridView_User.SelectedRow.Cells[2].Text;
            tbPassword.Text = GridView_User.SelectedRow.Cells[3].Text;
            for (int i = 0; i < combo_UserType.Items.Count; i++)
            {
                if (combo_UserType.Items[i].Text == GridView_User.SelectedRow.Cells[4].Text.ToString())
                {
                    combo_UserType.SelectedIndex = i;
                    break;
                }
            }

        }
    }
}