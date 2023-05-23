using FinalFYP.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace FinalFYP
{
    public partial class New_Session : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*  For Show in Department Table  */
                //    DisplayGirdView.get_GridViewAndProcedure("usp_SelectfromDepartment_onlyName", GridViewDept);
                //}

                /*  For Show in Department COMBO  */
                DisplayGirdView.get_GridViewAndProcedure("usp_SelectfromDepartment&Program", GridView_Session);


                /*  For Department COMBO  */
                Manage_ComboBoxes ics = new Manage_ComboBoxes();
                combo_Department.DataTextField = "DepartmentName";
                combo_Department.DataValueField = "DepartmentID";
                combo_Department.DataSource = ics.getAlldept();
                combo_Department.DataBind();
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            //if (Page.IsValid)
            //{
            //    if (Tb_AddDepartment.Text != "")
            //    {
            //        //ADO.NET Code here
            //        Manage_Department_AND_Program cs = new Manage_Department_AND_Program();
            //        cs.department = Tb_AddDepartment.Text;
            //        cs.insertCurrentSession_Department();
            //        Tb_AddDepartment.Text.Clone();
            //        Response.Redirect(Request.Url.AbsoluteUri);
            //    }
            //    else
            //    {//LabelShow
            //        DeptLabel.Text = " Saved Successfully ";
            //        DeptLabel.Visible = true;
            //        DeptLabel.ForeColor = System.Drawing.Color.Green;
            //        Tb_AddDepartment.Text = "";
            //    }
            //}
        }
      
        protected void GridViewDept_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {



            //GridViewDept.PageIndex = e.NewPageIndex;
            //GridViewDept.DataBind();
            ///*  For Show in Department Table  */
            //DisplayGirdView.get_GridViewAndProcedure("usp_SelectfromDepartment_onlyName", GridViewDept);

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            Manage_CurrentSession ics = new Manage_CurrentSession();

         

          
                ics.program = TextBox_program.Text;
                ics.Department_ID = Convert.ToInt32(combo_Department.SelectedValue);
                ics.insertCurrentSession_Program();
                TextBox_program.Text = "";
                DisplayGirdView.get_GridViewAndProcedure("usp_SelectfromDepartment&Program", GridView_Session);
                LabelShow.Text = "Record Saved Successful";
                Response.Redirect(Request.Url.AbsoluteUri);


           

        }

        protected void GridView_Session_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_Session.PageIndex = e.NewPageIndex;
            GridView_Session.DataBind();
           
            /*  For Show in Department COMBO  */
            DisplayGirdView.get_GridViewAndProcedure("usp_SelectfromDepartment&Program", GridView_Session);


       
        }

        protected void GridView_Session_SelectedIndexChanged(object sender, EventArgs e)
        {
            SesionID.Text = GridView_Session.SelectedRow.Cells[1].Text;

            for (int i = 0; i < combo_Department.Items.Count; i++)
            {
                if (combo_Department.Items[i].Text == GridView_Session.SelectedRow.Cells[2].Text.ToString())
                {
                    combo_Department.SelectedIndex = i;
                    break;
                }
            }

            TextBox_program.Text = GridView_Session.SelectedRow.Cells[3].Text;
                   

        }

        protected void GridView_Session_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Manage_CurrentSession cs = new Manage_CurrentSession();


            cs.ProgramID = Convert.ToInt32(GridView_Session.DataKeys[e.RowIndex].Value);
            cs.deleteCurrentSession();
            DisplayGirdView.get_GridViewAndProcedure("usp_SelectfromDepartment&Program", GridView_Session);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {try{
                        Manage_CurrentSession ics = new Manage_CurrentSession();

                 ics.ProgramID = Convert.ToInt32(SesionID.Text);
                ics.program = TextBox_program.Text;
                ics.Department_ID = Convert.ToInt32(combo_Department.SelectedValue);
                ics.updateCurrentSession_Program();
                combo_Department.ClearSelection();
                TextBox_program.Text = "";
                DisplayGirdView.get_GridViewAndProcedure("usp_SelectfromDepartment&Program", GridView_Session);
                LabelShow.Text = "Record Updated Successfully";
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            catch (Exception)
            {  Response.Write("<script language=javascript>alert('Please Select Fields')</script>");  }
               
        }

        
    }
}