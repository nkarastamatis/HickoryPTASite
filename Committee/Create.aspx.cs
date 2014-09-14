using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Committee_Create : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [System.Web.Services.WebMethod]
    public static void create(object data)
    {
        var dictionary = data as Dictionary<string, object>;
        var committee = typeof(Committee).Transform(data);
    }
}