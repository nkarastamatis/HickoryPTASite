using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

/// <summary>
/// Summary description for Teacher
/// </summary>
/// 
[Serializable]
public class Teacher
{
    public PersonName Name {get; set;}
    public Grade Grade { get; set; }
	
    public Teacher()
	{
		//
		// TODO: Add constructor logic here
		//
        Name = new PersonName();
        Grade = new Grade();
	}
}