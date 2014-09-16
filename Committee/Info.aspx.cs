using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;

public partial class Committee_Info : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var committeeFileName = Request.QueryString.GetValues(Constants.CommitteeQueryStringKey).FirstOrDefault();
            var filePath = "~/Committee/Data/" + Path.ChangeExtension(committeeFileName, "xml");
            Committee committee = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Committee));
            try
            {
                using (var stream = File.OpenRead(Server.MapPath(filePath)))
                {
                    committee = (Committee)serializer.Deserialize(stream);
                }
            }
            catch
            { }
        }
    }
}