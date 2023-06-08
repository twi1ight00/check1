using System.Collections.Generic;
using ns73;
using ns84;

namespace ns87;

internal class Class4199 : Class4154
{
	private List<Enum567> list_0;

	private bool bool_0;

	public IList<Enum567> Styles => list_0.AsReadOnly();

	public bool Auto => bool_0;

	internal Class4199(Class3679 value)
		: base(value)
	{
		list_0 = new List<Enum567>();
		if (!base.IsListValue)
		{
			if (Class3700.Class3702.class3689_3 == value)
			{
				bool_0 = true;
			}
			else
			{
				list_0.Add(Class4342.smethod_0<Enum567>().imethod_3(method_0()));
			}
			return;
		}
		Class3691 @class = value as Class3691;
		foreach (Class3680 item in @class)
		{
			if (Class3700.Class3702.class3689_0 != item)
			{
				list_0.Add(Class4342.smethod_0<Enum567>().imethod_3(item.vmethod_3()));
			}
		}
	}
}
