<%@ Page Title="Membership" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Membership.aspx.cs" Inherits="Membership" %>
<%@ Register TagPrefix="uc" TagName="PersonNameControl" Src="~/Membership/PersonNameControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="StudentControl" Src="~/Membership/StudentControl.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2><%: Title %>.</h2>

    <div class="form-group">
        <h4>Create a new account.</h4>
        <asp:DropDownList runat="server" EnableViewState="true" CssClass="form-control" ID="MembershipTypeSelect" OnSelectedIndexChanged="MembershipType_Select" AutoPostBack="True">
            <asp:ListItem Value="Single">Single</asp:ListItem>
            <asp:ListItem Value="Family">Family</asp:ListItem>
            <asp:ListItem Value="Corp">Corporate</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="row">
        <div class="col-md-5 form-group">
            <uc:PersonNameControl runat="server" ID="Adult1" PersonLabel="Adult" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-5 form-group">
            <uc:PersonNameControl runat="server" ID="Adult2" PersonLabel="Adult" />
        </div>
    </div>

    <uc:StudentControl runat="server" ID="Child1" StudentLabel="Child" />

    <asp:PlaceHolder runat="server" ID="ChildPanel"></asp:PlaceHolder>
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

