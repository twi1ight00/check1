using System.Collections.Generic;
using ns73;
using ns84;

namespace ns87;

internal class Class4174 : Class4154
{
	private Class4337 class4337_0;

	private Class4337 class4337_1;

	private Enum532? nullable_0;

	private Enum531? nullable_1;

	public Class4337 Width => class4337_0;

	public Class4337 Height => class4337_1;

	public Enum531? Orientation => nullable_1;

	public Enum532? Size => nullable_0;

	internal Class4174(Class3679 cssValue)
		: base(cssValue)
	{
		IEnumerator<Class3679> enumerator = ((Class3691)cssValue).GetEnumerator();
		enumerator.MoveNext();
		if (enumerator.Current == Class3700.Class3702.class3689_3)
		{
			nullable_1 = Enum531.const_0;
			return;
		}
		if (((Class3680)enumerator.Current).PrimitiveType == 21)
		{
			if (enumerator.Current != Class3700.Class3702.class3689_295 && enumerator.Current != Class3700.Class3702.class3689_296)
			{
				nullable_0 = Class4342.smethod_1<Enum532>(enumerator.Current.CSSText);
			}
			else
			{
				nullable_1 = Class4342.smethod_1<Enum531>(enumerator.Current.CSSText);
			}
			if (enumerator.MoveNext())
			{
				nullable_1 = Class4342.smethod_1<Enum531>(enumerator.Current.CSSText);
			}
			return;
		}
		class4337_0 = Class4338.smethod_4(enumerator.Current);
		if (enumerator.MoveNext())
		{
			if (((Class3680)enumerator.Current).PrimitiveType == 21)
			{
				class4337_1 = class4337_0;
				nullable_1 = Class4342.smethod_1<Enum531>(enumerator.Current.CSSText);
				return;
			}
			class4337_1 = Class4338.smethod_4(enumerator.Current);
			if (enumerator.MoveNext())
			{
				nullable_1 = Class4342.smethod_1<Enum531>(enumerator.Current.CSSText);
			}
		}
		else
		{
			class4337_1 = class4337_0;
		}
	}
}
