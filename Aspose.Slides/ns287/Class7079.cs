using System;
using System.Collections.Generic;
using ns305;

namespace ns287;

internal class Class7079 : Class7078
{
	private readonly Class7075 class7075_0;

	public override int Length => class7075_0.Length;

	public override Class6976 this[int index] => class7075_0[index];

	public Class7079(Class7041 section, Class7075 rows)
	{
		class7075_0 = rows;
	}

	public override IEnumerator<Class6976> GetEnumerator()
	{
		return class7075_0.GetEnumerator();
	}

	public override Class6976 vmethod_0(string name)
	{
		return smethod_0(class7075_0, name);
	}

	internal static Class6976 smethod_0(Class7075 rows, string name)
	{
		if (rows == null)
		{
			return null;
		}
		foreach (Class7040 row in rows)
		{
			string text = row.method_20("ID");
			if (text != null && text.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return row;
			}
		}
		foreach (Class7040 row2 in rows)
		{
			string text2 = row2.method_20("NAME");
			if (text2 != null && text2.Equals(name, StringComparison.OrdinalIgnoreCase))
			{
				return row2;
			}
		}
		return null;
	}
}
