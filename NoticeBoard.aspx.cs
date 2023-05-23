using FinalFYP.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalFYP
{
    public partial class Notice_Board : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*      For GRIDVIEW     */
            DisplayGirdView.get_GridViewAndProcedure("usp_SelectfromNoticeBoard", GridView_NoticeBoard);

            if (!IsPostBack)
            {

                
                /*  For Department COMBO  */
                Manage_ComboBoxes ics = new Manage_ComboBoxes();
                combo_Department.DataSource = ics.getAlldept();
                combo_Department.DataValueField = "DepartmentID";
                combo_Department.DataTextField = "DepartmentName";


                combo_Department.DataBind();
            }


        }

        


        protected void update_Click(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                Manage_NoticeBoard nb = new Manage_NoticeBoard();

                nb.NoticeBoardID = Convert.ToInt32(tbNoticeBoard.Text);
                nb.Department_ID = Convert.ToInt32(combo_Department.SelectedItem.Value);
                nb.Details = comments.Text;
                nb.UpdateNoticeBoard();
                DisplayGirdView.get_GridViewAndProcedure("usp_SelectfromNoticeBoard", GridView_NoticeBoard);
                comments.Text = "";
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }


        protected void GridView_NoticeBoard_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Manage_NoticeBoard board = new Manage_NoticeBoard();
            board.NoticeBoardID = Convert.ToInt32(GridView_NoticeBoard.DataKeys[e.RowIndex].Values[0]);

            board.deleteNoticeBoard();
            DisplayGirdView.get_GridViewAndProcedure("usp_SelectfromNoticeBoard", GridView_NoticeBoard);
        }

        protected void GridView_NoticeBoard_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < combo_Department.Items.Count; i++)
            {
                if (combo_Department.Items[i].Text == GridView_NoticeBoard.SelectedRow.Cells[2].Text.ToString())
                {
                    combo_Department.SelectedIndex = i;
                    break;
                }
            }

            comments.Text = GridView_NoticeBoard.SelectedRow.Cells[3].Text;
            tbNoticeBoard.Text = GridView_NoticeBoard.SelectedRow.Cells[1].Text;
        }

        protected void GridView_NoticeBoard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView_NoticeBoard.PageIndex = e.NewPageIndex;
            GridView_NoticeBoard.DataBind();

            /*      For GRIDVIEW     */
            DisplayGirdView.get_GridViewAndProcedure("usp_SelectfromNoticeBoard", GridView_NoticeBoard);


        }
        //FileUpload1
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (!FileUpload1.HasFile)
            {
                Response.Write("<script language=javascript>alert('Please Select Upload File!')</script>");
            }

            else if (FileUpload1.HasFile)
            {

                HttpPostedFile file = FileUpload1.PostedFile;
                if ((file != null) && (file.ContentLength > 0))
                {


                    int iFileSize = file.ContentLength;
                    if (iFileSize > 20971520)  // 20MB
                    {
                        Response.Write("<script language=javascript>alert('File exceeds the file maximum size is 20 MB')</script>");

                    }
                    else
                    {

                        Manage_NoticeBoard nb = new Manage_NoticeBoard();

                        nb.Department_ID = Convert.ToInt32(combo_Department.SelectedItem.Value);
                        nb.Details = comments.Text;


                        string filenamestring = FileUpload1.FileName;
                        FileUpload1.PostedFile.SaveAs(Server.MapPath("~/UploadedFiles/") + filenamestring);
                        string link = "~/UploadedFiles/" + filenamestring.ToString();
                        nb.insertNoticeBoard(link);
                        link = FileUpload1.ToString();

                        LabelShow.Visible = true;
                        //LabelShow.ForeColor = System.Drawing.Color.Red;
                        LabelShow.ForeColor = System.Drawing.Color.Green;
                        LabelShow.Text = "Uploaded";
                        LabelShow.ForeColor = System.Drawing.Color.Green;
                        DisplayGirdView.get_GridViewAndProcedure("usp_SelectfromNoticeBoard", GridView_NoticeBoard);
                        comments.Text = "";
                        Response.Redirect(Request.Url.AbsoluteUri);
                    }


                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {try{
            if (IsPostBack)
            {
                Manage_NoticeBoard nb = new Manage_NoticeBoard();

                nb.NoticeBoardID = Convert.ToInt32(tbNoticeBoard.Text);
                nb.Department_ID = Convert.ToInt32(combo_Department.SelectedItem.Value);
                nb.Details = comments.Text;
                nb.UpdateNoticeBoard();
                DisplayGirdView.get_GridViewAndProcedure("usp_SelectfromNoticeBoard", GridView_NoticeBoard);
                comments.Text = "";
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }
             catch (Exception)
            {  Response.Write("<script language=javascript>alert('Please Select Fields')</script>");  }
        }

    


     

      

       


    }
}