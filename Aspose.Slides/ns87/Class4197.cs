using System.Collections.Generic;
using ns73;

namespace ns87;

internal class Class4197 : Class4154
{
	private bool bool_0;

	private IList<Class4338> ilist_0 = new List<Class4338>();

	public bool None => bool_0;

	public IList<Class4338> Values => ilist_0;

	internal Class4197(Class3679 value)
		: base(value)
	{
		if (!base.IsListValue)
		{
			if (Class3700.Class3702.class3689_4 == value)
			{
				bool_0 = true;
			}
			else
			{
				ilist_0.Add(Class4338.smethod_4(value));
			}
			return;
		}
		Class3691 @class = value as Class3691;
		foreach (Class3679 item in @class)
		{
			ilist_0.Add(Class4338.smethod_4(item));
		}
	}
}
