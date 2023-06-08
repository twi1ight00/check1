using System.Collections.Generic;
using ns73;

namespace ns87;

internal class Class4228 : Class4154
{
	private IList<string> ilist_0;

	public IList<string> Fonts => ilist_0;

	internal Class4228(Class3679 value)
		: base(value)
	{
		ilist_0 = new List<string>();
		Class3691 @class = (Class3691)value;
		foreach (Class3679 item in @class)
		{
			ilist_0.Add(((Class3680)item).vmethod_3());
		}
	}
}
