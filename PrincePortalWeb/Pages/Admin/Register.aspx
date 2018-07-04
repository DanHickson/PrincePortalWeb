<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PrincePortalWeb.Pages.Admin.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
  

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />

        
           <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="SupplierListDropdown" CssClass="col-md-2 control-label">Supplier</asp:Label>
            <div class="col-md-10">                
                <asp:DropDownList ID="SupplierListDropdown" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="SupplierListDropdown"
                    CssClass="text-danger" ErrorMessage="You must select a supplier." />
            </div>
        </div>

          
    
          <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Username</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control"  />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                    CssClass="text-danger" ErrorMessage="The name field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>
        <div id="dvMessageError" runat="server" visible="false" class="justify-content-center alert alert-danger">
                            <strong>Error!</strong>
                            <asp:Label ID="lblMessage" runat="server" />
                        </div>
        <div id="dvMessageSuccess" runat="server" visible="false" class="justify-content-center alert alert-success">
                            <strong>Success!</strong>
                            <asp:Label ID="Label1" runat="server" />
                        </div>
       <%-- <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>--%>
       <%-- <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>--%>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Invite" CssClass="btn btn-default" ToolTip="This will invite the user to the portal by sending an email to the specified address." />
            </div>
        </div>
    </div>
</asp:Content>
