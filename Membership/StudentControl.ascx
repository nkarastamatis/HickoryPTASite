<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentControl.ascx.cs" Inherits="StudentControl" %>
<%@ Register TagPrefix="uc" TagName="PersonNameControl" Src="~/Membership/PersonNameControl.ascx" %>

<link href="../Content/Membership.css" rel="stylesheet" />
<div class="form-group">
    <div class="row">
        <div class="col-md-5 col-xs-12">
            <uc:PersonNameControl runat="server" ID="StudentName" />
        </div>
        <div class="input-group col-md-7 col-xs-12">
            <div class="col-md-3 col-xs-3">
                <asp:DropDownList runat="server" CssClass="form-control" ID="GradeSelect" OnSelectedIndexChanged="Grade_Select" AutoPostBack="True" />
            </div>
            <div class="col-md-6 col-xs-6">
                <asp:DropDownList runat="server" CssClass="form-control" ID="TeacherSelect" />
            </div>
        </div>
    </div>
</div>
