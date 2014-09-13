using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Committee
/// </summary>
/// 
[Serializable]
public class Committee
{
    public string CommitteeName {get; set;}
    public string Description {get; set;}
    public List<Contact> ChairPersons { get; set; }

	public Committee()
	{
		//
		// TODO: Add constructor logic here
		//
        ChairPersons = new List<Contact>();
	}
}