<%@ Page Title="Membership" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Membership.aspx.cs" Inherits="Membership" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="form-inline">
        <h4>Create a new account.</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="AdultFirstName1" CssClass="col-md-2 control-label">First Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="AdultFirstName1" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="AdultFirstName1"
                    CssClass="text-danger" ErrorMessage="The user name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="AdultLastName1" CssClass="col-md-2 control-label">Last Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="AdultLastName1" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="AdultLastName1"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
    </div>
    <div class="form-inline">
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="AdultFirstName2" CssClass="col-md-2 control-label">First Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="AdultFirstName2" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="AdultFirstName2"
                    CssClass="text-danger" ErrorMessage="The user name field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="AdultLastName2" CssClass="col-md-2 control-label">Last Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="AdultLastName2" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="AdultLastName2"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
        </div>
    </div>
    <div class="form-horizontal">
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="Button1" runat="server" OnClick="Submit_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>

