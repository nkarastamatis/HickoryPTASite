<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <div class="row">
            <h2 class="text-center">Welcome to Hickory Elementary PTA!</h2>
            <p class="lead col-md-7">The overall purpose of PTA is to make every child’s potential a reality by engaging and empowering families and communities to advocate for all children.</p>
            <div class="col-md-5">
            <img src="Content/images/hickoryschool.jpg" class="center-block img-responsive img-rounded" />
            </div>
        </div>
        <div class="list-group">
            
            
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Volunteer</h2>
            <p>As a PTA, we rely SOLELY on volunteers to make our programs and events a success! 
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Events</h2>
            <p>
                Join us for an upcoming event.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Corporate Members</h2>
            <p>
                Many thanks to our Corporate Members for supporting the HES PTA! Please visit their pages and consider giving them your business. 
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
