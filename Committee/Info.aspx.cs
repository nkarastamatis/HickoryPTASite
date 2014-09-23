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

            if (committee != null)
            {
                CommitteeName.InnerText = committee.CommitteeName;
                CommitteeDescription.InnerText = committee.Description;
                ChairPersons.DataSource = committee.ChairPersons;
                ChairPersons.DataBind();
            }
        }
    }

    protected void OnFileUpload(object sender, EventArgs e)
    {
        if (FileUpload.HasFile)
            try
            {
                var fileUploadTask = new FileUploadTask(FileUpload, Label);

                var asyncTask = new PageAsyncTask(
                    fileUploadTask.OnBegin,
                    fileUploadTask.OnEnd,
                    fileUploadTask.OnTimeout,
                    "Task1",
                    true);

                RegisterAsyncTask(asyncTask);
                ExecuteRegisteredAsyncTasks();

                Label.Text = fileUploadTask.GetAsyncTaskProgress();

                //FileUpload.SaveAs("C:\\Uploads\\" +
                //     FileUpload.FileName);
                //Label.Text = "File name: " +
                //     FileUpload.PostedFile.FileName + "<br>" +
                //     FileUpload.PostedFile.ContentLength + " kb<br>" +
                //     "Content type: " +
                //     FileUpload.PostedFile.ContentType;
            }
            catch (Exception ex)
            {
                Label.Text = "ERROR: " + ex.Message.ToString();
            }
        else
        {
            Label.Text = "You have not specified a file.";
        }
    }
}