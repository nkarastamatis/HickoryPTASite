using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_Roles : System.Web.UI.Page
{
    string[] rolesArray;

    public void Page_Load(object sender, EventArgs args)
    {
        if (!IsPostBack)
        {
            // Bind roles to GridView.
            BindRolestoGridView();            
        }
    }

    private void BindRolestoGridView()
    {
        var db = new HickoryPTASite.ApplicationDbContext();
        RolesGrid.DataSource = db.Roles.ToList().Select(r => r.Name);
        RolesGrid.DataBind();
    }

    public void CreateRole_OnClick(object sender, EventArgs args)
    {
        string createRole = RoleTextBox.Text;

        try
        {
            var rm = new HickoryPTASite.RoleManager();
            var task = rm.RoleExistsAsync(createRole);
            task.Wait();
            if (task.Result)
            {
                Msg.Text = "Role '" + Server.HtmlEncode(createRole) + "' already exists. Please specify a different role name.";
                return;
            }

            rm.CreateAsync(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole(createRole));

            Msg.Text = "Role '" + Server.HtmlEncode(createRole) + "' created.";

            BindRolestoGridView();
        }
        catch (Exception e)
        {
            Msg.Text = "Role '" + Server.HtmlEncode(createRole) + "' <u>not</u> created.";
            Response.Write(e.ToString());
        }

    }
}