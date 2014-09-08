using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;

public partial class Membership_StudentControl : System.Web.UI.UserControl
{
    private IDictionary<Grade, IList<Teacher>> _teachersByGrade;
    private const string TeachersByGradeSessionKey = "TeachersByGrade";
    private IDictionary<Grade, IList<Teacher>> TeachersByGrade
    {
        get
        {
            if (_teachersByGrade == null)
            {
                if (Session[TeachersByGradeSessionKey] == null)                
                    Session[TeachersByGradeSessionKey] = RetrieveTeachersByGrade();
                _teachersByGrade = Session[TeachersByGradeSessionKey] as IDictionary<Grade, IList<Teacher>>;
            }
            return _teachersByGrade;
        }
    }

    private IDictionary<Grade, IList<Teacher>> RetrieveTeachersByGrade()
    {
        var teachersByGrade = new Dictionary<Grade, IList<Teacher>>();
        foreach (var grade in (Grade[])Enum.GetValues(typeof(Grade)))
        {
            teachersByGrade.Add(grade, new List<Teacher>());
        }

        List<Teacher> teachers = null;
        XmlSerializer serializer = new XmlSerializer(typeof(List<Teacher>));
        using (var stream = File.OpenRead(Server.MapPath("~/Data/Teachers.xml")))
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var grades = new List<Grade>((Grade[])Enum.GetValues(typeof(Grade)));

            GradeSelect.Items.AddRange(
                grades
                .Select(g => new ListItem { Text = g.ToString() })
                .ToArray());

            UpdateTeacherDropDown();
        }
    }

    protected void Grade_Select(object sender, EventArgs e)
    {
        UpdateTeacherDropDown();
    }

    private void UpdateTeacherDropDown()
    {
        var selection = (Grade)Enum.Parse(typeof(Grade), GradeSelect.SelectedItem.Text);
        IList<Teacher> teacherList = null;
        if (TeachersByGrade.TryGetValue(selection, out teacherList))
        {
            TeacherSelect.Items.Clear();
            TeacherSelect.Items.AddRange(
                teacherList
                .Select(t => new ListItem { Text = t.Name.ToString() })
                .ToArray());
        }
    }

    protected void Teacher_Select(object sender, EventArgs e)
    {

    }
}