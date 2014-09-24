<%@ Page Title="Membership" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Membership.aspx.cs" Inherits="MembershipPage" %>
<%@ Register TagPrefix="uc" TagName="PersonNameControl" Src="~/Membership/PersonNameControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="StudentControl" Src="~/Membership/StudentControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="AddressControl" Src="~/Membership/AddressControl.ascx" %>
<%@ Register TagPrefix="uc" TagName="AdultControl" Src="~/Membership/AdultControl.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="jumbotron">
        <h1>Joining PTA Means...</h1>
        <div class="list-group">
            <a href="#" class="list-group-item">
                <p class="list-group-item-heading">You are supporting what we do to support our students & our school!</p>
                <p class="text-primary">Advocacy, funding for field trips, assemblies, school projects, etc.</p>
            </a>
            <a href="#" class="list-group-item">
                <p class="list-group-item-heading">As a member, you a voice, even if you can't be at meetings!</p>
                <p class="text-primary">When we advocate for our kids, it is for ALL kids at PMES,including yours! If you have an opinion, please share it with us to be included in our comments if you cannot attend! We represent ALL our members!</p>
            </a>
            <a href="#" class="list-group-item">
                <p class="list-group-item-heading">You are showing your kids that their school & what happens there is important to you!</p>
                <p class="text-primary">If you value your child's education and make it a priority, so will they!</p>
            </a>
        </div>
       <%-- <p><a href="Membership\Membership" class="btn btn-primary btn-large">Join Now &raquo;</a></p>--%>
    </div>

    <h2><%: Title %>.</h2>

    <div class="row">
        <div class="col-md-5 form-group">
            <div class="form-group">
                <div class="">
                    <label runat="server" class="control-label">Membership Type:</label>
                </div>
                <div class="">
                    <select data-bind="options: membershipTypes, selectedOptions: membershipType" runat="server" class="form-control"></select>
                </div>
            </div>
        </div>
    </div>

    <div data-bind="foreach: adults">
        <uc:AdultControl runat="server" ID="Adult1" />
    </div>

    <%-- Address Control --%>
    <div class="row">
        <div class="col-md-5 form-group">
            <uc:AddressControl runat="server" ID="Address" />
        </div>
    </div>
    
    <div data-bind="foreach: children">
        <uc:StudentControl runat="server" />
    </div>

    <%-- Remove/Add Child Button --%>
    <div class="form-group">
        <div class="form-inline">
            <div class="form-group">
                <div class="btn-group btn-group-xs">                    
                    <button data-bind="click: removeChild, visible: shouldShowRemove" runat="server" type="button" class="btn btn-danger">
                        <span class="glyphicon glyphicon-minus"></span>&nbsp;Remove Child
                    </button>
                    <button data-bind="click: addChild" runat="server" type="button" class="btn btn-success">
                        <span class="glyphicon glyphicon-plus"></span>&nbsp;Add Child
                    </button>
                </div>
            </div>
        </div>
    </div>


    <div class="row">
        <div class="form-group" style="padding-left: 15px;">
            <asp:Button ID="Button1" runat="server" OnClick="Submit_Click" Text="Register" CssClass="btn btn-default" />
            <button data-bind="click: submit", class="btn btn-default" value="Submit">Register</button>
        </div>
    </div>

    <script type="text/javascript">
        OnMembershipLoaded();
    </script>
</asp:Content>

