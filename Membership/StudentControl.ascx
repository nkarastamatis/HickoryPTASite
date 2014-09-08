<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentControl.ascx.cs" Inherits="Membership_StudentControl" %>
<%@ Register TagPrefix="uc" TagName="PersonNameControl" Src="~/Membership/PersonNameControl.ascx" %>
<link href="../Content/bootstrap.min.css" rel="stylesheet" />
<link href="../Content/Membership.css" rel="stylesheet" />
<div class="form-group">
    <div class="row">
        <div class="col-lg-5">
            <uc:PersonNameControl runat="server" ID="StudentName" />
        </div>
        <div class="col-lg-7">
            <div class="col-md-3">
                <asp:DropDownList runat="server" CssClass="form-control" ID="GradeSelect" OnSelectedIndexChanged="Grade_Select" AutoPostBack="True" />
            </div>
            <div class="col-md-8">
            <asp:DropDownList runat="server" CssClass="form-control" ID="TeacherSelect" />
            </div>
        </div>
    </div>
</div>
