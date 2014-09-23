using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for FileUploadTask
/// </summary>
public class FileUploadTask
{
    private FileUpload _fileUpload;
    private Label _label;
    private String _taskprogress;
    private AsyncTaskDelegate _dlgt;

    public FileUploadTask(FileUpload fileUpload, Label label)
    {
        _fileUpload = fileUpload;
        _label = label;
    }

    // Create delegate. 
    protected delegate void AsyncTaskDelegate();

    public String GetAsyncTaskProgress()
    {
        return _taskprogress;
    }
    public void ExecuteAsyncTask()
    {
        // Introduce an artificial delay to simulate a delayed  
        // asynchronous task.
        //Thread.Sleep(TimeSpan.FromSeconds(5.0));
        _fileUpload.SaveAs(System.Web.Hosting.HostingEnvironment.MapPath("~/Committee/Data/" +
                     _fileUpload.FileName));

    }

    // Define the method that will get called to 
    // start the asynchronous task. 
    public IAsyncResult OnBegin(object sender, EventArgs e,
        AsyncCallback cb, object extraData)
    {
        _taskprogress = "AsyncTask started at: " + DateTime.Now + ". ";

        _dlgt = new AsyncTaskDelegate(ExecuteAsyncTask);
        IAsyncResult result = _dlgt.BeginInvoke(cb, extraData);

        return result;
    }

    // Define the method that will get called when 
    // the asynchronous task is ended. 
    public void OnEnd(IAsyncResult ar)
    {
        _taskprogress += "AsyncTask completed at: " + DateTime.Now;
        _dlgt.EndInvoke(ar);

        //_label.Text = "File name: " +
        //     _fileUpload.PostedFile.FileName + "<br>" +
        //     _fileUpload.PostedFile.ContentLength + " kb<br>" +
        //     "Content type: " +
        //     _fileUpload.PostedFile.ContentType;
    }

    // Define the method that will get called if the task 
    // is not completed within the asynchronous timeout interval. 
    public void OnTimeout(IAsyncResult ar)
    {
        _taskprogress += "AsyncTask failed to complete " +
            "because it exceeded the AsyncTimeout parameter.";
    }
}