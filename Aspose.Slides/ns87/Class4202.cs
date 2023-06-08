using System.Collections.Generic;
using System.Drawing;
using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4202 : Class4154
{
	private readonly Class4337 class4337_0;

	private readonly Class4337 class4337_1;

	private readonly Class4337 class4337_2;

	private readonly Color? nullable_0;

	private readonly bool bool_0;

	public bool IsNone => bool_0;

	public Color? Color => nullable_0;

	public Class4337 Blur => class4337_2;

	public Class4337 VShadow => class4337_1;

	public Class4337 HShadow => class4337_0;

	internal Class4202(Class3679 cssValue)
		: base(cssValue)
	{
		IEnumerator<Class3679> enumerator = ((Class3691)cssValue).GetEnumerator();
		int num = 0;
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			if (enumerator.Current == Class3700.Class3702.class3689_4)
			{
				break;
			}
			switch (num)
			{
			case 0:
				class4337_0 = Class4338.smethod_4(enumerator.Current);
				break;
			case 1:
				class4337_1 = Class4338.smethod_4(enumerator.Current);
				break;
			case 2:
				if (!(enumerator.Current is Class3685) && !(enumerator.Current is Class3682))
				{
					nullable_0 = ((Class3680)enumerator.Current).vmethod_6().method_0();
				}
				else
				{
					class4337_2 = Class4338.smethod_4(enumerator.Current);
				}
				break;
			case 3:
				nullable_0 = ((Class3680)enumerator.Current).vmethod_6().method_0();
				break;
			}
			num++;
		}
		bool_0 = true;
	}
}
