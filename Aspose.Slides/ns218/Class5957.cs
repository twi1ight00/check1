using System;
using System.Collections;

namespace ns218;

internal static class Class5957
{
	public static void smethod_0(object[] source, IDictionary importMap, IDictionary exportMap)
	{
		int num = source.Length / 2;
		for (int i = 0; i < num; i++)
		{
			importMap.Add(source[i * 2], source[i * 2 + 1]);
			exportMap?.Add(source[i * 2 + 1], source[i * 2]);
		}
	}

	public static object smethod_1(IDictionary map, object sourceValue, object defaultValue)
	{
		if (sourceValue != null)
		{
			object obj = map[sourceValue];
			if (obj != null)
			{
				return obj;
			}
		}
		if (defaultValue == null)
		{
			throw new InvalidOperationException($"Cannot convert '{sourceValue}'.");
		}
		return defaultValue;
	}

	public static object smethod_2(IDictionary map, object sourceValue)
	{
		return smethod_1(map, sourceValue, null);
	}

	public static object smethod_3(IDictionary map, object sourceValue)
	{
		if (sourceValue == null)
		{
			return null;
		}
		return map[sourceValue];
	}

	public static bool smethod_4(int value, int flag)
	{
		return (value & flag) == flag;
	}
}
