using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PTAData.Entities;

public partial class Roles_UsersAndRoles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Bind the users and roles
            BindUsersToUserList();
            BindRolesToList();

            // Check the selected user's roles
            CheckRolesForSelectedUser();

            // Display those users belonging to the currently selected role
            DisplayUsersBelongingToRole();
        }
    }

    private void BindRolesToList()
    {
        // Get all of the roles
        var db = new PTAData.Entities.ApplicationUserContext();
        var roles = db.Roles.ToList().Select(r => r.Name);
        UsersRoleList.DataSource = roles;
        UsersRoleList.DataBind();

        RoleList.DataSource = roles;
        RoleList.DataMember = "Name";
        RoleList.DataBind();
    }

    #region 'By User' Interface-Specific Methods
    private void BindUsersToUserList()
    {
        // Get all of the user accounts
        var db = new ApplicationUserContext();
        var users = db.Users.ToList();
        UserList.DataSource = users;
        UserList.DataMember = "UserName";
        UserList.DataBind();
    }

    protected void UserList_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckRolesForSelectedUser(); 
    }

    private void CheckRolesForSelectedUser()
    {
        // Determine what roles the selected user belongs to
        string selectedUserName = UserList.SelectedValue;
        var list = UserList.DataSource as IList;
        var user = list[UserList.SelectedIndex] as IdentityUser;
        var um = new UserManager();
        var selectedUsersRoles = user.Roles.ToList();

        // Loop through the Repeater's Items and check or uncheck the checkbox as needed
        foreach (RepeaterItem ri in UsersRoleList.Items)
        {
            // Programmatically reference the CheckBox
            CheckBox RoleCheckBox = ri.FindControl("RoleCheckBox") as CheckBox;
            var rm = new RoleManager();
            var checkedRole = rm.FindByName(RoleCheckBox.Text);
            // See if RoleCheckBox.Text is in selectedUsersRoles
            if (selectedUsersRoles.Where(r => r.RoleId == checkedRole.Id).Any())
                RoleCheckBox.Checked = true;
            else
                RoleCheckBox.Checked = false;
        }
    }

    protected void RoleCheckBox_CheckChanged(object sender, EventArgs e)
    {
        // Reference the CheckBox that raised this event
        CheckBox RoleCheckBox = sender as CheckBox;

        // Get the currently selected user and role
        string selectedUserName = UserList.SelectedValue;
        var um = new UserManager();
        var user = um.FindByName(selectedUserName);
        string roleName = RoleCheckBox.Text;

        // Determine if we need to add or remove the user from this role
        if (RoleCheckBox.Checked)
        {
            // Add the user to the role            
            um.AddToRoleAsync(user.Id, roleName);

            // Display a status message
            ActionStatus.Text = string.Format("User {0} was added to role {1}.", selectedUserName, roleName);
        }
        else
        {
            // Remove the user from the role
            um.RemoveFromRoleAsync(user.Id, roleName);

            // Display a status message
            ActionStatus.Text = string.Format("User {0} was removed from role {1}.", selectedUserName, roleName);
        }

        // Refresh the "by role" interface
        DisplayUsersBelongingToRole();
    }
    #endregion

    #region 'By Role' Interface-Specific Methods
    protected void RoleList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DisplayUsersBelongingToRole();
    }

    private void DisplayUsersBelongingToRole()
    {
        // Get the selected role
        string selectedRoleName = RoleList.SelectedValue;

        // Get the list of usernames that belong to the role
        var db = new ApplicationUserContext();
        var rm = new RoleManager();
        var selectedRole = rm.FindByName(selectedRoleName);
        var usersBelongingToRole = db.Users
                  .Where(u => u.Roles.Any(r => r.RoleId == selectedRole.Id))
                  .ToList();

        // Bind the list of users to the GridView
        RolesUserList.DataSource = usersBelongingToRole;
        RolesUserList.DataMember = "UserName";
        RolesUserList.DataBind();
    }

    protected void RolesUserList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the selected role
        string selectedRoleName = RoleList.SelectedValue;

        // Reference the UserNameLabel
        Label UserNameLabel = RolesUserList.Rows[e.RowIndex].FindControl("UserNameLabel") as Label;

        // Remove the user from the role
        var um = new UserManager();
        var user = um.FindByName(UserNameLabel.Text);
        um.RemoveFromRole(user.Id, selectedRoleName);

        // Refresh the GridView
        DisplayUsersBelongingToRole();

        // Display a status message
        ActionStatus.Text = string.Format("User {0} was removed from role {1}.", UserNameLabel.Text, selectedRoleName);

        // Refresh the "by user" interface
        CheckRolesForSelectedUser();
    }

    protected void AddUserToRoleButton_Click(object sender, EventArgs e)
    {
        // Get the selected role and username
        string selectedRoleName = RoleList.SelectedValue;
        string userNameToAddToRole = UserNameToAddToRole.Text;

        // Make sure that a value was entered
        if (userNameToAddToRole.Trim().Length == 0)
        {
            ActionStatus.Text = "You must enter a username in the textbox.";
            return;
        }

        // Make sure that the user exists in the system
        var um = new UserManager();
        var user = um.FindByName(userNameToAddToRole);
        if (user == null)
        {
            ActionStatus.Text = string.Format("The user {0} does not exist in the system.", userNameToAddToRole);
            return;
        }

        // Make sure that the user doesn't already belong to this role
        var rm = new RoleManager();
        var selectedRole = rm.FindByName(selectedRoleName);
        if (user.Roles.Where(r => r.RoleId == selectedRole.Id).Any())
        {
            ActionStatus.Text = string.Format("User {0} already is a member of role {1}.", userNameToAddToRole, selectedRoleName);
            return;
        }

        // If we reach here, we need to add the user to the role
        um.AddToRole(user.Id, selectedRoleName);

        // Clear out the TextBox
        UserNameToAddToRole.Text = string.Empty;

        // Refresh the GridView
        DisplayUsersBelongingToRole();

        // Display a status message
        ActionStatus.Text = string.Format("User {0} was added to role {1}.", userNameToAddToRole, selectedRoleName);

        // Refresh the "by user" interface
        CheckRolesForSelectedUser();
    }
    #endregion
}