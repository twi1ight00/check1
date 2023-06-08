using System;
using System.Collections.Generic;

namespace ns33;

internal class Class1155
{
	private readonly Dictionary<Enum, Enum> dictionary_0;

	public object this[Enum enumValue]
	{
		get
		{
			dictionary_0.TryGetValue(enumValue, out var value);
			return value;
		}
	}

	public Class1155(params Enum[] values)
	{
		dictionary_0 = new Dictionary<Enum, Enum>(values.Length);
		for (int num = values.Length - 2; num >= 0; num -= 2)
		{
			dictionary_0[values[num]] = values[num + 1];
			dictionary_0[values[num + 1]] = values[num];
		}
	}
}
