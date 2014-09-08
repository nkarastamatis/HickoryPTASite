<%@ Page Title="Membership" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Membership.aspx.cs" Inherits="Membership" %>
<%@ Register TagPrefix="uc" TagName="PersonNameControl" Src="~/Membership/PersonNameControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="StudentControl" Src="~/Membership/StudentControl.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <h2><%: Title %>.</h2>

    <div class="form-group">
        <h4>Create a new account.</h4>
        <asp:DropDownList runat="server" CssClass="form-control" ID="MembershipTypeSelect" OnSelectedIndexChanged="MembershipType_Select" AutoPostBack="True">
            <asp:ListItem>Single</asp:ListItem>
            <asp:ListItem>Family</asp:ListItem>
            <asp:ListItem>Corporate</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="row">
        <div class="col-md-5">
            <uc:PersonNameControl runat="server" ID="Adult1" PersonLabel="Adult #1" />
        </div>
    </div>
    <uc:PersonNameControl runat="server" ID="Adult2" PersonLabel="Adult #2" />
    <div class="row">
        <div class="col-md-5">
    <uc:PersonNameControl runat="server" ID="Child1" PersonLabel="Child #1" />
                    </div>
    </div>
    <uc:StudentControl runat="server" />
    <asp:Panel runat="server" ID="ChildPanel" CssClass="form-control-static"></asp:Panel>
    <div class="form-group">
        <div class="form-inline">
            <div class="form-group">
                <div class="btn-group btn-group-xs">
                    <button runat="server" id="RemoveChildButton" onclientclick="RemoveClick" onserverclick="RemoveChild_ServerClick" type="button" class="btn btn-danger">
                        <span class="glyphicon glyphicon-minus-sign"></span>&nbsp;Remove Child
                    </button>
                    <button runat="server" id="AddChildButton" onserverclick="AddChild_ServerClick" type="button" class="btn btn-success">
                        <span class="glyphicon glyphicon-plus-sign"></span>&nbsp;Add Child
                    </button>

                </div>
            </div>
        </div>
    </div>

    <div class="form-group">
        <div class="form-horizontal">
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button ID="Button1" runat="server" OnClick="Submit_Click" Text="Register" CssClass="btn btn-default" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

