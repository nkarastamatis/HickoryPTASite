using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml.Serialization;
using PTAData.Entities;
using PTAData.Repositories;
using Newtonsoft.Json;

public partial class Committee_Create : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region AvailableChairs
    private static IList<Member> _availableChairs;
    private static string AvailableChairsSessionKey = "AvailableChairs";
    private static IList<Member> AvailableChairs
    {
        get
        {
            if (_availableChairs == null)
            {
                //if (Session[AvailableChairsSessionKey] == null)
                //    Session[AvailableChairsSessionKey] = RetrieveAvailableChairs();
                //_availableChairs = Session[AvailableChairsSessionKey] as IList<Member>;
                _availableChairs = RetrieveAvailableChairs();
            }
            return _availableChairs;
        }
    }

    private static IList<Member> RetrieveAvailableChairs()
    {
        //var member = new Member();
        //member.Email = "test2@gmail.com";
        //member.Phone = "5555555555";
        //member.Name.First = "MyFirst2";
        //member.Name.Last = "LastTest2";
        //member.MembershipId = "Test";
        var repo = new MembershipRepository();
        //repo.Save(member);

        var availableChairs = repo.Members;
        
        return availableChairs;
    }
    #endregion

    [System.Web.Services.WebMethod]
    public static string GetAvailableChairs()
    {
        // Null out circuler relationship before convert
        foreach (var chair in AvailableChairs)
            chair.Membership = null;

        var jsonAvailableChairs = JsonConvert.SerializeObject(AvailableChairs);
        return jsonAvailableChairs;
    }

    [System.Web.Services.WebMethod]
    public static void create(object data)
    {        
        var committee = typeof(Committee).Transform(data) as Committee;
        if (committee == null)
            return;

        var repo = new CommitteeRepository();
        repo.Save(committee);     
    }
}