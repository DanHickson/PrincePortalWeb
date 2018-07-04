<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplierEdit.aspx.cs" Inherits="PrincePortalWeb.Pages.Admin.SupplierEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="searchText" CssClass="col-md-2 control-label">Search Supplier Name:</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="searchText" CssClass="form-control" />
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" Text="Search" CssClass="btn btn-default" OnClick="Search_Click" />
            </div>
        </div>
    </div>





    <asp:GridView ID="GridView1" runat="server"
        CssClass="table table-hover table-striped" GridLines="None"
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="supplierid" HeaderText="ID" Visible="false" />
            <asp:BoundField DataField="Suppliername" HeaderText="Supplier Name" />
            <asp:BoundField DataField="Address1" HeaderText="Address 1" />
            <asp:BoundField DataField="County" HeaderText="County" />
            <asp:BoundField DataField="country" HeaderText="Country" />
            <asp:BoundField DataField="postcode" HeaderText="Post Code" />
            <asp:BoundField DataField="Telephone" HeaderText="Telephone" />
             <asp:BoundField DataField="webstatus" HeaderText="Portal Status" />

        </Columns>
        <RowStyle CssClass="cursor-pointer" />
    </asp:GridView>
















    </div>


</asp:Content>
