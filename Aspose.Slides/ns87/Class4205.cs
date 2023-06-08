using ns73;
using ns74;
using ns84;

namespace ns87;

internal class Class4205 : Class4154
{
	private readonly bool bool_0;

	private readonly Class4337 class4337_0;

	private bool bool_1;

	private bool bool_2;

	public Class4337 Degree => class4337_0;

	public bool IsLeftwards => bool_1;

	public bool IsRightwards => bool_2;

	internal Class4205(Class3679 cssValue)
		: base(cssValue)
	{
		if (base.IsIdentValue)
		{
			if (Class3700.Class3702.class3689_16 == cssValue)
			{
				bool_1 = true;
			}
			else if (Class3700.Class3702.class3689_17 == cssValue)
			{
				bool_2 = true;
			}
		}
		else
		{
			class4337_0 = Class4338.smethod_3((Class3681)cssValue);
		}
	}
}
