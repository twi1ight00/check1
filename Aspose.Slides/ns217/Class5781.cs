using System.Collections.Generic;
using ns215;
using ns216;

namespace ns217;

internal abstract class Class5781 : Class5780, Interface248
{
	private bool bool_0;

	private string string_3;

	private Dictionary<string, Class5898> dictionary_0 = new Dictionary<string, Class5898>();

	public bool CreatedFromData
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public Dictionary<string, Class5898> Attributes => dictionary_0;

	public string Id
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	internal Class5898 method_5(string attributeName)
	{
		if (!dictionary_0.ContainsKey(attributeName))
		{
			return null;
		}
		return dictionary_0[attributeName];
	}

	internal virtual bool vmethod_0()
	{
		return true;
	}

	internal virtual bool vmethod_1()
	{
		return true;
	}

	internal virtual Class5781 vmethod_2()
	{
		return null;
	}

	public virtual object Clone()
	{
		Class5781 @class = vmethod_3();
		@class.ClassName = base.ClassName;
		@class.Name = base.Name;
		@class.Id = Id;
		@class.Parent = base.Parent;
		if (!string.IsNullOrEmpty(Id))
		{
			((Class5784)method_2()).IdElementsDictionary[Id] = (Class5782)@class;
		}
		@class.dictionary_0.Clear();
		foreach (KeyValuePair<string, Class5898> item in dictionary_0)
		{
			@class.dictionary_0.Add(item.Key, (Class5898)item.Value.Clone());
		}
		foreach (Class5781 item2 in base.Nodes.List)
		{
			Class5781 class2 = (Class5781)item2.Clone();
			class2.Parent = @class;
			@class.Nodes.method_0(class2);
		}
		return @class;
	}

	public abstract Class5781 vmethod_3();
}
