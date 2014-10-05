using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;
using PTAData.Entities;
using PTAData.Repositories;

public partial class Committee_Info : System.Web.UI.Page
{
    #region Browser Refresh
    private bool refreshState;
    private bool isRefresh;
    private string refreshKey = "ISREFRESHCOMMITTEEINFO";

    protected override void LoadViewState(object savedState)
    {
        object[] AllStates = (object[])savedState;
        base.LoadViewState(AllStates[0]);
        refreshState = bool.Parse(AllStates[1].ToString());
        if (Session[refreshKey] != null && Session[refreshKey] != "")
            isRefresh = (refreshState == (bool)Session[refreshKey]);
    }

    protected override object SaveViewState()
    {
        Session[refreshKey] = refreshState;
        object[] AllStates = new object[3];
        AllStates[0] = base.SaveViewState();
        AllStates[1] = !(refreshState);
        return AllStates;
    }

    #endregion 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Committee committee = LoadCommittee();            

            if (committee != null)
            {
                CommitteeName.InnerText = committee.CommitteeName;
                CommitteeDescription.InnerText = committee.Description;

                ChairPersons.DataSource = committee.ChairPersons;
                ChairPersons.DataBind();

                AttachedFiles.DataSource = committee.AttachedFiles;
                AttachedFiles.DataBind();
            }
        }
        else
        {
            Committee committee = LoadCommittee();
            AttachedFiles.DataSource = committee.AttachedFiles;
            AttachedFiles.DataBind();
        }
    }

    private Committee LoadCommittee()
    {
        string[] values = Request.QueryString.GetValues(HickoryPTASite.Constants.CommitteeQueryStringKey);
        if (values == null)
            return null;
        var committeeName = values.FirstOrDefault();
        var repo = new CommitteeRepository();

        var committee = repo.Get<Committee>().FirstOrDefault(c => c.CommitteeName == committeeName);

        return committee;
    }

    protected void OnFileUpload(object sender, EventArgs e)
    {
        if (!isRefresh && FileUpload.HasFile)
        {
            try
            {
                //var fileUploadTask = new FileUploadTask(FileUpload, Label);

                //var asyncTask = new PageAsyncTask(
                //    fileUploadTask.OnBegin,
                //    fileUploadTask.OnEnd,
                //    fileUploadTask.OnTimeout,
                //    "Task1",
                //    true);

                //RegisterAsyncTask(asyncTask);
                //ExecuteRegisteredAsyncTasks();

                //Label.Text = fileUploadTask.GetAsyncTaskProgress();

                FileUpload.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath("~/Committee/Data/" +
                        FileUpload.FileName));

                Committee committee = LoadCommittee();

                if (committee != null)
                {
                    committee.AttachedFiles.Add(new CommitteeFile() { CommitteeName = committee.CommitteeName, FileName = FileUpload.FileName });
                    committee.Save();

                    AttachedFiles.DataSource = committee.AttachedFiles;
                    AttachedFiles.DataBind();
                }
            }
            catch (Exception ex)
            {
                Label.Text = "ERROR: " + ex.Message.ToString();
            }
        }
        else
        {
            Label.Text = "You have not specified a file.";
        }
    }
}