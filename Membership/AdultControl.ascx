﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdultControl.ascx.cs" Inherits="AdultControl" %>
<%@ Register TagPrefix="uc" TagName="PersonNameControl" Src="~/Membership/PersonNameControl.ascx" %>
<div class="form-group">
    <div class="row">
        <div class="col-md-5 col-xs-12">
            <uc:PersonNameControl runat="server" ID="StudentName" PersonLabel="Adult" />
        </div>
        <div class="input-group col-md-7 col-xs-12">
            <div class="col-md-3 col-xs-3">
                <%--onkeyup="formatPhoneNumber()"--%>
                <input data-bind="value: Phone, valueUpdate: 'afterkeydown'" runat="server"  class="form-control phone" type="tel" id="Phone" placeholder="Enter Phone" />
            </div>
            <div class="col-md-6 col-xs-6">
                <input data-bind="value: Email" runat="server" class="form-control" type="email" id="Email" placeholder="Enter Email" />
            </div>
        </div>
    </div>
</div>
<script>
    
</script>
