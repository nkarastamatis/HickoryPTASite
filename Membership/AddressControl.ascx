﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddressControl.ascx.cs" Inherits="AddressControl" %>

<div runat="server" class="form-group row">
    <div class="form-group col-md-12">
        <input runat="server" id="StreetAddress" type="text" class="form-control" placeholder="Steet Address" required />
    </div>
    <div class="form-group">
        <div class="col-md-6">
            <input runat="server" id="City" type="text" class="form-control" placeholder="City" required />
        </div>
        <div class="col-md-4">
            <input runat="server" id="Zip" type="text" class="form-control" placeholder="Zip" required />
        </div>
    </div>
</div>
