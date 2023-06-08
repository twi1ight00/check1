using System.Collections.Generic;
using ns73;

namespace ns87;

internal class Class4182 : Class4154
{
	private readonly Class4338 class4338_0;

	private readonly bool bool_0;

	private readonly bool bool_1;

	public Class4338 Value => class4338_0;

	public bool FromImage => bool_0;

	public bool Snap => bool_1;

	internal Class4182(Class3679 cssValue)
		: base(cssValue)
	{
		IEnumerator<Class3679> enumerator = ((Class3691)cssValue).GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (Class3700.Class3702.class3689_97 == enumerator.Current)
			{
				bool_0 = true;
			}
			else if (Class3700.Class3702.class3689_98 == enumerator.Current)
			{
				bool_1 = true;
			}
			else
			{
				class4338_0 = Class4338.smethod_4(enumerator.Current);
			}
		}
	}
}
