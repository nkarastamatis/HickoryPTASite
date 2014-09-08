using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Membership : System.Web.UI.Page
{
    private const string MembershipSelectedSessionKey = "membershipselected";
    private IList<StudentControl> _persistedControls;
    private const string PersistedControlsSessionKey = "studentcontrols";
    private IList<StudentControl> PersistedControls
    {
        get
        {
            if (_persistedControls == null)
            {
                if (Session[PersistedControlsSessionKey] == null)
                    Session[PersistedControlsSessionKey] = new List<StudentControl>();
                _persistedControls = Session[PersistedControlsSessionKey] as IList<StudentControl>;
            }
            return _persistedControls;
        }
    }
    protected void Page_Init(Object sender, EventArgs e)
    {
        RemoveChildButton.Visible = false;
        foreach (var control in PersistedControls)
        {
            RemoveChildButton.Visible = true;
            (control as StudentControl).SetEvents();
            ChildPanel.Controls.Add(control);
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
        else
        {
            //if (Session[MembershipSelectedSessionKey] != null)
            //    MembershipTypeSelect.SelectedIndex = (int)Session[MembershipSelectedSessionKey];
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
        Session[MembershipSelectedSessionKey] = MembershipTypeSelect.SelectedIndex;
    }

    protected void AddChild_ServerClick(object sender, EventArgs e)
    {
        var control = this.LoadControl("StudentControl.ascx") as StudentControl;
        control.Initialize();
        control.StudentLabel = "Child";// +(ChildPanel.Controls.Count + 2).ToString();
        ChildPanel.Controls.Add(control);
        PersistedControls.Add(control);

        if (ChildPanel.Controls.Count > 0)
            RemoveChildButton.Visible = true;

        //this.Response.Redirect(this.Request.Url.ToString(), false);
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

        //this.Response.Redirect(this.Request.Url.ToString());
    }
}