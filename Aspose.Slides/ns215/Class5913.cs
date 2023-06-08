using System;
using System.Collections;
using Aspose.XfaConverter.Elements;

namespace ns215;

internal class Class5913
{
	private readonly Hashtable hashtable_0;

	internal object this[Enum739 type] => hashtable_0[type];

	internal int Count => hashtable_0.Count;

	internal IEnumerable Keys => hashtable_0.Keys;

	internal void Add(Enum739 formatType, object formatValue)
	{
		hashtable_0[formatType] = formatValue;
	}

	internal bool method_0(Enum739 type)
	{
		return hashtable_0.ContainsKey(type);
	}

	internal void method_1(Enum739 type)
	{
		if (!method_0(type))
		{
			throw new ArgumentException("Please report exception.");
		}
		hashtable_0.Remove(type);
	}

	internal void method_2(Enum739 type, ref string @object)
	{
		if (hashtable_0.ContainsKey(type))
		{
			@object = (string)hashtable_0[type];
		}
	}

	internal void method_3(Enum739 type, ref float @object)
	{
		if (hashtable_0.ContainsKey(type))
		{
			@object = (float)hashtable_0[type];
		}
	}

	internal void method_4(Enum739 type, ref int @object)
	{
		if (hashtable_0.ContainsKey(type))
		{
			@object = (int)hashtable_0[type];
		}
	}

	internal void method_5(Enum739 type, ref bool @object)
	{
		if (hashtable_0.ContainsKey(type))
		{
			@object = (bool)hashtable_0[type];
		}
	}

	internal void method_6(Enum739 type, ref XfaEnums.Enum719 @object)
	{
		if (hashtable_0.ContainsKey(type))
		{
			@object = (XfaEnums.Enum719)hashtable_0[type];
		}
	}

	internal void method_7(Enum739 type, ref XfaEnums.Enum720 @object)
	{
		if (hashtable_0.ContainsKey(type))
		{
			@object = (XfaEnums.Enum720)hashtable_0[type];
		}
	}

	internal Class5913()
	{
		hashtable_0 = new Hashtable();
	}

	internal Class5913(Class5913 collection)
	{
		if (collection != null)
		{
			hashtable_0 = (Hashtable)collection.hashtable_0.Clone();
		}
		else
		{
			hashtable_0 = new Hashtable();
		}
	}
}
