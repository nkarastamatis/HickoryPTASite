<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
        <p><a href="Membership\Membership" class="btn btn-primary btn-large">Join Now &raquo;</a></p>
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
