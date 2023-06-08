using System.Collections.Generic;

namespace ns274;

internal class Class6715
{
	private readonly List<Class6714> list_0 = new List<Class6714>();

	public Class6714 this[int index]
	{
		get
		{
			return list_0[index];
		}
		set
		{
			list_0[index] = value;
		}
	}

	public int Count => list_0.Count;

	public bool HasNames
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < list_0.Count)
				{
					if (this[num].HasName)
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
	}

	public int CountOfPropertiesWithNames
	{
		get
		{
			int num = 0;
			for (int i = 0; i < list_0.Count; i++)
			{
				if (this[i].HasName)
				{
					num++;
				}
			}
			return num;
		}
	}

	public void Add(Class6714 item)
	{
		list_0.Add(item);
	}

	public Class6714 method_0(int id)
	{
		int num = 0;
		while (true)
		{
			if (num < list_0.Count)
			{
				if (this[num].int_0 == id)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return this[num];
	}

	public Class6714 method_1(string name)
	{
		int num = 0;
		while (true)
		{
			if (num < list_0.Count)
			{
				if (this[num].string_0 == name)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return this[num];
	}
}
