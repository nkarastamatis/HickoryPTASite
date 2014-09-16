using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml.Serialization;

public partial class Committee_Create : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [System.Web.Services.WebMethod]
    public static void create(object data)
    {        
        var committee = typeof(Committee).Transform(data) as Committee;
        if (committee == null)
            return;

        var committeeFileName = committee.CommitteeName;//.Replace(" ", String.Empty);
        var filePath = "~/Committee/Data/" + Path.ChangeExtension(committeeFileName, "xml");
        XmlSerializer serializer = new XmlSerializer(typeof(Committee));
        try
        {
            using (var stream = File.OpenWrite(System.Web.Hosting.HostingEnvironment.MapPath(filePath)))
            {
                serializer.Serialize(stream, committee);
            }
        }
        catch
        { }

    }
}