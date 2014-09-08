<%@ Control Language="C#" ClassName="PersonNameControl" AutoEventWireup="true" CodeFile="PersonNameControl.ascx.cs" Inherits="PersonNameControl" %>

<div runat="server" class="" id="PersonNameGroup">
    <asp:Label runat="server" ID="ControlLabel" CssClass="control-label"></asp:Label>
    
        <div class="col-md-5">
            <input runat="server" id="FirstName" type="text" class="form-control" placeholder="First Name" value="<%# Name.First %>" required />
        </div>
        <div class="col-md-6">
            <input runat="server" id="LastName" type="text" class="form-control" placeholder="Last Name" value="<%# Name.Last %>" required />
        </div>

    
</div>
