using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Serialization.Advanced;
using System.Xml.Serialization.Configuration;
using PTAData.Entities;

public partial class About : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var c = new Committee();      
    }
}