<%@ Page Title="Membership" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Membership.aspx.cs" Inherits="Membership" %>
<%@ Register TagPrefix="uc" TagName="PersonNameControl" Src="~/Membership/PersonNameControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="StudentControl" Src="~/Membership/StudentControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="AddressControl" Src="~/Membership/AddressControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="AdultControl" Src="~/Membership/AdultControl.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2><%: Title %>.</h2>
    <button id="btnSearch" onclick="search(); return false;" >Search</button>

    <div class="row">
        <div class="col-md-5 form-group">
            <div class="form-group">
            <div class="">
                <label runat="server" class="control-label">Membership Type:</label>
            </div>
            <div class="">
                <asp:DropDownList runat="server" EnableViewState="true" CssClass="form-control" ID="MembershipTypeSelect" OnSelectedIndexChanged="MembershipType_Select" AutoPostBack="True">
                    <asp:ListItem Value="Single">Single</asp:ListItem>
                    <asp:ListItem Value="Family">Family</asp:ListItem>
                    <asp:ListItem Value="Corp">Corporate</asp:ListItem>
                </asp:DropDownList>
            </div>
            </div>
        </div>
    </div>

    <uc:AdultControl runat="server" ID="Adult1" />

    <uc:AdultControl runat="server" ID="Adult2" />

    <%-- Address Control --%>
    <div class="row">
        <div class="col-md-5 form-group">
            <uc:AddressControl runat="server" ID="Address" />
        </div>
    </div>

    <asp:PlaceHolder runat="server" ID="ChildPanel"></asp:PlaceHolder>

    <%-- Remove/Add Child Button --%>
    <div class="form-group">
        <div class="form-inline">
            <div class="form-group">
                <div class="btn-group btn-group-xs">
                    <button runat="server" id="RemoveChildButton" onclientclick="RemoveClick" onserverclick="RemoveChild_ServerClick" type="button" class="btn btn-danger">
                        <span class="glyphicon glyphicon-minus"></span>&nbsp;Remove Child
                    </button>
                    <button runat="server" id="AddChildButton" onserverclick="AddChild_ServerClick" type="button" class="btn btn-success">
                        <span class="glyphicon glyphicon-plus"></span>&nbsp;Add Child
                    </button>
                </div>
            </div>
        </div>
    </div>


    <div class="row">
        <div class="form-group" style="padding-left: 15px;">
            <asp:Button ID="Button1" runat="server" OnClick="Submit_Click" Text="Register" CssClass="btn btn-default" />
        </div>
    </div>
    <script type="text/javascript">
        OnMembershipLoaded();
        function search() {
            $.ajax({
                type: 'POST',
                url: '<%= ResolveUrl("~/membership/membership.aspx/GetTeachersByGrade") %>',
                data: '{ }',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (msg) {
                    jsonTeachersByGrade = msg.d;
                }
            });
        }
    </script>
</asp:Content>

