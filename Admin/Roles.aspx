<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="Admin_Roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <h3>Create a Role</h3>

    <asp:Label ID="Msg" ForeColor="maroon" runat="server" /><br />

    Role name: 

  <asp:TextBox ID="RoleTextBox" runat="server" />

    <asp:Button Text="Create Role" ID="CreateRoleButton"
        runat="server" OnClick="CreateRole_OnClick" />

    <br />

    <asp:GridView runat="server" CellPadding="2" ID="RolesGrid"
        GridLines="Both" CellSpacing="2" AutoGenerateColumns="false">
        <HeaderStyle BackColor="navy" ForeColor="white" />
        <Columns>
            <asp:TemplateField HeaderText="Roles">
                <ItemTemplate>
                    <%# Container.DataItem.ToString() %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>

