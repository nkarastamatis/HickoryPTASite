using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Membership : System.Web.UI.Page
{
    private IList<Control> _persistedControls;
    private const string PersistedControlsSessionKey = "persistedcontrols";
    private IList<Control> PersistedControls
    {
        get
        {
            if (_persistedControls == null)
            {
                if (Session[PersistedControlsSessionKey] == null)
                    Session[PersistedControlsSessionKey] = new List<Control>();
                _persistedControls = Session[PersistedControlsSessionKey] as IList<Control>;
            }
            return _persistedControls;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //var l = new PersonName[] { Adult1.Name, Adult2.Name, Child1.Name, Child2.Name, Child3.Name };
            //Session["names"] = l;
            Adult2.Visible = false;
            //ViewState["ChildPanel"] = ChildPanel;
        }

        RemoveChildButton.Visible = false;
        foreach (var control in PersistedControls)
        {
            RemoveChildButton.Visible = true;
            ChildPanel.Controls.Add(control);
        }
    }

    private void MembershipTypeSelect_ServerChange(object sender, EventArgs e)
    {
        
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        var p = Adult1.Name;
        //var t = Adult2.Name;
        
    }

    protected void MembershipType_Select(object sender, EventArgs e)
    {
        Adult2.Visible = MembershipTypeSelect.Text == "Family";

    }

    protected void AddChild_ServerClick(object sender, EventArgs e)
    {
        var c = this.LoadControl("PersonNameControl.ascx") as PersonNameControl;
        c.PersonLabel = "Child #" + (ChildPanel.Controls.Count + 2).ToString();
        var container = Child1.Parent;
        int i = container.Controls.IndexOf(Child1);
        ChildPanel.Controls.Add(c);
        PersistedControls.Add(c);

        if (ChildPanel.Controls.Count > 0)
            RemoveChildButton.Visible = true;

        this.Response.Redirect(this.Request.Url.ToString());
    }

    protected void RemoveChild_ServerClick(object sender, EventArgs e)
    {
        var last = PersistedControls.LastOrDefault();
        if (last != null)
        {
            ChildPanel.Controls.Remove(last);
            PersistedControls.Remove(last);
        }

        if (ChildPanel.Controls.Count == 0)
            RemoveChildButton.Visible = false;

        this.Response.Redirect(this.Request.Url.ToString());
    }
}