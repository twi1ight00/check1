using System.Collections.Generic;
using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4163 : Class4154
{
	private readonly Class4337 class4337_0;

	private readonly Class4337 class4337_1;

	private readonly Class4337 class4337_2;

	private readonly Class4337 class4337_3;

	private bool bool_0;

	public Class4337 Top => class4337_0;

	public Class4337 Right => class4337_1;

	public Class4337 Bottom => class4337_2;

	public Class4337 Left => class4337_3;

	public bool Fill
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

	internal Class4163(Class3679 value)
		: base(value)
	{
		IList<Class3679> list = new List<Class3679>();
		if (value.CSSValueType == 2)
		{
			foreach (Class3679 item in (Class3691)value)
			{
				if (item == Class3700.Class3702.class3689_29)
				{
					bool_0 = true;
				}
				else
				{
					list.Add(item);
				}
			}
		}
		else
		{
			list.Add(value);
		}
		list = method_3(list);
		class4337_0 = Class4338.smethod_3((Class3681)list[0]);
		class4337_1 = Class4338.smethod_3((Class3681)list[1]);
		class4337_2 = Class4338.smethod_3((Class3681)list[2]);
		class4337_3 = Class4338.smethod_3((Class3681)list[3]);
	}

	private IList<Class3679> method_3(IList<Class3679> tokens)
	{
		Class3679[] array = new Class3679[4];
		tokens.CopyTo(array, 0);
		switch (tokens.Count)
		{
		case 1:
			array[1] = (array[2] = (array[3] = tokens[0]));
			break;
		case 2:
			array[2] = tokens[0];
			array[3] = tokens[1];
			break;
		case 3:
			array[3] = tokens[1];
			break;
		}
		return array;
	}
}
