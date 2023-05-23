using FinalFYP.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalFYP
{
    public partial class Courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromCourse", GridView_Course);


                Manage_ComboBoxes ics = new Manage_ComboBoxes();

                combo_Department.DataTextField = "DepartmentName";
                combo_Department.DataValueField = "DepartmentID";
                combo_Department.DataSource = ics.getAlldept();
                combo_Department.DataBind();

                combo_Program.DataTextField = "ProgramName";
                combo_Program.DataValueField = "ProgramID";
                combo_Program.DataSource = ics.getAllProgram();
                combo_Program.DataBind();


                combo_Semester.DataTextField = "SemesterName";
                combo_Semester.DataValueField = "SemesterID";
                combo_Semester.DataSource = ics.getAllSemster();
                combo_Semester.DataBind();


                //combo_Section.DataTextField = "SectionName";
                //combo_Section.DataValueField = "SectionID";
                //combo_Section.DataSource = ics.getAllSection();
                //combo_Section.DataBind();




            }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            Manage_Course course = new Manage_Course();
            course.Department_ID = Convert.ToInt32(combo_Department.SelectedValue);
            course.Semester_ID = Convert.ToInt32(combo_Semester.SelectedValue);
            course.Program_ID = Convert.ToInt32(combo_Program.SelectedValue);
            course.CourseName = TextBox_CourseName.Text;
            course.insert_Course();


            DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromCourse", GridView_Course);
            Response.Redirect(Request.Url.AbsoluteUri);
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


        protected void GridView_Course_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView_Course.PageIndex = e.NewPageIndex;
            GridView_Course.DataBind();
            /*  For Show in Department Table  */
            DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromCourse", GridView_Course);


        }

        protected void GridView_Course_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                Manage_Course course = new Manage_Course();
                course.CourseID = Convert.ToInt32(GridView_Course.DataKeys[e.RowIndex].Values[0]);

                course.deleteCourse();
                DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromCourse", GridView_Course);
            }catch(Exception){

            }

        }

        protected void GridView_Course_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < combo_Department.Items.Count; i++)
            {
                if (combo_Department.Items[i].Text == GridView_Course.SelectedRow.Cells[2].Text.ToString())
                {
                    combo_Department.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < combo_Program.Items.Count; i++)
            {
                if (combo_Program.Items[i].Text == GridView_Course.SelectedRow.Cells[3].Text.ToString())
                {
                    combo_Program.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < combo_Semester.Items.Count; i++)
            {
                if (combo_Semester.Items[i].Text == GridView_Course.SelectedRow.Cells[4].Text.ToString())
                {
                    combo_Semester.SelectedIndex = i;
                    break;
                }
            }

            TextBox_CourseName.Text = GridView_Course.SelectedRow.Cells[5].Text;
            tbCourse.Text = GridView_Course.SelectedRow.Cells[1].Text;

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Manage_Course course = new Manage_Course();
                course.CourseID = Convert.ToInt32(tbCourse.Text);
                course.Department_ID = Convert.ToInt32(combo_Department.SelectedValue);
                course.Semester_ID = Convert.ToInt32(combo_Semester.SelectedValue);
                course.Program_ID = Convert.ToInt32(combo_Program.SelectedValue);
                course.CourseName = TextBox_CourseName.Text;
                course.UpdateCourse();


                DisplayGirdView.get_GridViewAndProcedure("usp_SelectAllFromCourse", GridView_Course);
                Response.Redirect(Request.Url.AbsoluteUri);
            }

            catch (Exception)
            { Response.Write("<script language=javascript>alert('Please Select Fields')</script>"); }


        }
    }
}