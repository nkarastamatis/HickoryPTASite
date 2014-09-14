<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageUsers.aspx.cs" Inherits="Admin_ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h3>Manage Users</h3>

    <asp:GridView runat="server" CellPadding="2" ID="UsersGrid"
        GridLines="Both" CellSpacing="2" AutoGenerateColumns="false">
        <HeaderStyle BackColor="navy" ForeColor="white" />
        <Columns>
            <asp:TemplateField HeaderText="Username">
                <ItemTemplate>
                    <%# ((HickoryPTASite.ApplicationUser)Container.DataItem).UserName %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

