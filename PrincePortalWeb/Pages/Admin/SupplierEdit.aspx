<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupplierEdit.aspx.cs" Inherits="PrincePortalWeb.Pages.Admin.SupplierEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
    <div class="page-header text-center">
        <h2>Prince Portal Dashboard</h2>
    </div>

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <div class="container" style="padding-top: 50px;">

        <div class="row">
            <div id="griddiv" class="col-md-12">


                <asp:GridView ID="GridView1" runat="server" CssClass="col-md-8 table table-bordered table-hover table-responsive" SelectMethod="GridView1_GetData" DeleteMethod="GridView1_DeleteItem" UpdateMethod="GridView1_UpdateItem"
                    DataKeyNames="supplierid" GridLines="Horizontal" ItemType="PrincePortalWeb.Models.supplier" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" SelectedRowStyle-BackColor="#ddf7ff">
                    <Columns>
                     <asp:CommandField ButtonType="Image" ItemStyle-HorizontalAlign="Center" CancelImageUrl="~/Content/Images/cancelicon.png" EditImageUrl="~/Content/Images/editicon.png" ControlStyle-CssClass="text-center" ShowEditButton="True" UpdateImageUrl="~/Content/Images/tickicon.png" />

                        <asp:DynamicField DataField="suppliername" HeaderStyle-CssClass="text-center" ItemStyle-Font-Bold="true" ItemStyle-CssClass="text-center" ItemStyle-VerticalAlign="Middle" HeaderText="Supplier Name" />
                        <asp:DynamicField DataField="status" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Status" />
                        <asp:DynamicField DataField="whencompliant" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="When Compliant" DataFormatString="{0:MM/dd/yyyy}" ApplyFormatInEditMode="true" />
                        <asp:DynamicField DataField="reviewdate" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Review Date" DataFormatString="{0:MM/dd/yyyy}" ApplyFormatInEditMode="true" />
                        <asp:DynamicField DataField="lastreviewedby" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderText="Reviewed By" />
                        <asp:DynamicField DataField="webstatus" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" ReadOnly="true" HeaderText="Portal Status" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" ShowHeader="True" />

                        <asp:TemplateField ControlStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Content/Images/producticon.png" CommandName="ViewProducts" ImageAlign="Middle" ToolTip="View Supplier Products" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton  ImageUrl="~/Content/Images/detailicon.png" ImageAlign="Middle" CommandName="ViewDetails" ToolTip="View Supplier Details" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ControlStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton  ToolTip="Delete Supplier" CommandName="Delete" runat="server" ImageUrl="~/Content/Images/deleteicon.png" ImageAlign="Middle" OnClientClick="return confirm('Are you sure you want to delete this supplier?');" />
                            </ItemTemplate>
                        </asp:TemplateField>         
                        
                          <asp:HyperLinkField  DataNavigateUrlFormatString="~/pages/admin/editUsers?supplierid={0}" Text="<img src='../../Content/Images/usericon.png' />" DataNavigateUrlFields="supplierId" />
                                                     

             
                    </Columns>
                </asp:GridView>

            </div>


        </div>

        <div class="row" id="buttonholder">


            <div class="form-inline pull-right col-md-4">
                <asp:Button ID="newsupplierbtn" CssClass="btn-lg btn-info pull-right" OnClick="newsupplierbtn_Click" runat="server" Text="New Supplier" />
            </div>
        </div>


    </div>



</asp:Content>
