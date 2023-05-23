﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCordinator.Master" AutoEventWireup="true" CodeBehind="Courses.aspx.cs" Inherits="FinalFYP.Courses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!--CSS-->
     <link href="BootstrapFiles/css/bootstrap.css" rel="stylesheet" />
    <link href="BootstrapFiles/css/font-awesome.min.css" rel="stylesheet" />
    <link href="BootstrapFiles/css/style.css" rel="stylesheet" />




    <!--Header-->
<header class="bg-info py-2 text-white" id="main-header" >
<div class="container">
    <div class="row">
      <div class="col-md-9">
       <h5><i class="fa fa-home"></i> MANAGE COURSES</h5>
      </div>
    </div>
  </div>
</header>




 <!--Table & Edit Form-->
<section id="posts" style="padding-top:30px">
<div class="container" >
 
    <div class="row " >
    
         <!--Edit Foum-->
     <div class="col-md-4  "  >
        <div class="card Border " >
           <div class="card-header">
         <h3>Add Notice</h3>
          </div>
         
            <section id="padding20">
               
                <div class="form-group">
                    <asp:TextBox ID="tbCourse" runat="server" Visible="False"></asp:TextBox>
                </div>
                 <asp:ScriptManager ID="Scrip1" runat="server"></asp:ScriptManager>
                           <asp:UpdatePanel ID="update1" runat="server"><ContentTemplate>
                           
                <div class="form-group ContainerCenter ">
                    <label for="title" class="form-control-label ">Department</label>
                    <div style="margin-top: 0%">
                        <asp:DropDownList ID="combo_Department" AutoPostBack="true" runat="server" AppendDataBoundItems="true"
                            CssClass="mydropdownlist"  Height="40px" Width="99%" OnSelectedIndexChanged="combo_Department_SelectedIndexChanged" >
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group ContainerCenter ">
                    <label for="title" class="form-control-label ">Program</label>
                    <div style="margin-top: 0%">
                        <asp:DropDownList ID="combo_Program" AutoPostBack="True" runat="server" AppendDataBoundItems="true"
                            CssClass="mydropdownlist"  Height="40px" Width="99%">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group ContainerCenter ">
                    <label for="title" class="form-control-label ">Semester</label>
                    <div style="margin-top: 0%">
                        <asp:DropDownList ID="combo_Semester" AutoPostBack="True" runat="server" AppendDataBoundItems="true"
                            CssClass="mydropdownlist"  Height="40px" Width="99%">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

               
                <div class="form-group CustomBoxSetting ">
                                    <label for="title" class="form-control-label">Course</label>
                                    <asp:TextBox ID="TextBox_CourseName" runat="server" class="form-control" placeholder="Course Name" required="required"></asp:TextBox>
                                </div>
                                <!--TextBox-->

                <asp:Label ID="LabelShow" runat="server" Text="Error" Visible="False"></asp:Label>
</ContentTemplate></asp:UpdatePanel>

                <div class="modal-footer CustomBoxSetting  ContainerCenter ">
                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn btn-success" OnClick="btnsubmit_Click"  />
                     <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary" OnClick="btnUpdate_Click"   />
                   
                </div>
                  
         </section>
          </div><!--card-->
      </div><!--col-md-4-->
      
   
            <!--TABLE AREA-->
        <div class=" col-md-8" runat="server">
          <%--<div class="card-header " style="background-color:#dcdcdc; width:108.50%"  >
            <h3>Notice Table</h3>
          </div>--%>
            
        <div class="col-md-15" runat="server">
             <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
        <asp:GridView ID="GridView_Course" runat="server" 
                      AllowPaging="True" PageSize="4"
                         DataKeyNames="ID"
                      CssClass="table table-striped table-bordered table-hover table-responsive" 
                      AutoGenerateDeleteButton="True" 
                      AutoGenerateSelectButton="True"  OnPageIndexChanging="GridView_Course_PageIndexChanging1" OnRowDeleting="GridView_Course_RowDeleting" OnSelectedIndexChanged="GridView_Course_SelectedIndexChanged" >
        </asp:GridView>
                 </ContentTemplate></asp:UpdatePanel>
            
         </div><!--col-md-15-->
         </div><!--TABLE AREA-->


     </div><!--row-->
   </div>  <!--container-->

    </section>

</asp:Content>

