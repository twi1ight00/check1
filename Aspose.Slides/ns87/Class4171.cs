using ns73;

namespace ns87;

internal class Class4171 : Class4154
{
	private bool bool_0;

	private Class4338 class4338_0;

	public bool IsNormal => bool_0;

	public Class4338 Length => class4338_0;

	internal Class4171(Class3679 value)
		: base(value)
	{
		if (value == Class3700.Class3702.class3689_5)
		{
			bool_0 = true;
		}
		else
		{
			class4338_0 = Class4338.smethod_4(value);
		}
	}
}
