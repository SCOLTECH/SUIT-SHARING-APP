<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCordinator.Master" AutoEventWireup="true" CodeBehind="TimeTable.aspx.cs" Inherits="FinalFYP.Time_Table" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <link href="BootstrapFiles/css/bootstrap.css" rel="stylesheet" />
    <link href="BootstrapFiles/css/font-awesome.min.css" rel="stylesheet" />
    <link href="BootstrapFiles/css/style.css" rel="stylesheet" />



  


<!--Header-->
<header class="bg-info py-2 text-white" id="main-header" >
<div class="container">
    <div class="row">
      <div class="col-md-9">
       <h5><i class="fa fa-home"></i>  MANAGE TIME TABLE</h5>
      </div>
    </div>
  </div>
</header>


 <!--Table & Edit Form-->
<section >
        <div class="container w-100" >
 
    <div class="row" style="padding-top:2%" >
    
         <!--Edit Foum-->
     <div class="col-md-3 "   >
        <div class="card Border " >
           <div class="card-header">
         <h3>Add Time Table</h3>
          </div>
         
            <section id="padding20">
               
                <div class="form-group">
                    <asp:TextBox ID="tbTimeTable" runat="server" Visible="False"></asp:TextBox>
                </div>
                 <asp:ScriptManager ID="Scrip1" runat="server"></asp:ScriptManager>
                           <asp:UpdatePanel ID="update1" runat="server"><ContentTemplate>
                           
                <div class="form-group ContainerCenter ">
                    <label for="title" class="form-control-label ">Department</label>
                    <div style="margin-top: 0%">
                        <asp:DropDownList ID="combo_Department" AutoPostBack="true" runat="server" AppendDataBoundItems="true"
                            CssClass="mydropdownlist" Height="40px" Width="99%" OnSelectedIndexChanged="combo_Department_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group ContainerCenter ">
                    <label for="title" class="form-control-label ">Program</label>
                    <div style="margin-top: 0%">
                        <asp:DropDownList ID="combo_Program" AutoPostBack="True" runat="server" AppendDataBoundItems="true"
                            CssClass="mydropdownlist" Height="40px" Width="99%">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group ContainerCenter ">
                    <label for="title" class="form-control-label ">Semester</label>
                    <div style="margin-top: 0%">
                        <asp:DropDownList ID="combo_Semester" AutoPostBack="True" runat="server" AppendDataBoundItems="true"
                            CssClass="mydropdownlist" Height="40px" Width="99%">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group ContainerCenter ">
                    <label for="title" class="form-control-label ">Section</label>
                    <div style="margin-top: 0%">
                        <asp:DropDownList ID="combo_Section" AutoPostBack="True" runat="server" AppendDataBoundItems="true"
                            CssClass="mydropdownlist" Height="40px" Width="99%">
                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group ContainerCenter " >
                    <label for="title" class="form-control-label">Details</label>
                    <div style="margin-top: 0%">
                        <asp:TextBox ID="comments" class="form-group " Width="99%"  runat="server" TextMode="MultiLine" MaxLength="50" CssClass="mydropdownlist " ></asp:TextBox>
                    </div>
                </div>


                <div class="form-group ContainerCenter">
                    <label for="file">Upload File</label>
                    <asp:FileUpload ID="Upload_File" runat="server" class="form-control-file " />
                    <small class="form-text text-muted">Maximum 2MB</small>
                </div>
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
        <div class=" col-md-8" runat="server" >
            
        <div class="col-md-15" runat="server" >
             <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
        <asp:GridView ID="GridView_TimeTable" runat="server" 
                      AllowPaging="True" PageSize="10"
                      CssClass="table table-striped table-bordered table-hover table-responsive" 
                      OnPageIndexChanging="GridView_TimeTable_PageIndexChanging"
                      AutoGenerateDeleteButton="True" 
                      DataKeyNames="ID"
                      AutoGenerateSelectButton="True" OnRowDeleting="GridView_TimeTable_RowDeleting" OnSelectedIndexChanged="GridView_TimeTable_SelectedIndexChanged"
                     >
        </asp:GridView>
                 </ContentTemplate></asp:UpdatePanel>
         </div><!--col-md-15-->
         </div><!--TABLE AREA-->


     </div><!--row-->
   </div>  <!--container-->
</section>










</asp:Content>
