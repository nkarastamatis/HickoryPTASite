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
        Initialize();
	}

    public Contact(object obj)
    {
        var valuesByProp = obj as Dictionary<string, object>;
        if (valuesByProp == null)
        {
            Initialize();
            return;
        }

        Type type = typeof(Contact);
        foreach (var pair in valuesByProp)
        {
            var property = type.GetProperty(pair.Key);
            if (property != null)
            {
                object value = null;
                if (property.PropertyType == typeof(string))
                    value = pair.Value;
                else
                    value = Activator.CreateInstance(property.PropertyType, pair.Value);
                property.SetValue(this, value);
            }
        }
    }

    private void Initialize()
    {
        Name = new PersonName();
    }
}