using FinalFYP.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalFYP
{
    public partial class ClassNotices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromClassNotice", GridView_ClassNotice);


                Manage_ComboBoxes ics = new Manage_ComboBoxes();

                combo_Department.DataTextField = "DepartmentName";
                combo_Department.DataValueField = "DepartmentID";
                combo_Department.DataSource = ics.getAlldept();
                combo_Department.DataBind();

                combo_Program.DataTextField = "ProgramName";
                combo_Program.DataValueField = "ProgramID";
                combo_Program.DataSource = ics.getAllProgram();
                combo_Program.DataBind();

                combo_Section.DataTextField = "SectionName";
                combo_Section.DataValueField = "SectionID";
                combo_Section.DataSource = ics.getAllSection();
                combo_Section.DataBind();


                combo_Semester.DataTextField = "SemesterName";
                combo_Semester.DataValueField = "SemesterID";
                combo_Semester.DataSource = ics.getAllSemster();
                combo_Semester.DataBind();


            }

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!Upload_File.HasFile)
            {
                Response.Write("<script language=javascript>alert('File exceeds the file maximum size is 2 MB')</script>");
            }

            else if (Upload_File.HasFile)
            {

                HttpPostedFile file = Upload_File.PostedFile;
                if ((file != null) && (file.ContentLength > 0))
                {

                    int iFileSize = file.ContentLength;
                    if (iFileSize > 20971520)  // 20MB
                    {
                      
                        Response.Write("<script language=javascript>alert('File exceeds the file maximum size is 20 MB')</script>");
                       
                    }
                    Manage_ClassNotice notice = new Manage_ClassNotice();
                    notice.Department_ID = Convert.ToInt32(combo_Department.SelectedValue);
                    notice.Semester_ID = Convert.ToInt32(combo_Semester.SelectedValue);
                    notice.Section_ID = Convert.ToInt32(combo_Section.SelectedValue);
                    notice.Program_ID = Convert.ToInt32(combo_Program.SelectedValue);
                    notice.Details = comments.Text;
                    string filenamestring = Upload_File.FileName;
                    Upload_File.PostedFile.SaveAs(Server.MapPath("~/UploadedFiles/") + filenamestring);
                    string link = "Upload/" + filenamestring.ToString();
                    notice.insert_ClassNotice(link);
                    link = Upload_File.ToString();
                    DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromClassNotice", GridView_ClassNotice);
                    comments.Text = "";
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
        }

        protected void GridView_ClassNotice_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Manage_ClassNotice notice = new Manage_ClassNotice();
            notice.ClassNoticeID = Convert.ToInt32(GridView_ClassNotice.DataKeys[e.RowIndex].Values[0]);

            notice.deleteClassNotice();
            DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromClassNotice", GridView_ClassNotice);

        }

        protected void GridView_ClassNotice_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < combo_Department.Items.Count; i++)
            {
                if (combo_Department.Items[i].Text == GridView_ClassNotice.SelectedRow.Cells[2].Text.ToString())
                {
                    combo_Department.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < combo_Program.Items.Count; i++)
            {
                if (combo_Program.Items[i].Text == GridView_ClassNotice.SelectedRow.Cells[3].Text.ToString())
                {
                    combo_Program.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < combo_Semester.Items.Count; i++)
            {
                if (combo_Semester.Items[i].Text == GridView_ClassNotice.SelectedRow.Cells[4].Text.ToString())
                {
                    combo_Semester.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < combo_Section.Items.Count; i++)
            {
                if (combo_Section.Items[i].Text == GridView_ClassNotice.SelectedRow.Cells[5].Text.ToString())
                {
                    combo_Section.SelectedIndex = i;
                    break;
                }
            }

            comments.Text = GridView_ClassNotice.SelectedRow.Cells[6].Text;
            tbClassNotice.Text = GridView_ClassNotice.SelectedRow.Cells[1].Text;

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
          try{
            if (IsPostBack)
            {

                Manage_ClassNotice notice = new Manage_ClassNotice();
                notice.ClassNoticeID = Convert.ToInt32(tbClassNotice.Text);
                notice.Department_ID = Convert.ToInt32(combo_Department.SelectedValue);
                notice.Semester_ID = Convert.ToInt32(combo_Semester.SelectedValue);
                notice.Section_ID = Convert.ToInt32(combo_Section.SelectedValue);
                notice.Program_ID = Convert.ToInt32(combo_Program.SelectedValue);
                notice.Details = comments.Text;
                notice.UpdateClassNotice();
                DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromClassNotice", GridView_ClassNotice);
                comments.Text = "";
                LabelShow.Text = "Sucessfully Update!";
                Response.Redirect(Request.Url.AbsoluteUri);
            }
              }
            catch (Exception)
            {  Response.Write("<script language=javascript>alert('Please Select Fields')</script>");  }
        }

        protected void combo_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_Program.DataSource = DisplayGirdView.getProgramOfdept(Convert.ToInt32(combo_Department.SelectedValue));
            combo_Program.Items.Clear();
            // combo_Program.Items.Add("Select Option");
            combo_Program.DataTextField = "ProgramName";
            combo_Program.DataValueField = "ProgramID";
            combo_Program.DataBind();

        }

        protected void GridView_ClassNotice_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_ClassNotice.PageIndex = e.NewPageIndex;
            GridView_ClassNotice.DataBind();

            /*      For GRIDVIEW     */
            DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromClassNotice", GridView_ClassNotice);
          

        }
    }
}