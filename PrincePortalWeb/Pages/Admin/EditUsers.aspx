<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUsers.aspx.cs" Inherits="PrincePortalWeb.Pages.Admin.EditUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     
    <div class="container" style="padding-top: 50px;">
                <div id="dvMessageError" runat="server" visible="false" class="justify-content-center alert alert-danger">
                            <strong>Error!</strong>
                            <asp:Label ID="lblMessage" runat="server" />
                        </div>
        <div id="dvMessageSuccess" runat="server" visible="false" class="justify-content-center alert alert-success">
                            <strong>Success!</strong>
                            <asp:Label ID="Label1" runat="server" />
                        </div>

        <div class="row">
            <div id="griddiv" class="col-md-12">


<asp:GridView ID="GridView1" runat="server" CssClass="col-md-8 table table-bordered table-hover table-responsive" SelectMethod="GridView1_GetData" UpdateMethod="GridView1_UpdateItem" DeleteMethod="GridView1_DeleteItem"
                    DataKeyNames="ID" GridLines="Horizontal" ItemType="PrincePortalWeb.Models.ApplicationUser" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" SelectedRowStyle-BackColor="#ddf7ff" EmptyDataText="No users currently exist for this supplier.">
                    <Columns>
                     <asp:CommandField ButtonType="Image" ItemStyle-HorizontalAlign="Center" CancelImageUrl="~/Content/Images/cancelicon.png" EditImageUrl="~/Content/Images/editicon.png" ControlStyle-CssClass="text-center" ShowEditButton="True" UpdateImageUrl="~/Content/Images/tickicon.png" />

                        <asp:DynamicField DataField="username" HeaderStyle-CssClass="text-center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderText="Username" ReadOnly="true" />
                        <asp:DynamicField DataField="email" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Email" ReadOnly="true" />
                        <asp:DynamicField DataField="phonenumber" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Telephone"  />
                        <asp:DynamicField DataField="webstatus" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Portal Status" ReadOnly="true" />
                        <asp:DynamicField DataField="lastlogdatetime" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Last Logged In" ReadOnly="true" />
                       
                           <asp:TemplateField ControlStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>                              
                                <asp:ImageButton CommandArgument='<%# Eval("ID") %>' CommandName="passwordreset" ToolTip="Reset Password For User" ID="passwordresetbtn" runat="server" ImageUrl="~/Content/Images/passwordicon.png" ImageAlign="Middle" OnClientClick="return confirm('Are you sure you want to reset the password for this user?');" OnCommand="passwordresetbtn_Command"   />
                            </ItemTemplate>
                        </asp:TemplateField>  
                       <asp:TemplateField ControlStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton  ToolTip="Delete User" CommandName="Delete" runat="server" ImageUrl="~/Content/Images/deleteicon.png" ImageAlign="Middle" OnClientClick="return confirm('Are you sure you want to delete this user?');" />
                            </ItemTemplate>
                        </asp:TemplateField>  
                   
                    </Columns>
                </asp:GridView>
      
    </div>
            </div>


              <div class="row" id="buttonholder">


            <div class="form-inline pull-right col-md-4">
                <asp:Button ID="newuserbtn" CssClass="btn-lg btn-info pull-right" OnClick="newuserbtn_Click"     runat="server" Text="New User" />
            </div>
        </div>



        </div>
</asp:Content>
