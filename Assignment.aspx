<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Assignment.aspx.cs" Inherits="FinalFYP.Assignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_BodyArea" runat="server">
        <link href="BootstrapFiles/css/bootstrap.css" rel="stylesheet" />
    <link href="BootstrapFiles/css/font-awesome.min.css" rel="stylesheet" />
    <link href="BootstrapFiles/css/style.css" rel="stylesheet" />


    
<!--Header-->
<header class="bg-info py-2 text-white" id="main-header" >
<div class="container">
    <div class="row">
      <div class="col-md-9">
       <h5><i class="fa fa-edit"></i> MANAGE ASSIGNMENT</h5>
      </div>
    </div>
  </div>
</header>


  
<!--Table-->
    <section >
        <div class="container w-100" >
            <div class="row  " style=" margin-top:3%">

                <!--Edit Foum-->
                <div class="col-md-3">
                    <div class="card">
                        <div class="card-header">
                            <h3>Add Assignment</h3>
                        </div>

                        <div id="padding20">
                            <div class="form-group">
                                <asp:TextBox ID="tbAssignment" runat="server" Visible="False"></asp:TextBox>
                            </div>

                             <asp:ScriptManager ID="Scrip1" runat="server"></asp:ScriptManager>
                           <asp:UpdatePanel ID="update1" runat="server"><ContentTemplate>
                           
                            <div class="form-group  ">
                                <label for="title" class="form-control-label ">Department</label>
                                <div>
                                    <asp:DropDownList ID="combo_Department" AutoPostBack="true" runat="server" AppendDataBoundItems="true"
                                        CssClass="mydropdownlist" Height="40px" Width="99%" OnSelectedIndexChanged="combo_Department_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group  ">
                                <label for="title" class="form-control-label ">Program</label>
                                <div>
                                    <asp:DropDownList ID="combo_Program" Height="40px" Width="99%" AutoPostBack="True" runat="server" AppendDataBoundItems="true"
                                        CssClass="mydropdownlist">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group  ">
                                <label for="title" class="form-control-label ">Semester</label>
                                <div>
                                    <asp:DropDownList ID="combo_Semester" AutoPostBack="True" runat="server" AppendDataBoundItems="true"
                                        CssClass="mydropdownlist"  Height="40px" Width="99%" OnSelectedIndexChanged="combo_Semester_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group  ">
                                <label for="title" class="form-control-label ">Section</label>
                                <div>
                                    <asp:DropDownList ID="combo_Section" AutoPostBack="True" runat="server" AppendDataBoundItems="true"
                                        CssClass="mydropdownlist"  Height="40px" Width="99%">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group  ">
                                <label for="title" class="form-control-label ">Course</label>
                                <div>
                                    <asp:DropDownList ID="combo_CourseName" AutoPostBack="True" runat="server" AppendDataBoundItems="true"
                                        CssClass="mydropdownlist"  Height="40px" Width="99%">
                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="form-group  ">
                                <label for="title" class="form-control-label">Details</label>
                                <div>
                                    <asp:TextBox ID="comments" class="form-group " Width="99%"   runat="server" TextMode="MultiLine" MaxLength="50" CssClass="mydropdownlist "></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group CustomBoxSetting">
                                <label for="file">Upload File</label>
                                <asp:FileUpload ID="Upload_File" runat="server" class="form-control-file " />
                                <small class="form-text text-muted">Maximum 2MB</small>
                            </div>
                            <asp:Label ID="LabelShow" runat="server" Text="Error" Visible="False"></asp:Label>
                               </ContentTemplate></asp:UpdatePanel>

                            
                            <div class="modal-footer CustomBoxSetting   ">
                                <asp:Button ID="btnsubmit" runat="server" Text="Submit" class="btn btn-success col-5" OnClick="btnsubmit_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-primary col-5" OnClick="btnUpdate_Click" />
                            </div>
                        </div>
                    </div>
                    <!--card-->
                </div>
                <!--col-md-4-->



             <!--TABLE AREA-->
                <div class=" col-md-9 " >
                         
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                                <asp:GridView ID="GridViewAssignment" runat="server"
                                    AllowPaging="true" PageSize="10"
                                    AutoPostBack="true"
                                        DataKeyNames="ID"
                                    CssClass="table table-striped table-bordered table-hover table-responsive"
                                    AutoGenerateDeleteButton="True"
                                    AutoGenerateSelectButton="True"
                                   OnPageIndexChanging ="GridViewAssignment_PageIndexChanging" OnRowDeleting="GridViewAssignment_RowDeleting" OnSelectedIndexChanged="GridViewAssignment_SelectedIndexChanged" >
                                </asp:GridView>
                           
                   </ContentTemplate></asp:UpdatePanel>
              
            </div>
        </div>
            </div>
    </section><!--section--> 




    
      
      
                             
</asp:Content>
