using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;
using PTAData.Entities;

public partial class MembershipPage : System.Web.UI.Page
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
                if (Session[PersistedControlsSessionKey] as IList<StudentControl> == null)
                    Session[PersistedControlsSessionKey] = new List<StudentControl>();
                _persistedControls = Session[PersistedControlsSessionKey] as IList<StudentControl>;
            }
            return _persistedControls;
        }
    }

    #region Browser Refresh
    private bool refreshState;
    private bool isRefresh;

    protected override void LoadViewState(object savedState)
    {
        object[] AllStates = (object[])savedState;
        base.LoadViewState(AllStates[0]);
        refreshState = bool.Parse(AllStates[1].ToString());
        if (Session["ISREFRESH"] != null && Session["ISREFRESH"] != "")
            isRefresh = (refreshState == (bool)Session["ISREFRESH"]);
    }

    protected override object SaveViewState()
    {
        Session["ISREFRESH"] = refreshState;
        object[] AllStates = new object[3];
        AllStates[0] = base.SaveViewState();
        AllStates[1] = !(refreshState);
        return AllStates;
    }

    #endregion 

    #region TeachersByGrade
    private static IDictionary<Grade, IList<Teacher>> _teachersByGrade;
    private static string TeachersByGradeSessionKey = "TeachersByGrade";
    private static IDictionary<Grade, IList<Teacher>> TeachersByGrade
    {
        get
        {
            if (_teachersByGrade == null)
            {
                //if (Session[TeachersByGradeSessionKey] == null)
                //    Session[TeachersByGradeSessionKey] = RetrieveTeachersByGrade();
                //_teachersByGrade = Session[TeachersByGradeSessionKey] as IDictionary<Grade, IList<Teacher>>;
                _teachersByGrade = RetrieveTeachersByGrade();
            }
            return _teachersByGrade;
        }
    }

    private static IDictionary<Grade, IList<Teacher>> RetrieveTeachersByGrade()
    {
        var teachersByGrade = new Dictionary<Grade, IList<Teacher>>();
        foreach (var grade in (Grade[])Enum.GetValues(typeof(Grade)))
        {
            teachersByGrade.Add(grade, new List<Teacher>());
        }

        List<Teacher> teachers = null;
        XmlSerializer serializer = new XmlSerializer(typeof(List<Teacher>));
        using (var stream = File.OpenRead(
            System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Teachers.xml")))
        {
            teachers = (List<Teacher>)serializer.Deserialize(stream);
        }

        if (teachers != null)
        {
            IList<Teacher> teacherList = null;
            foreach (var teacher in teachers)
            {
                if (teachersByGrade.TryGetValue(teacher.Grade, out teacherList))
                    teacherList.Add(teacher);
            }
        }
        return teachersByGrade;
    }
    #endregion

    protected void Page_Init(Object sender, EventArgs e)
    {
        //foreach (var control in PersistedControls)
        //{
        //    RemoveChildButton.Visible = true;
        //    (control as StudentControl).SetEvents();
        //    ChildPanel.Controls.Add(control);
        //}
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //var l = new PersonName[] { Adult1.Name, Adult2.Name, Child1.Name, Child2.Name, Child3.Name };
            //Session["names"] = l;
            //ViewState["ChildPanel"] = ChildPanel;

            var teacher = new Teacher();
            teacher.Name.First = "Mrs.";
            teacher.Name.Last = "Grubbs";
            teacher.Grade = Grade.First;

            var db = new MembershipContext();
            db.Teachers.Add(teacher);
            db.SaveChanges();
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
        //var p = Adult1.Name;
        //var t = Adult2.Name;
        
    }

    protected void MembershipType_Select(object sender, EventArgs e)
    {
        //Adult2.Visible = MembershipTypeSelect.Text == "Family";
        //Session[MembershipSelectedSessionKey] = MembershipTypeSelect.SelectedIndex;
    }


    [System.Web.Services.WebMethod]
    public static string GetTeachersByGrade()
    {
        var jsonTeachersByGrade = JsonConvert.SerializeObject(TeachersByGrade);
        return jsonTeachersByGrade;      
    }

    [System.Web.Services.WebMethod]
    public static void submit(object data)
    {
        var d = JsonConvert.DeserializeObject(data.ToString());
    }

    [System.Web.Services.WebMethod]
    public static string search()
    {
        return "worked";
    }
}