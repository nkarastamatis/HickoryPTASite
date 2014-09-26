using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PTAData.Entities;

public partial class PersonNameControl : System.Web.UI.UserControl
{
    private string personLabel;

    public string PersonLabel 
    {
        get { return personLabel; }
        set
        {
            personLabel = value;
            ControlLabel.Text = PersonLabel;
        }
    }

    public PersonName Name
    {
        get
        {
            var name = new PersonName();
            name.First = FirstName.Value;
            name.Last = LastName.Value;
            return name;
        }
    }

    public PersonNameControl() { }

    protected void Page_Init(Object sender, EventArgs e)
    {       
         
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ControlLabel.Text = PersonLabel;
            PersonNameGroup.DataBind();
        }
    }
}