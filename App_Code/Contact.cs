using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Contact
/// </summary>
/// 
[Serializable]
public class Contact
{
    public PersonName Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

	public Contact()
	{
		//
		// TODO: Add constructor logic here
		//
        Name = new PersonName();
	}
}