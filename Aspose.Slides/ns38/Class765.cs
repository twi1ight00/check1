using System;

namespace ns38;

internal class Class765 : IComparable
{
	private string string_0;

	private int int_0;

	private int int_1;

	internal string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	internal int Val
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal int ToMax
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	internal Class765(string name, int val)
	{
		string_0 = name;
		int_0 = val;
	}

	public int CompareTo(object obj)
	{
		Class765 @class = (Class765)obj;
		if (@class.Val == Val)
		{
			return 0;
		}
		if (@class.Val > Val)
		{
			return 1;
		}
		return -1;
	}

	public override bool Equals(object obj)
	{
		Class765 @class = (Class765)obj;
		return Name.Equals(@class.Name);
	}

	public override int GetHashCode()
	{
		return string_0.GetHashCode();
	}
}
