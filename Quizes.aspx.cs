using FinalFYP.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalFYP
{
    public partial class Quizes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromQuiz", GridView_Quiz);


                Manage_ComboBoxes ics = new Manage_ComboBoxes();

                combo_Department.DataTextField = "DepartmentName";
                combo_Department.DataValueField = "DepartmentID";
                combo_Department.DataSource = ics.getAlldept();
                combo_Department.DataBind();


                combo_Section.DataTextField = "SectionName";
                combo_Section.DataValueField = "SectionID";
                combo_Section.DataSource = ics.getAllSection();
                combo_Section.DataBind();

                combo_Semester.DataTextField = "SemesterName";
                combo_Semester.DataValueField = "SemesterID";
                combo_Semester.DataSource = ics.getAllSemster();
                combo_Semester.DataBind();


                combo_Program.DataTextField = "ProgramName";
                combo_Program.DataValueField = "ProgramID";
                combo_Program.DataSource = ics.getAllProgram();
                combo_Program.DataBind();




                combo_CourseName.DataTextField = "CourseName";
                combo_CourseName.DataValueField = "CourseID";
                combo_CourseName.DataSource = ics.getAllCourses();
                combo_CourseName.DataBind();

            }
        }

        protected void GridView_Quiz_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


            GridView_Quiz.PageIndex = e.NewPageIndex;
            GridView_Quiz.DataBind();
            /*  For Show in Department Table  */
            DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromQuiz", GridView_Quiz);
       
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            if (!Upload_File.HasFile)
            {

                Response.Write("<script language=javascript>alert('Please Select Upload File!')</script>");
                //  Response.Write("<script language=javascript>alert('File exceeds the file maximum size is 2 MB')</script>");
               
            }

            else if (Upload_File.HasFile)
            {

                HttpPostedFile file = Upload_File.PostedFile;
                if ((file != null) && (file.ContentLength > 0))
                {


                    int iFileSize = file.ContentLength;
                    if (iFileSize > 20971520)  // 20MB
                    {
                       // Response.Write("<script language=javascript>alert('Please Select Upload File!')</script>");
                          Response.Write("<script language=javascript>alert('File exceeds the file maximum size is 20 MB')</script>");
                        // File exceeds the file maximum size
                       
                    }
                    Manage_Quizs quiz = new Manage_Quizs();
                    quiz.Course_ID = Convert.ToInt32(combo_CourseName.SelectedValue);
                    quiz.Department_ID = Convert.ToInt32(combo_Department.SelectedValue);
                    quiz.Semester_ID = Convert.ToInt32(combo_Semester.SelectedValue);
                    quiz.Section_ID = Convert.ToInt32(combo_Section.SelectedValue);
                    quiz.Program_ID = Convert.ToInt32(combo_Program.SelectedValue);
                    quiz.Details = comments.Text;

                    string filenamestring = Upload_File.FileName;
                    Upload_File.PostedFile.SaveAs(Server.MapPath("~/UploadedFiles/") + filenamestring);
                    string link = "~/UploadedFiles/" + filenamestring.ToString();
                    quiz.insert_Quiz(link);
                    link = Upload_File.ToString();
                    DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromQuiz", GridView_Quiz);
                    comments.Text = "";
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
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

        protected void combo_Semester_SelectedIndexChanged(object sender, EventArgs e)
        {

            combo_CourseName.DataSource = DisplayGirdView.getSection_Of_ProgramANDSemester(Convert.ToInt32(combo_Program.SelectedValue), Convert.ToInt32(combo_Semester.SelectedValue));
            combo_CourseName.Items.Clear();
            // combo_Program.Items.Add("Select Option");
            combo_CourseName.DataTextField = "CourseName";
            combo_CourseName.DataValueField = "CourseID";
            combo_CourseName.DataBind();
        }

        protected void GridView_Quiz_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Manage_Quizs quiz = new Manage_Quizs();
            quiz.QuizID = Convert.ToInt32(GridView_Quiz.DataKeys[e.RowIndex].Value);
            quiz.deleteQuiz();
            DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromQuiz", GridView_Quiz);
       
        }

        protected void GridView_Quiz_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < combo_Department.Items.Count; i++)
            {
                if (combo_Department.Items[i].Text == GridView_Quiz.SelectedRow.Cells[2].Text.ToString())
                {
                    combo_Department.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < combo_Program.Items.Count; i++)
            {
                if (combo_Program.Items[i].Text == GridView_Quiz.SelectedRow.Cells[3].Text.ToString())
                {
                    combo_Program.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < combo_Semester.Items.Count; i++)
            {
                if (combo_Semester.Items[i].Text == GridView_Quiz.SelectedRow.Cells[4].Text.ToString())
                {
                    combo_Semester.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < combo_Section.Items.Count; i++)
            {
                if (combo_Section.Items[i].Text == GridView_Quiz.SelectedRow.Cells[5].Text.ToString())
                {
                    combo_Section.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < combo_CourseName.Items.Count; i++)
            {
                if (combo_CourseName.Items[i].Text == GridView_Quiz.SelectedRow.Cells[6].Text.ToString())
                {
                    combo_CourseName.SelectedIndex = i;
                    break;
                }
            }
            comments.Text = GridView_Quiz.SelectedRow.Cells[7].Text;
            tb_QuizID.Text = GridView_Quiz.SelectedRow.Cells[1].Text;

       
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack)
                {

                    Manage_Quizs quiz = new Manage_Quizs();
                    quiz.QuizID = Convert.ToInt32(tb_QuizID.Text);
                    quiz.Course_ID = Convert.ToInt32(combo_CourseName.SelectedValue);
                    quiz.Department_ID = Convert.ToInt32(combo_Department.SelectedValue);
                    quiz.Semester_ID = Convert.ToInt32(combo_Semester.SelectedValue);
                    quiz.Section_ID = Convert.ToInt32(combo_Section.SelectedValue);
                    quiz.Program_ID = Convert.ToInt32(combo_Program.SelectedValue);
                    quiz.Details = comments.Text;
                    quiz.UpdateQuiz();
                    DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromQuiz", GridView_Quiz);
                    comments.Text = "";
                    LabelShow.Visible = true;
                    //LabelShow.ForeColor = System.Drawing.Color.Red;
                    LabelShow.ForeColor = System.Drawing.Color.Green;

                    LabelShow.Text = "Sucessfully Update!";
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
            catch (Exception)
            { Response.Write("<script language=javascript>alert('Please Select Fields')</script>"); }
        }
    }
}