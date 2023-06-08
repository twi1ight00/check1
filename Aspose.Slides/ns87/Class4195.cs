using System.Collections.Generic;
using ns73;

namespace ns87;

internal class Class4195 : Class4154
{
	private bool bool_0;

	private IList<string> ilist_0;

	public bool None => bool_0;

	public IList<string> Values => ilist_0;

	internal Class4195(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsIdentValue && Class3700.Class3702.class3689_4 == cssValue)
		{
			bool_0 = true;
		}
		else
		{
			if (cssValue.CSSValueType != 2)
			{
				return;
			}
			ilist_0 = new List<string>();
			Class3691 @class = (Class3691)cssValue;
			foreach (Class3679 item in @class)
			{
				ilist_0.Add(((Class3680)item).vmethod_3());
			}
		}
	}
}
