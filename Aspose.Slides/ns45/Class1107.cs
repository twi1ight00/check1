using System.Collections.Generic;

namespace ns45;

internal class Class1107 : Class1105
{
	private List<Class1105> list_0;

	public Class1107()
	{
		list_0 = new List<Class1105>();
		short_0 = 1;
	}

	public Class1107(string name)
		: this()
	{
		base.EntryName = name;
	}

	public bool Add(Class1105 entry)
	{
		list_0.Add(entry);
		return true;
	}

	public bool method_0(List<Class1105> entries)
	{
		for (int i = 0; i < entries.Count; i++)
		{
			Add(entries[i]);
		}
		return true;
	}

	public bool method_1(string name)
	{
		if (name != null)
		{
			int num = 0;
			while (true)
			{
				if (num < list_0.Count)
				{
					Class1105 @class = list_0[num];
					if (@class.EntryName.Equals(name))
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public bool Remove(Class1105 entry)
	{
		list_0.Remove(entry);
		return true;
	}

	public bool Remove(string name)
	{
		list_0.Remove(method_2(name));
		return true;
	}

	public Class1105 method_2(string name)
	{
		if (name != null)
		{
			for (int i = 0; i < list_0.Count; i++)
			{
				Class1105 @class = list_0[i];
				if (@class.EntryName.Equals(name))
				{
					return @class;
				}
			}
		}
		return null;
	}

	public List<Class1105> method_3()
	{
		return list_0;
	}
}
