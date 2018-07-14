<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddSupplier.aspx.cs" Inherits="PrincePortalWeb.Pages.Admin.AddSupplier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <div class="page-header text-center">
        <h2>Add New Supplier</h2>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div id="newsupplierformview" class="col-md-6 col-md-offset-3 text-center">

            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" />
            <asp:FormView runat="server" ID="addSupplierForm"
                ItemType="PrincePortalWeb.Models.supplier"
                InsertMethod="FormView1_InsertItem" DefaultMode="Insert"
                RenderOuterTable="false" OnItemInserted="addSupplierForm_ItemInserted">
                <InsertItemTemplate>
                    <fieldset class="table-bordered">
                        <ol>
                            <div id="leftform" class="col-md-6">

                                <div class="form-group">

                                    <label id="suppname" class="pull-left">Supplier Name</label>
                                    <asp:DynamicControl runat="server" DataField="suppliername" CssClass="" Mode="Insert" />
                                </div>

                                <div class="form-group">
                                    <label id="suppadd1" class="pull-left">Address 1</label>
                                    <asp:DynamicControl runat="server" DataField="address1" CssClass="" Mode="Insert" />
                                </div>

                                <div class="form-group">
                                    <label id="suppadd2" class="pull-left">Address 2</label>
                                    <asp:DynamicControl runat="server" DataField="address2" CssClass="" Mode="Insert" />
                                </div>

                                <div class="form-group">
                                    <label id="countylbl" class="pull-left">County</label>
                                    <asp:DynamicControl runat="server" DataField="county" CssClass="" Mode="Insert" />
                                </div>

                                <div class="form-group">
                                    <label id="countrylbl" class="pull-left">Country</label>
                                    <asp:DynamicControl runat="server" DataField="country" CssClass="" Mode="Insert" />
                                </div>

                            </div>
                                                        
                            <div id="rightform" class="col-md-6">

                                <div class="form-group">
                                    <label id="postcodelbl" class="pull-left control-label">Postcode</label>
                                    <asp:DynamicControl runat="server" DataField="postcode" CssClass="" Mode="Insert" />
                                </div>

                                <div class="form-group">
                                    <label id="tellbl" class="pull-left">Telephone</label>
                                    <asp:DynamicControl runat="server" DataField="telephone" CssClass="" Mode="Insert" />
                                </div>
                                                             
                                <div class="form-group">
                                    <label id="Compliantlbl" class="pull-left">When Compliant</label>
                                    <asp:DynamicControl runat="server" DataField="whencompliant" CssClass="" Mode="Insert" />
                                </div>


                                <div class="form-group">
                                    <label id="reviewlbl" class="pull-left">Review Date</label>
                                    <asp:DynamicControl runat="server" DataField="reviewdate" CssClass="" Mode="Insert" />
                                </div>

                                <div class="form-group">
                                    <label id="reviewbylbl" class="pull-left">Reviewed By</label>
                                    <asp:DynamicControl runat="server" DataField="lastreviewedby" CssClass="" Mode="Insert" />
                                </div>
                                   <div class="form-group">
                                    <label id="statuslbl" class="pull-left">Status</label>
                                    <asp:DynamicControl runat="server" DataField="status" CssClass="" Mode="Insert" />
                                </div>

                            </div>

                       
                        </ol>
                        <asp:Button runat="server" Text="Insert" CommandName="Insert" CssClass="btn btn-success" />
                        <asp:Button runat="server" Text="Cancel" CausesValidation="false" OnClick="Unnamed_Click" CssClass="btn btn-danger" />
                    </fieldset>
                </InsertItemTemplate>
            </asp:FormView>
        </div>
    </div>

</asp:Content>
