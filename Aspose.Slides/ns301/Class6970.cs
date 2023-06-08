using System;
using System.Globalization;
using ns284;
using ns290;

namespace ns301;

internal class Class6970 : Interface361
{
	public float imethod_0(Class6959 value, Class6845 container)
	{
		switch (value.Unit)
		{
		default:
			throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "The value.Unit is out of range: {0}", new object[1] { value.Unit }));
		case Enum955.const_0:
			return value.Value;
		case Enum955.const_3:
			return container.InnerBound.Width * value.Value / 100f;
		case Enum955.const_4:
			return value.Value * 0.75f;
		case Enum955.const_1:
		case Enum955.const_2:
		case Enum955.const_5:
		case Enum955.const_6:
		case Enum955.const_7:
		case Enum955.const_8:
			return value.Value;
		}
	}
}
