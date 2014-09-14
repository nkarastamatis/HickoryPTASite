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
        Initialize();
	}

    public Committee(object obj)
    {
        var valuesByProp = obj as Dictionary<string, object>;
        if (valuesByProp == null)
        {
            Initialize();
            return;
        }

        Type type = typeof(Committee);
        foreach (var pair in valuesByProp)
        {
            var property = type.GetProperty(pair.Key);
            if (property != null)
            {
                object value = null;
                if (property.PropertyType == typeof(string))
                    value = pair.Value;
                else if (pair.Value is Array)
                {
                    foreach (var item in (pair.Value as object[]))
                    {
                        value = Activator.CreateInstance(property.PropertyType.GetGenericArguments()[0], item);
                    }
                }
                else
                    value = Activator.CreateInstance(property.PropertyType, pair.Value);
                property.SetValue(this, value);
            }
        }
    }

    private void Initialize()
    {
        ChairPersons = new List<Contact>();
    }
}