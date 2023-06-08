using System.Collections.Generic;
using ns73;

namespace ns87;

internal class Class4209 : Class4154
{
	public enum Enum588
	{
		const_0,
		const_1
	}

	private readonly string string_0;

	private readonly Enum588? nullable_0;

	private bool bool_0;

	private bool bool_1;

	public Enum588? UrlAttribute => nullable_0;

	public string Url => string_0;

	public bool IsAuto => bool_0;

	public bool IsNone => bool_1;

	internal Class4209(Class3679 value)
		: base(value)
	{
		IEnumerator<Class3679> enumerator = (value as Class3691).GetEnumerator();
		while (enumerator.MoveNext())
		{
			value = enumerator.Current;
			if (Class3700.Class3702.class3689_3 == value)
			{
				bool_0 = true;
			}
			else if (Class3700.Class3702.class3689_4 == value)
			{
				bool_1 = true;
			}
			else
			{
				if (value.CSSValueType != 1 || (((Class3680)value).PrimitiveType != 19 && ((Class3680)value).PrimitiveType != 20))
				{
					continue;
				}
				string_0 = ((Class3680)value).vmethod_3();
				if (enumerator.MoveNext())
				{
					value = enumerator.Current;
					if (Class3700.Class3702.class3689_88 == value)
					{
						nullable_0 = Enum588.const_0;
					}
					else if (Class3700.Class3702.class3689_26 == value)
					{
						nullable_0 = Enum588.const_1;
					}
				}
			}
		}
	}
}
