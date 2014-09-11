<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentControl.ascx.cs" Inherits="StudentControl" %>
<%@ Register TagPrefix="uc" TagName="PersonNameControl" Src="~/Membership/PersonNameControl.ascx" %>


    <%--<div class="row">
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
    </div>--%>
    
<div class="form-group">
    <div class="row">
        <div class="col-md-5 col-xs-12">
            <uc:PersonNameControl runat="server" ID="PersonNameControl1" PersonLabel="Child" />
        </div>
        <div class="input-group col-md-7 col-xs-12">
            <div class="col-md-3 col-xs-3">
                <select data-bind="options: grades, selectedOptions: selectedGrade" runat="server" class="form-control" id="DropDownList1" />
            </div>
            <div class="col-md-6 col-xs-6">
                <select data-bind="options: teachers" runat="server" class="form-control" id="DropDownList2" />
            </div>
        </div>
    </div>
</div>

