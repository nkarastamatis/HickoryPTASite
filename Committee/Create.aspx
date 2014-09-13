<%@ Page Title="Create Committee" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Create.aspx.cs" Inherits="Committee_Create" %>
<%@ Register TagPrefix="uc" TagName="AdultControl" Src="~/Membership/AdultControl.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2><%: Title %>.</h2>
    <div class="row">
        <div class="form-group">
            <input data-bind="value: CommitteeName" type="text" class="form-control" placeholder="Committee Name" />

        </div>
        <div class="form-group">
            <textarea data-bind="value: Description" rows="10" class="form-control" placeholder="Description"></textarea>
        </div>
        <div data-bind="foreach: ChairPersons">
            <div class="form-group">
                <uc:AdultControl runat="server" />
            </div>
        </div>
        <div class="form-group">
        <div class="form-inline">
            <div class="form-group">
                <div class="btn-group btn-group-xs">                    
                    <button data-bind="click: removeChair" runat="server" type="button" class="btn btn-danger">
                        <span class="glyphicon glyphicon-minus"></span>&nbsp;Remove Chair
                    </button>
                    <button data-bind="click: addChair" runat="server" type="button" class="btn btn-success">
                        <span class="glyphicon glyphicon-plus"></span>&nbsp;Add Chair
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="form-group" style="padding-left: 15px;">
            <button data-bind="click: create", class="btn btn-default" value="Create">Create</button>
        </div>
    </div>

    </div>
    <script type="text/javascript">
        OnCreateCommitteeLoaded();
    </script>
</asp:Content>

