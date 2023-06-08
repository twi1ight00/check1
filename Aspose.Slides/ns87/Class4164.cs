using System.Collections.Generic;
using ns73;

namespace ns87;

internal class Class4164 : Class4154
{
	private readonly Class4338 class4338_0;

	private readonly Class4338 class4338_1;

	private readonly Class4338 class4338_2;

	private readonly Class4338 class4338_3;

	public Class4338 Top => class4338_0;

	public Class4338 Right => class4338_1;

	public Class4338 Bottom => class4338_2;

	public Class4338 Left => class4338_3;

	internal Class4164(Class3679 value)
		: base(value)
	{
		IList<Class3679> list = new List<Class3679>();
		if (value.CSSValueType == 2)
		{
			foreach (Class3679 item in (Class3691)value)
			{
				list.Add(item);
			}
		}
		else
		{
			list.Add(value);
		}
		list = method_3(list);
		class4338_0 = Class4338.smethod_4(list[0]);
		class4338_1 = Class4338.smethod_4(list[1]);
		class4338_2 = Class4338.smethod_4(list[2]);
		class4338_3 = Class4338.smethod_4(list[3]);
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
