using FinalFYP.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalFYP
{
    public partial class Lectures : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromLectures", GridView_Lectures);

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


                combo_CourseName.DataTextField = "CourseName";
                combo_CourseName.DataValueField = "CourseID";
                combo_CourseName.DataSource = ics.getAllCourses();
                combo_CourseName.DataBind();
            }


        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            if (!Upload_File.HasFile)
            {
              
                Response.Write("<script language=javascript>alert('Please select the file then Upload')</script>");   
              
            }

            else if (Upload_File.HasFile)
            {

                HttpPostedFile file = Upload_File.PostedFile;
                if ((file != null) && (file.ContentLength > 0))
                {

                    int iFileSize = file.ContentLength;
                    if (iFileSize > 20971520)  // 20MB
                    {
                       
                        // File exceeds the file maximum size
                        Response.Write("<script language=javascript>alert('File exceeds the file maximum size is 20 MB')</script>");

                    }
                    Manage_Lecture lecture = new Manage_Lecture();
                    lecture.Course_ID = Convert.ToInt32(combo_CourseName.SelectedValue);
                    lecture.Department_ID = Convert.ToInt32(combo_Department.SelectedValue);
                    lecture.Semester_ID = Convert.ToInt32(combo_Semester.SelectedValue);
                    lecture.Section_ID = Convert.ToInt32(combo_Section.SelectedValue);
                    lecture.Program_ID = Convert.ToInt32(combo_Program.SelectedValue);
                    lecture.Details = comments.Text;
                    string filenamestring = Upload_File.FileName;
                    Upload_File.PostedFile.SaveAs(Server.MapPath("~/UploadedFiles/") + filenamestring);
                    string link = "~/UploadedFiles/" + filenamestring.ToString();
                    lecture.insert_lecture(link);
                    link = Upload_File.ToString();
                    DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromLectures", GridView_Lectures);
                    comments.Text = "";
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
        }

        

        protected void GridView_TimeTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_Lectures.PageIndex = e.NewPageIndex;
            GridView_Lectures.DataBind();
            /*  For Show in Department Table  */
            DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromLectures", GridView_Lectures);


        }

        protected void combo_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_Program.DataSource = DisplayGirdView.getProgramOfdept(Convert.ToInt32(combo_Department.SelectedValue));
            combo_Program.Items.Clear();
            //  combo_Program.Items.Add("Select Option");
            combo_Program.DataTextField = "ProgramName";
            combo_Program.DataValueField = "ProgramID";
            combo_Program.DataBind();

        }

        protected void combo_Semester_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_CourseName.DataSource = DisplayGirdView.getSection_Of_ProgramANDSemester(Convert.ToInt32(combo_Program.SelectedValue), Convert.ToInt32(combo_Semester.SelectedValue));
            combo_CourseName.Items.Clear();
            // combo_Program.Items.Add("Select Option");
            combo_CourseName.DataTextField = "CourseName";
            combo_CourseName.DataValueField = "CourseID";
            combo_CourseName.DataBind();
        }

        protected void GridView_Lectures_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Manage_Lecture lec = new Manage_Lecture();
            lec.LectureID = Convert.ToInt32(GridView_Lectures.DataKeys[e.RowIndex].Values[0]);

            lec.deleteLecture();
            DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromLectures", GridView_Lectures);
        
        }

        protected void GridView_Lectures_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < combo_Department.Items.Count; i++)
            {
                if (combo_Department.Items[i].Text == GridView_Lectures.SelectedRow.Cells[2].Text.ToString())
                {
                    combo_Department.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < combo_Program.Items.Count; i++)
            {
                if (combo_Program.Items[i].Text == GridView_Lectures.SelectedRow.Cells[3].Text.ToString())
                {
                    combo_Program.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < combo_Semester.Items.Count; i++)
            {
                if (combo_Semester.Items[i].Text == GridView_Lectures.SelectedRow.Cells[4].Text.ToString())
                {
                    combo_Semester.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < combo_Section.Items.Count; i++)
            {
                if (combo_Section.Items[i].Text == GridView_Lectures.SelectedRow.Cells[5].Text.ToString())
                {
                    combo_Section.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < combo_CourseName.Items.Count; i++)
            {
                if (combo_CourseName.Items[i].Text == GridView_Lectures.SelectedRow.Cells[6].Text.ToString())
                {
                    combo_CourseName.SelectedIndex = i;
                    break;
                }
            }
            comments.Text = GridView_Lectures.SelectedRow.Cells[7].Text;

            tbLectureID.Text = GridView_Lectures.SelectedRow.Cells[1].Text;

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {

                    Manage_Lecture lec = new Manage_Lecture();
                    lec.LectureID = Convert.ToInt32(tbLectureID.Text);
                    lec.Course_ID = Convert.ToInt32(combo_CourseName.SelectedValue);
                    lec.Department_ID = Convert.ToInt32(combo_Department.SelectedValue);
                    lec.Semester_ID = Convert.ToInt32(combo_Semester.SelectedValue);
                    lec.Section_ID = Convert.ToInt32(combo_Section.SelectedValue);
                    lec.Program_ID = Convert.ToInt32(combo_Program.SelectedValue);
                    lec.Details = comments.Text;
                    lec.UpdateLecture();
                    DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromLectures", GridView_Lectures);
                    comments.Text = "";
                    LabelShow.Visible = true;
                    //LabelShow.ForeColor = System.Drawing.Color.Red;
                    LabelShow.ForeColor = System.Drawing.Color.Green;

                    LabelShow.Text = "Sucessfully Update!";
                    Response.Redirect(Request.Url.AbsoluteUri);
                }



            }
            catch (Exception)
            {  Response.Write("<script language=javascript>alert('Please Select Fields')</script>");  }
          
        }
    }
}